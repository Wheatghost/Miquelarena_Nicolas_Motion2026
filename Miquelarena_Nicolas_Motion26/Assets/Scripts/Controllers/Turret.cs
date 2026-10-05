using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.UI.Image;
public class Turret : MonoBehaviour
{
    public Transform targetTransform;
    bool turnRight = false;
    public float rotationSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(transform.position, targetTransform.position, Color.red);
        Vector3 directionToTarget = targetTransform.position - transform.position;
        Debug.Log(turnRight);
     

        if (ATanMath.VectorDot(directionToTarget, transform.right) > 0)
        {
            turnRight = true;
            transform.eulerAngles -= Vector3.forward*rotationSpeed*Time.deltaTime;
        }
        else
        {
            transform.eulerAngles += Vector3.forward * rotationSpeed * Time.deltaTime;
            turnRight= false;
        }
    }
}
