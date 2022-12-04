using System;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public int interactions;
    public GameObject prefab;
    public int radius;
    public double teta;
    public int x;
    public int y;

    private Vector2 CalculateRotation(int x, int y, int angle)
    {
        return new Vector2((float)(x * Math.Cos(angle) - y * Math.Sin(angle)), (float)(x * Math.Sin(angle) + y * Math.Cos(angle)));
    }

    private Vector2 CalculateRotation2(Vector2 position, double teta, double r)
    {
        return new((float)(r * Math.Cos(teta) + position.x), (float)(r * Math.Sin(teta) + position.y));
    }

    private Vector2 CalculateRotation3(Vector2 v, double teta, double r)
    {
        //return new((float)(Math.Cos(teta) * v.x  - Math.Sin(teta) * v.y ), (float)(Math.Sin(teta) * v.x + Math.Cos(teta) * y));
        return new((float)(v.x + r * Math.Cos(teta * Math.PI / 180)), (float)(v.y + r * Math.Sin(teta * Math.PI / 180)));
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(new(x, y, 0), radius);

        var newpos = CalculateRotation3(new(x, y), teta, radius);
        //Instantiate(prefab, new Vector3(newpos.x, newpos.y, 0), Quaternion.identity);
        Gizmos.DrawWireCube(newpos, new(1, 1, 1));
    }

    // Start is called before the first frame update
    private void Start()
    {
        var original = Instantiate(prefab, new Vector3(x, y, 0), Quaternion.identity);
        var cubeRenderer = original.GetComponent<Renderer>();

        // Call SetColor using the shader property name "_Color" and setting the color to red
        cubeRenderer.material.SetColor("_Color", Color.green);

        /*for (int i =0; i < interactions; i++)
        {
            var newpos = CalculateRotation2(new(x, y), i, 10);
            Instantiate(prefab, new Vector3(newpos.x, newpos.y, 0), Quaternion.identity);
        }*/

        var newpos = CalculateRotation(x, y, 10);
        Instantiate(prefab, new Vector3(newpos.x, newpos.y, 0), Quaternion.identity);
    }

    // Update is called once per frame
    private void Update()
    {
    }
}