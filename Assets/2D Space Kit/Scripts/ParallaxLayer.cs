using UnityEngine;

public class ParallaxLayer : MonoBehaviour
{
    public float movement_resistance = 1f;
    private Vector3 wantedPosition;
    //1 = no movement, 0.9 = some movement, 0.5 = more movement, etc, 0 = centered at origin, layer is now foreground

    // Update is called once per frame
    private void LateUpdate()
    {
        wantedPosition = Camera.main.transform.position * movement_resistance;
        wantedPosition.z = transform.position.z;
        transform.position = wantedPosition;
    }

    // Use this for initialization
    private void Start()
    {
    }
}