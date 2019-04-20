﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Caching;
using System.Runtime.InteropServices;
using HtmlAgilityPack;
using Microsoft.Win32;
using Webscraper.Core.Workflow;

namespace ImageSetter.Workflow
{
    public static class WallpaperChanger
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SystemParametersInfo(
            UInt32 action, UInt32 uParam, String vParam, UInt32 winIni);

        const UInt32 SPI_SETDESKWALLPAPER = 0x14;
        const UInt32 SPIF_UPDATEINIFILE = 0x01;
        const UInt32 SPIF_SENDWININICHANGE = 0x02;

        private static Random rnd = new Random();

        private static RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true);
        private static string _currentBackGround = (string) key.GetValue("WallPaper");

        public static void ImageSetter(string url, string[] args)
        {
            if (args.Contains("BlackList"))
                BlackListCurrentBackground();

            if (args.Contains("Previous"))
            {
                SetPreviousBackground();
                return;
            }
                
            if (!ConnectionChecker.CheckNet())
            {
                NoConnExistingImage();
                return;
            }
            var page = rnd.Next(0, 27);

            if (page != 0)
                url += $@"page/{page}";

            try
            {
                var document = Scraper.GetHtmlDocument(url);
                DownloadImage(document);
            }
            catch (Exception)
            {
                NoConnExistingImage();
            }
        }

        private static void BlackListCurrentBackground()
        {
            var currentBackGround = Path.GetFileNameWithoutExtension(_currentBackGround);
            var path = new FileInfo(@"E:\webscraper\Config\blacklist.txt");
            if (!path.Directory.Exists)
                Directory.CreateDirectory(path.Directory.FullName);
            
            File.AppendAllLines(path.FullName, new List<string>{ currentBackGround });
        }

        private static void SetPreviousBackground()
        {
            var path = new FileInfo(@"E:\webscraper\Config\previous.txt");
            if (!path.Directory.Exists)
                return;

            if (File.Exists(path.FullName))
            {
                var previousBackGround = File.ReadAllLines(path.FullName).FirstOrDefault();
                if (previousBackGround == null)
                    return;

                SetImage(previousBackGround);
            }
        }

        private static void DownloadImage(HtmlDocument document)
        {
            var imageList = new List<string>();
            foreach (var result in document.DocumentNode.Descendants("img").Select(x => x.Attributes["src"]))
            {
                if (result.Value.Contains("wallpaper"))
                {
                    var res = result.Value.LastIndexOf("-");
                    var full = result.Value.Remove(res, 8);
                    imageList.Add(full);
                }
            }

            imageList = RemoveBlackListed(imageList);

            if (!imageList.Any())
                return;

            int pictureNum = rnd.Next(0, imageList.Count - 1);
            var diff1 = imageList[pictureNum].LastIndexOf(@"/");
            diff1++;
            var diff2 = imageList[pictureNum].LastIndexOf("g");
            diff2++;
            var diff = diff2 - diff1;

            var file = imageList[pictureNum].Substring(diff1, diff);
            var fullName = $@"E:\webscraper\{file}";

            if (!File.Exists(fullName))
            {
                var image = Scraper.Webclient.DownloadData(imageList[pictureNum]);
                File.WriteAllBytes(fullName, image);
            }

            SetImage(fullName);
        }

        private static List<string> RemoveBlackListed(List<string> images)
        {
            var path = new FileInfo(@"E:\webscraper\Config\blacklist.txt");
            if (path.Exists)
            {
                var blackListedItems = File.ReadAllLines(path.FullName);
                images.RemoveAll(image => IsBlackListed(image, blackListedItems));   
            }

            return images;
        }

        private static bool IsBlackListed(string picture, string[] blackListedItems)
        { 
            foreach (string item in blackListedItems)
            {
                if (string.IsNullOrWhiteSpace(item))
                    continue;

                if (picture.Contains(item))
                    return true;
            }

            return false;
        }

        private static void NoConnExistingImage()
        {
            var files = Directory.GetFiles(@"E:\webscraper\", "*.*").ToList();
            files = RemoveBlackListed(files);
            var file = files[rnd.Next(files.Count) - 1];

            SetImage(file);
        }

        private static void SetImage(string file)
        {
            SavePreviousBackGround();
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

        private static void SavePreviousBackGround()
        {
            var path = new FileInfo(@"E:\webscraper\Config\previous.txt");
            if (!path.Directory.Exists)
                Directory.CreateDirectory(path.Directory.FullName);

            File.WriteAllLines(path.FullName, new List<string> {_currentBackGround});
        }
    }
}
