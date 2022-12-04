using System.Collections;
using UnityEngine;

namespace Assets.Source.Test
{
    public class AutoShipMovementTest : MonoBehaviour
    {
        public float acceleration;
        public float angle;
        public float angleAxis;
        public Vector3 direction;
        public Vector3 forwardDirection;
        public float maxSpeed;
        public float rotationSpeed;
        public float speed;
        public GameObject target;
        public Quaternion targetRotation;
        public float testAngle;
        private bool started = false;

        private float time = 0;

        private IEnumerator Fade()
        {
            yield return new WaitForSeconds(1f);

            // Get the Renderer component from the new cube
            var cubeRenderer = GetComponent<Renderer>();

            // Call SetColor using the shader property name "_Color" and setting the color to red
            cubeRenderer.material.SetColor("_Color", Color.blue);

            Debug.Log(transform.position.y);
            Debug.Log(0 * 1 + (1 / 2) * acceleration * 1 * 1);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            //Gizmos.DrawLine(transform.position, transform.up);
            Gizmos.DrawRay(transform.position, transform.up);
            Gizmos.DrawRay(transform.position, target.transform.position - transform.position);
        }

        private void RotateBackwards()
        {
            transform.rotation *= Quaternion.AngleAxis(rotationSpeed * Time.deltaTime, -transform.forward);
        }

        private void RotateForward()
        {
            transform.rotation *= Quaternion.AngleAxis(rotationSpeed * Time.deltaTime, transform.forward);
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
                if (!started)
                {
                    started = true;

                    StartCoroutine(Fade());
                }

                if (time >= 1f)
                {
                    float x = (1f / 2) * acceleration * Mathf.Pow(time, 2);
                }

                direction = (target.transform.position - transform.position).normalized;
                forwardDirection = transform.up;

                angle = Vector3.Angle(transform.up, (target.transform.position - transform.position));
                angleAxis = transform.rotation.eulerAngles.z;
                speed += acceleration * Time.deltaTime;
                if (speed > maxSpeed)
                {
                    speed = maxSpeed;
                }

                testAngle = Mathf.Atan2(target.transform.position.y - transform.position.y, target.transform.position.x - transform.position.x) * Mathf.Rad2Deg;

                targetRotation = Quaternion.Euler(new Vector3(0, 0, testAngle));

                float aangle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
                Quaternion q = Quaternion.AngleAxis(aangle, -transform.forward);

                transform.rotation = Quaternion.RotateTowards(transform.rotation, q, rotationSpeed * Time.deltaTime);

                transform.position += transform.up * speed * Time.deltaTime;
                time += Time.deltaTime;
            }
        }
    }
}