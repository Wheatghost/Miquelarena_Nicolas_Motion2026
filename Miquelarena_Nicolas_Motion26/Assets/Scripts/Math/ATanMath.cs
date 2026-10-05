using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class ATanMath : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 facingDirection = transform.up;
        float facingAngle = ATanMath.VectorToAngle(facingDirection);
       // Debug.Log(facingAngle);

    }
    //convert from a vector to an angle based on the x-axis
    public static float VectorToAngle(Vector3 inVector)
    {
        float angle = Mathf.Atan2(inVector.y, inVector.x) * Mathf.Rad2Deg;

        return angle;
    }
    public static float VectorDot(Vector3 a , Vector3 b)
    {
        float dotProduct = a.x * b.x + a.y * b.y;
        return dotProduct;
    }
}
