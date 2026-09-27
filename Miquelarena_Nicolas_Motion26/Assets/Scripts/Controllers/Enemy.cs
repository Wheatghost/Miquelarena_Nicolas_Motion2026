using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.InputSystem;

public class Enemy : MonoBehaviour
{
    //Week 3
    //Task 1
    public Vector3 currentVelocity = Vector3.right;
    public float accelerationTime;
    public float currentAcceleration;
    public float maxSpeed;
    float timer = 0;

    void Start()
    {
        currentAcceleration = maxSpeed / accelerationTime;
        
    }

    void Update()
    {
        
        if (timer > 0.1)
        {
            EnemyMovement();
            timer = 0;
        }
        timer += Time.deltaTime;
        
    }

    void EnemyMovement()
    {
        Vector3 direction = Vector3.zero;

        if (Keyboard.current.leftArrowKey.isPressed)
        {
            direction += Vector3.left;
        }
        if (Keyboard.current.rightArrowKey.isPressed)
        {
            direction += Vector3.right;
        }
        if (Keyboard.current.upArrowKey.isPressed)
        {
            direction += Vector3.up;
        }
        if (Keyboard.current.downArrowKey.isPressed)
        {
            direction += Vector3.down;
        }

        currentVelocity += direction.normalized * currentAcceleration * Time.deltaTime;

        if (currentVelocity.magnitude > maxSpeed)
        {
            currentVelocity = currentVelocity.normalized * maxSpeed;
        }
        transform.position = transform.position + (currentVelocity * Time.deltaTime);
    }

}
