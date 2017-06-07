using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace NFLTeamsApp.Helpers
{
    public static class Settings
    {
        private static ISettings AppSettings => CrossSettings.Current;

        const string UserIdKey = "userId";
        static readonly string UserIdDefault = string.Empty;
        public static string UserId
        {
            get { return AppSettings.GetValueOrDefault<string>(UserIdKey, UserIdDefault); }
            set { AppSettings.AddOrUpdateValue<string>(UserIdKey, value); }
        }

        const string AuthTokenKey = "authtoken";
        static readonly string AuthTokenDefault = string.Empty;
        public static string AuthToken
        {
            get { return AppSettings.GetValueOrDefault<string>(AuthTokenKey, AuthTokenDefault); }
            set { AppSettings.AddOrUpdateValue<string>(AuthTokenKey, value); }
        }

        const string Avatar = "";


        public static bool IsLoaggedIn => !string.IsNullOrWhiteSpace(UserId);
    }
}