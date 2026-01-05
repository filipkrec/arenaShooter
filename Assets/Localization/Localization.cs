using System;

public static class Localization
{
    public static Action<string> OnLanguageChanged;

    public static void SetLanguage(string _language)
    {
        OnLanguageChanged?.Invoke(_language);
    }
}
