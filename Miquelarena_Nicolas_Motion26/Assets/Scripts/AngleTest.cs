using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AngleTest : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public List<float> angles;
    public Vector2 origin;
    public int i = 0;
    public List<int> r;
    float timer = 0;
    void Start()
    {
        float fortyFiveAngle = 45f;
        float fFDinR = fortyFiveAngle * Mathf.Deg2Rad;


        float tPR = 2 * Mathf.PI;
        float tPRinD = tPR * Mathf.Rad2Deg;


        float currentAngle = 90f;
        Mathf.Cos(currentAngle * Mathf.Deg2Rad); 
        Mathf.Sin(currentAngle * Mathf.Deg2Rad);

        for (int i = 0; i < 10; i++)
        {
            angles.Add(Random.Range(0, 361));
            r.Add(Random.Range(1, 11));
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= 1)
        {
            DrawNext(i, angles[i], r[i]);
            i++;
            if (i >= 10)
            {
                i = 0;
            }
            timer = 0;
        }
        timer += Time.deltaTime;
    }

    void DrawNext(int i, float angle, int radius)
    {
        Vector2 convert = new Vector2 (Mathf.Cos(angle), Mathf.Sin(angle))*radius;
        Debug.DrawLine(origin, convert, Color.white, 9);
        origin = convert;
    }
}
