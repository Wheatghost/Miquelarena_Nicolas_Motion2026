using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class Stars : MonoBehaviour
{
    //Journal 3
    //Task 3
    public List<Transform> starTransforms;
    public float drawingTime;
    public float timer;
    int i = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (i +1 >= starTransforms.Count)
        {
            i = 0;
        }
        Vector3 startPoint = starTransforms[i].position;
        Vector3 endPoint = starTransforms[i+1].position;
        if (timer > 1)
        {
            timer = 0;
            DrawConstellation(startPoint, endPoint);
            if (i + 1 < starTransforms.Count)
            {
                i++;
            }
        }
        timer += Time.deltaTime;
    }

    public void DrawConstellation(Vector3 startPoint, Vector3 endPoint)
    {
        int i = 0;
        if (i < starTransforms.Count)
        {
            Debug.DrawLine(startPoint, endPoint, Color.white, 1);
        }  
        
    }
}

