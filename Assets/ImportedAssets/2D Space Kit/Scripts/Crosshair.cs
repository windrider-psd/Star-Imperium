using UnityEngine;

public class Crosshair : MonoBehaviour
{
    private Vector3 wanted_position;

    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        wanted_position = CustomPointer.pointerPosition;
        wanted_position.z = transform.position.z;
        transform.position = wanted_position;
    }
}