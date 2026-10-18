using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.UI.Image;
public class Turret : MonoBehaviour
{
    //Movement
    public Vector3 currentVelocity = Vector3.zero;
    public float accelerationTime = 3;
    public float currentAcceleration = 0;
    public float maxSpeed = 5;

    public Transform targetTransform;
    bool turnRight = false;
    public float rotationSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentAcceleration = maxSpeed / accelerationTime;
    }

    // Update is called once per frame
    void Update()
    {
        targetTransform = Mechanics.SendTransform();

        Vector3 directionToTarget = targetTransform.position - transform.position;     

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
        movement();
        
    }
    void movement()
    {
        Vector3 direction = Vector3.zero;

        direction += transform.up;

        currentVelocity += direction.normalized * currentAcceleration * Time.deltaTime;

        if (currentVelocity.magnitude > maxSpeed)
        {
            currentVelocity = currentVelocity.normalized * maxSpeed;
        }

        transform.position = transform.position + (currentVelocity * Time.deltaTime);
    }
}
