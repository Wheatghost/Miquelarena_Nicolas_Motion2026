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
    public float deccelerationTime;
    public float decceleration;
    public float currentAcceleration;
    public float maxSpeed;

    void Start()
    {
        currentAcceleration = maxSpeed / accelerationTime;
        decceleration = currentAcceleration / deccelerationTime;
    }

    void Update()
    {
        float timer = 0;
        if (timer > 1)
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

        if (Keyboard.current.downArrowKey.isPressed == false && Keyboard.current.upArrowKey.isPressed == false && Keyboard.current.rightArrowKey.isPressed == false && Keyboard.current.leftArrowKey.isPressed == false && currentVelocity.magnitude != 0)
        {
            Debug.Log("Deccelerating");
            currentVelocity += -1 * direction.normalized * decceleration * Time.deltaTime;
        }
        //Still Cannot figure this out

        if (currentVelocity.magnitude > maxSpeed)
        {
            currentVelocity = currentVelocity.normalized * maxSpeed;
        }


        transform.position = transform.position + (currentVelocity * Time.deltaTime);
    }
}