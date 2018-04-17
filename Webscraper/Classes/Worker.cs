﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.HtmlControls;
using HtmlAgilityPack;
using Microsoft.Win32;

namespace Webscraper.Classes
{
    public static class Worker
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SystemParametersInfo(
            UInt32 action, UInt32 uParam, String vParam, UInt32 winIni);

        [DllImport("wininet.dll")]
        private static extern bool InternetGetConnectedState(out int Description, int ReservedValue);

        const UInt32 SPI_SETDESKWALLPAPER = 0x14;
        const UInt32 SPIF_UPDATEINIFILE = 0x01;
        const UInt32 SPIF_SENDWININICHANGE = 0x02;
        
        private static List<string> ImageList = new List<string>();
        private static Random rnd = new Random();

        private static RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true);

        public static void ImageSetter(string url)
        {
            if (!CheckNet())
            {
                NoConnExistingImage();
                return;
            }
            var page = rnd.Next(0, 27);
            if (page == 0)
                GetAllImages(url);
            else
            {
                url += $@"page/{page}/";
                GetAllImages(url);
            }
        }

        private static bool CheckNet()
        {
            int desc;
            return InternetGetConnectedState(out desc, 0);
        }

        private static void NoConnExistingImage()
        {
            var files = Directory.GetFiles(@"E:\webscraper\", "*.*");
            var file = files[rnd.Next(files.Length)];

            SetImage(file);
        }

        private static void GetAllImages(string url)
        {
            WebClient webclient = new WebClient();
            string source = webclient.DownloadString(@url);
            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(source);

            foreach (var result in document.DocumentNode.Descendants("img").Select(x=>x.Attributes["src"]))
            {
                if (result.Value.Contains("wallpaper"))
                {
                    var res = result.Value.LastIndexOf("-");
                    var full = result.Value.Remove(res, 8);
                    ImageList.Add(full);
                }
            }

            int pictureNum = rnd.Next(0, ImageList.Count -1);
            var diff1 = ImageList[pictureNum].LastIndexOf(@"/");
            diff1++;
            var diff2 = ImageList[pictureNum].LastIndexOf("g");
            diff2++;
            var diff = diff2 - diff1;

            var file = ImageList[pictureNum].Substring(diff1, diff);
            var fullName = $@"E:\webscraper\{file}";

            if (!File.Exists(fullName))
            {
                var image = webclient.DownloadData(ImageList[pictureNum]);
                File.WriteAllBytes(fullName, image);
            }

            SetImage(fullName);
        }

        private static void SetImage(string file)
        {
            string currentBackground = key.GetValue("Wallpaper").ToString();
            if (currentBackground == file)
            {
                NoConnExistingImage();
                return;
            }

            key.SetValue(@"WallpaperStyle", 1.ToString());
            key.SetValue(@"TileWallpaper", 0.ToString());

            SystemParametersInfo(SPI_SETDESKWALLPAPER,
                0,
                file,
                SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
        }
    }
}
