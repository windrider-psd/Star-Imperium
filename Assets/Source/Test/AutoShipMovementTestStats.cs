using UnityEngine;

namespace Assets.Source.Test
{
    [ExecuteInEditMode]
    public class AutoShipMovementTestStats : MonoBehaviour
    {
        public float acceleration;
        public float angle;
        public float angleAxis;
        public float angulartime;
        public Vector3 direction;
        public float distance;
        public Vector3 forwardDirection;
        public float maxSpeed;
        public float rotationSpeed;
        public float speed;
        public GameObject target;
        public float time;

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
            direction = (target.transform.position - transform.position).normalized;
            forwardDirection = transform.up;

            angle = Vector3.Angle(transform.up, (target.transform.position - transform.position));
            angleAxis = transform.rotation.eulerAngles.z;

            distance = (target.transform.position - transform.position).magnitude;
            time = distance / maxSpeed;

            angulartime = angle / rotationSpeed;
        }
    }
}