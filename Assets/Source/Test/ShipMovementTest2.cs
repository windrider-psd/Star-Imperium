using UnityEngine;

namespace Assets.Source.Test
{
    public class ShipMovementTest2 : MonoBehaviour
    {
        public float acceleration;
        public float maxSpeed;
        public float rotationSpeed;
        public float speed;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            //Gizmos.DrawLine(transform.position, transform.up);
            Gizmos.DrawRay(transform.position, transform.up);
        }

        // Use this for initialization
        private void Start()
        {
            var pos = transform.position + transform.up * acceleration;

            var rot = transform.rotation * Quaternion.AngleAxis(rotationSpeed, transform.forward);
            //Instantiate(this.gameObject, pos, rot);
        }

        // Update is called once per frame
        private void Update()
        {
            if (Input.GetKey(KeyCode.W))
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

            if (Input.GetKey(KeyCode.A))
                transform.rotation *= Quaternion.AngleAxis(rotationSpeed * Time.deltaTime, transform.forward);

            if (Input.GetKey(KeyCode.D))
                transform.rotation *= Quaternion.AngleAxis(rotationSpeed * Time.deltaTime, -transform.forward);
        }
    }
}