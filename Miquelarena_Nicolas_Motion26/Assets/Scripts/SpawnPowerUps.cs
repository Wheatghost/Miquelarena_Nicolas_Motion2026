using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.UI.Image;
public class SpawnPowerUps : MonoBehaviour
{
    public float radius;
    public int nmbr;
    public List<float> angles;
    public Vector2 origin;
    public GameObject powerUp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < nmbr; i++)
        {
            angles.Add((360 / nmbr)*(i + 1));
        }
        for (int i = 0; i < nmbr; i++)
        {
            Spawn(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    void Spawn(int i)
    {
        float angle = angles[i];
        Vector2 convert = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * radius;
        convert = convert + (Vector2)transform.position;
        powerUp = Instantiate(powerUp);
        powerUp.transform.position = convert;
        
    }
}
