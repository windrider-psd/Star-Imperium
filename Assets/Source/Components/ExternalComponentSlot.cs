using Assets.Source.Miscellaneous;
using UnityEngine;

namespace Assets.Source.Components
{
    public class ExternalComponentSlot : MonoBehaviour
    {
        [SerializeField]
        public ExternalComponentType externalComponentType;

        [SerializeField]
        public int number;

        [SerializeField]
        public ScaleClassification scaleClassification;

        [SerializeField]
        private ExternalComponent externalComponent;

        public ExternalComponent ExternalComponent { get => externalComponent; set => externalComponent = value; }
        public ExternalComponentType ExternalComponentType { get => externalComponentType; set => externalComponentType = value; }
        public int Number { get => number; set => number = value; }

        public Sprite Sprite
        {
            get => GetComponent<SpriteRenderer>().sprite;
            set => GetComponent<SpriteRenderer>().sprite = value;
        }

        public void Update()
        {
            if (ExternalComponent != null)
            {
                ExternalComponent.Update();
            }
        }
    }
}