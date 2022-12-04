using UnityEngine;

public class AimBeam : MonoBehaviour
{
    public LineRenderer lnRenderer;
    public float visual_Distance = 1024f;
    private Vector2 beam;

    // Use this for initialization
    private void Start()
    {
        beam = new Vector2(0, visual_Distance);
        lnRenderer.SetPosition(0, Vector2.zero);
        lnRenderer.SetPosition(1, beam);
    }

    // Update is called once per frame
    private void Update()
    {
    }
}