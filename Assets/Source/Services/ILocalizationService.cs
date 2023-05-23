using Assets.Source.Localization;
using System;

namespace Assets.Source.Services
{
    public interface ILocalizationService
    {
        public delegate void OnCurrentLanguageChangedEventHandler(LocalLanguage oldValue, LocalLanguage newValue);
        public event OnCurrentLanguageChangedEventHandler OnCurrentLanguageChanged;

        public LocalLanguage CurrentLanguage { get; set; }

        public string GetText(string key);
        public bool TryGetText(string key, out string result);

        public void LoadLibrary(LocalizationLibrary library);
        public void LoadAllLibraries();
    }
}