using System.Collections;
using UnityEngine;

namespace Assets.Source.Cameras
{
    public class ParallaxEffect : MonoBehaviour
    {
        public float length;
        public float height;
        public GameObject cam;
        public Vector3 startPosition;
        public float parallaxEffect;

        public void Start()
        {
            startPosition = transform.position;
            length = GetComponent<SpriteRenderer>().bounds.size.x;
            height = GetComponent<SpriteRenderer>().bounds.size.y;
        }

        public void LateUpdate()
        {
            float tempx = (cam.transform.position.x * (1 - parallaxEffect));
            float distx = (cam.transform.position.x * parallaxEffect);

            float tempy = (cam.transform.position.y * (1 - parallaxEffect));
            float disty = (cam.transform.position.y * parallaxEffect);

            transform.position = new(startPosition.x + distx, startPosition.y + disty, transform.position.z);

            if(tempx > startPosition.x + length) startPosition.x += length;
            else if(tempx < startPosition.x - length) startPosition.x -= length;

            if (tempy > startPosition.y + height) startPosition.y += height;
            else if (tempy < startPosition.y - height) startPosition.y -= height;
        }
    }
}