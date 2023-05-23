using Assets.Source.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Source.Services
{
    public class LocalizationService : MonoBehaviour, ILocalizationService
    {
        private LocalLanguage currentLanguage = LocalLanguage.EnUs;
        private Dictionary<LocalLanguage, Dictionary<string, string>> localizationMapping = new();
        private List<LocalizationLibrary> preloadedLibraries;

        public event ILocalizationService.OnCurrentLanguageChangedEventHandler OnCurrentLanguageChanged;

        public LocalLanguage CurrentLanguage
        {
            get => currentLanguage;
            set
            {
                var old = currentLanguage;
                if (value != old)
                {
                    currentLanguage = value;
                    OnCurrentLanguageChanged?.Invoke(old, value);
                }
            }
        }

        public bool IsReady
        {
            get;
            private set;
        } = false;

        public Dictionary<LocalLanguage, Dictionary<string, string>> LocalizationMapping { get => localizationMapping; set => localizationMapping = value; }
        public List<LocalizationLibrary> PreloadedLibraries { get => preloadedLibraries; set => preloadedLibraries = value; }

        public void Awake()
        {
            PreloadedLibraries = Resources.LoadAll<LocalizationLibrary>("PreloadedLocalizationLibraries/").ToList();
            LoadAllLibraries();
            IsReady = true;
        }

        public string GetText(string key)
        {
            var dict = LocalizationMapping[CurrentLanguage];

            if (dict.TryGetValue(key.ToLower(), out var str))
            {
                return str;
            }
            return null;
        }

        public void LoadAllLibraries()
        {
            foreach (var preloadedLibrary in PreloadedLibraries)
            {
                LoadLibrary(preloadedLibrary);
            }
        }

        public void LoadLibrary(LocalizationLibrary library)
        {
            foreach (var kv in library.keyValues)
            {
                int i = 0;
                foreach (LocalLanguage language in Enum.GetValues(typeof(LocalLanguage)))
                {
                    if (!LocalizationMapping.ContainsKey(language))
                    {
                        LocalizationMapping[language] = new();
                    }

                    var dict = LocalizationMapping[language];

                    var localizationValue = kv.value.ElementAtOrDefault(i);

                    localizationValue ??= "";

                    var key = $"{library.prefix.ToLower()}_{kv.key.ToLower()}";

                    if (!dict.ContainsKey(key))
                    {
                        dict.Add(key, localizationValue);
                    }

                    i++;
                }
            }
        }

        public bool TryGetText(string key, out string result)
        {
            result = GetText(key);
            return result != null;
        }
    }
}