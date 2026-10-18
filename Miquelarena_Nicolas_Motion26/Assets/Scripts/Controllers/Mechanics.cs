using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.UI.Image;

public class Mechanics : MonoBehaviour
{
    public static Transform target;
    public Transform enemyTransform;
    public Transform playerPos; //player position and everything
    Vector3 spawnPos;
    public Vector2 pos;
  
    //Movement
    public Vector3 currentVelocity = Vector3.right;
    public float accelerationTime;
    public float deccelerationTime;
    public float decceleration;
    public float currentAcceleration;
    public float maxSpeed;

    //ProposalTest
    //check if warp is placed or not
    public bool warpReady = false;
    public GameObject warpStone;
    //Store the coordinates/velocity
    public Vector2 warpCoords;
    public Vector2 warpVelocity;

    //Spawn missile
    public GameObject missile;
    void Start()
    {
        currentAcceleration = maxSpeed / accelerationTime;
        decceleration = currentAcceleration / deccelerationTime;
        target = enemyTransform;
    }

    void Update()
    {
        spawnPos = transform.position;
        //returns the current target to the missile
        SendTransform();

        pos = playerPos.position;//for some reason this needs to be done as a seperate step or else it gets mad at me
        if (Keyboard.current.xKey.wasPressedThisFrame)
        {
            if (warpReady == false)
            {
                PlaceWarp(transform.position, currentVelocity);
                warpReady = true;
            }
            else
            {
                useWarp(warpCoords, warpVelocity);
                warpReady = false;
            }
        }
        if (Keyboard.current.cKey.wasPressedThisFrame)
        {
            SpawnMissile();
        }

        PlayerMovement();
    }
    void PlayerMovement()
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
            //currentVelocity += -1*direction.normalized * decceleration * Time.deltaTime;
            currentVelocity -= currentVelocity;
        }

        if (currentVelocity.magnitude > maxSpeed)
        {
            currentVelocity = currentVelocity.normalized * maxSpeed;
        }


        transform.position = transform.position + (currentVelocity * Time.deltaTime);
    }
    void PlaceWarp(Vector2 currentPos, Vector2 velocity)
    {
        warpCoords = currentPos;
        warpVelocity = velocity;
        //place an object that represents the warp stone
        Instantiate(warpStone, spawnPos, Quaternion.identity);
    }

    void useWarp(Vector2 destination, Vector2 exitSpeed)
    {
        transform.position = destination;
        currentVelocity = exitSpeed;
    }

    void WarpShield()
    {
        //Generate a ring around the player that prevents damage in some way
        //Needs a game object that behaves as the shield
        //Needs to orbit around the player
    }

    void SpawnMissile()
    {
        Instantiate(missile, spawnPos, Quaternion.identity);
    }

    public static Transform SendTransform()
    {
        Transform gift = target;
        return gift;
    }
}
