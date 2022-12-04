using UnityEngine;

namespace Assets.Source.Entities.Miscellaneous
{
    public class Asteroid : MapEntity
    {
        public Sprite Sprite
        {
            get => GetComponent<SpriteRenderer>().sprite;
            set
            {
                GetComponent<SpriteRenderer>().sprite = value;
            }
        }

        public void Update()
        {
            //sectorHashGridClient.Update();
        }
    }
}