using System;
using UnityEngine;

public static class Localization
{
    public const string LANGUAGE_DEFAULT = "English";
    public static Action<string> OnLanguageChanged;
    public static string s_CurrentLanguage
    {
        get
        {
            if (string.IsNullOrEmpty(s_currentLanguage))
            {
                s_currentLanguage = LoadLanguageFromPrefs();
            }

            return s_currentLanguage;
        }
    }

    private static string s_currentLanguage;

    private const string PLAYER_PREFS_LANGUAGE_KEY = "SelectedLanguage";

    public static void SetLanguage(string _language)
    {
        OnLanguageChanged?.Invoke(_language);
        s_currentLanguage = _language;
        PlayerPrefs.SetString(PLAYER_PREFS_LANGUAGE_KEY, _language);
    }

    private static string LoadLanguageFromPrefs()
    {
        return PlayerPrefs.GetString(PLAYER_PREFS_LANGUAGE_KEY, LANGUAGE_DEFAULT);
    }
}
