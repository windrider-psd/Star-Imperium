using Assets.Source.Utilities;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.Test
{
    public class ShipMovementTest3 : MonoBehaviour
    {
        public float acceleration;
        public List<UnityTuple<float, float>> listtest;
        public float maxSpeed;
        public float rotationSpeed;
        public float speed;
        // Use this for initialization

        private void MoveFormward()
        {
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            //Gizmos.DrawLine(transform.position, transform.up);
            Gizmos.DrawRay(transform.position, transform.up);
        }

        private void Start()
        {
            //Instantiate(this.gameObject, pos, rot);
        }

        // Update is called once per frame
        private void Update()
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                speed += acceleration * Time.deltaTime;
                if (speed > maxSpeed)
                {
                    speed = maxSpeed;
                }
            }
            else
            {
                speed -= acceleration * Time.deltaTime;
                if (speed < 0)
                {
                    speed = 0;
                }
            }
            var up = transform.up;
            var pos = transform.position;
            // transform.position = new Vector3(pos.x, pos.y * up.y, pos.z) * speed * Time.deltaTime;

            transform.position += transform.up * speed * Time.deltaTime;

            if (Input.GetKey(KeyCode.LeftArrow))
                transform.rotation *= Quaternion.AngleAxis(rotationSpeed * Time.deltaTime, transform.forward);

            if (Input.GetKey(KeyCode.RightArrow))
                transform.rotation *= Quaternion.AngleAxis(rotationSpeed * Time.deltaTime, -transform.forward);
        }
    }
}