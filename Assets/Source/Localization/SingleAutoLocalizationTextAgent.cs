using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Source.Localization
{
    public class SingleAutoLocalizationTextAgent
    {
        private string localizationKey;
        private SingletonComponentFinder<LocalizationManager> LManager => new();

        public string LocalizationKey
        {
            get => localizationKey;
            set
            {
                localizationKey = value;
                LoadTexts();
            }
        }

        void Start()
        {
            LoadTexts();

            LManager.Instance.OnCurrentLanguageChanged += OnLanguageUpdated;
            LManager.Instance.OnMappingUpdated += OnMappingUpdated;

            GameSceneManager.Instance.OnSceneStartedLoadingCleanUp.AddListener(() =>
            {
                LocalizationManager.Instance.OnCurrentLanguageChanged -= OnLanguageUpdated;
                LocalizationManager.Instance.OnMappingUpdated -= OnMappingUpdated;
            });

        }


        private void OnLanguageUpdated(LocalLanguage oldValue, LocalLanguage newValue)
        {
            LoadTexts();
        }

        private void OnMappingUpdated()
        {
            LoadTexts();
        }


        private void LoadTexts()
        {
            if (LManager.Instance.TryGetText(LocalizationKey, out var str))
            {
                GetComponent<TMPro.TMP_Text>().text = str;
            }
            else
            {
                Debug.LogWarning($"Failed to get localization key {LocalizationKey}");
            }
        }

    }
}
