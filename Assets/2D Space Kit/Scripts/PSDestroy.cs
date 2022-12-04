using UnityEngine;

public class PSDestroy : MonoBehaviour
{
    // Use this for initialization
    private void Start()
    {
        Destroy(gameObject, GetComponent<ParticleSystem>().main.duration);
    }

    // Update is called once per frame
    private void Update()
    {
    }
}