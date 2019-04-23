using System.Configuration;

namespace ImageSetter.Utils
{
    public static class ConfigReader
    {
        private const string PreviousKey = "previous";
        private const string BlacklistKey = "blacklist";
        private const string WallpaperSiteKey = "wallpaperSite";
        private const string ImageLocationKey = "imageLocation";

        public static string Previous
        {
            get => OpenConfigManager().AppSettings.Settings[PreviousKey].Value;
            set => SaveConfigurationManager(PreviousKey, value);
        }

        public static string Blacklist
        {
            get => OpenConfigManager().AppSettings.Settings[BlacklistKey].Value;
            private set => SaveConfigurationManager(BlacklistKey, value);
        }

        public static void AddBlacklist(string name)
        {
            var blacklist = OpenConfigManager().AppSettings.Settings[BlacklistKey].Value;
            Blacklist = $"{blacklist},{name}";
        }

        public static string WallpaperSite
        {
            get => OpenConfigManager().AppSettings.Settings[WallpaperSiteKey].Value;
            set => SaveConfigurationManager(WallpaperSiteKey, value);
        }

        public static string ImageLocation
        {
            get => OpenConfigManager().AppSettings.Settings[ImageLocationKey].Value;
            set => SaveConfigurationManager(ImageLocationKey, value);
        }

        private static void SaveConfigurationManager(string settingKey, string settingValue)
        {
            var configManager = OpenConfigManager();

            configManager.AppSettings.Settings[settingKey].Value = settingValue;

            configManager.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        private static Configuration OpenConfigManager() => ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
    }
}