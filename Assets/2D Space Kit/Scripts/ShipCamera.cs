using UnityEngine;

public class ShipCamera : MonoBehaviour
{
    public float follow_tightness;
    public Transform target_object;
    private Vector3 wanted_position;

    // Update is called once per frame
    private void LateUpdate()
    {
        if (target_object != null)
        {
            wanted_position = target_object.position;
            wanted_position.z = transform.position.z;
            transform.position = wanted_position;
        }
        
    }

    // Use this for initialization
    private void Start()
    {
    }
}