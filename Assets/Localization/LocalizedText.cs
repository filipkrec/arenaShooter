using System;
using TMPro;
using UnityEngine;

public class LocalizedText : MonoBehaviour
{
    [SerializeField] private string m_code;
    [SerializeField] private TextAsset m_localizationSheet;

    [SerializeField] private TextMeshProUGUI m_text;

    private void Start()
    {
        Localization.OnLanguageChanged += SetLanguage;
        SetLanguage(Localization.s_CurrentLanguage);
    }

    public string GetLocalizedText(string _language)
    {
        if (m_localizationSheet == null || string.IsNullOrEmpty(m_code) || string.IsNullOrEmpty(_language))
        {
            Debug.LogError($"Missing data: Sheet={m_localizationSheet != null}, Code='{m_code}', Language='{_language}'");
            return string.Empty;
        }

        string[] lines = m_localizationSheet.text.Split(
            new[] { '\n', '\r' },
            StringSplitOptions.RemoveEmptyEntries
        );

        if (lines.Length < 2)
        {
            Debug.LogError("Localization sheet does not contain enough lines.");
            return string.Empty;
        }

        string[] headerColumns = lines[0].Split(',');

        int languageColumnIndex = -1;
        for (int i = 1; i < headerColumns.Length; i++)
        {
            string header = headerColumns[i].Trim();

            if (header.Equals(_language, StringComparison.OrdinalIgnoreCase))
            {
                languageColumnIndex = i;
            }
        }

        if (languageColumnIndex == -1)
        {
            Debug.LogError($"Language '{_language}' not found in header.");
            return string.Empty;
        }

        //skip headers
        for (int i = 1; i < lines.Length; i++)
        {
            string[] columns = lines[i].Split(',');

            string codeValue = columns[0].Trim();

            if (codeValue.Equals(m_code, StringComparison.OrdinalIgnoreCase))
            {
                return columns[languageColumnIndex].Trim();
            }
        }

        Debug.LogError($"Code '{m_code}' not found for language '{_language}'.");
        return string.Empty;
    }

    private void OnDestroy()
    {
        Localization.OnLanguageChanged -= SetLanguage;
    }

    private void SetLanguage(string _language)
    {
        m_text.text = GetLocalizedText(_language);
    }
}
