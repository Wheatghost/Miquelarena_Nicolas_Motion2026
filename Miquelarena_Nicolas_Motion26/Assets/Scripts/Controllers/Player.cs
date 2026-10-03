using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.UI.Image;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;

    //Journal 2
    //Task 1
    public Transform playerPos; //player position and everything
    public Vector2 spawnOffset; //offset variable
    public Vector2 pos;
    public float numberOfBombs; //number of bombs
    //Task 2
    public Vector2 distance; //distance from the player to the corner
    //Task 3
    public float ratio = 1f;
    //Task 4
    public Vector2 maxRange; //radar range
    public Vector2 distanceToRock;

    //Week 3
    //Task 1
    public Vector3 currentVelocity = Vector3.right;
    public float accelerationTime;
    public float deccelerationTime;
    public float decceleration;
    public float currentAcceleration;
    public float maxSpeed;


    //Week 4
    //Player Radar
    //Use player position, draw a circle around them using radius, offset the circle using the player coordinates, 
    Vector2 origin = Vector2.zero;
    public List<int> radarDeg;
    public Vector2 radarOffset;
    public float radius;

    void Start()
    {
        currentAcceleration = maxSpeed / accelerationTime;
        decceleration = currentAcceleration / deccelerationTime;
        for (int i = 0; i < 8; i++)
        {
            radarDeg.Add(45 * i);
        }
    }

    void Update()
    {
        pos = playerPos.position;//for some reason this needs to be done as a seperate step or else it gets mad at me

        if (Keyboard.current.bKey.wasPressedThisFrame)
        {
            //Update the bomb offset postion by using Player position + Spawnoffset
            bombsTransform.position = (Vector2)pos + spawnOffset;
            SpawnBombAtOffset(bombsTransform, numberOfBombs);
            Debug.Log(playerPos.position);
        }

        if (Keyboard.current.vKey.wasPressedThisFrame)
        {
            bombsTransform.position = playerPos.position;
            //spawn a corner bomb
            SpawnCornerBomb(bombsTransform, distance);
        }

        if (Keyboard.current.wKey.wasPressedThisFrame)
        {
            Warp(enemyTransform, playerPos, ratio);//Warps player
        }

        PlayerMovement();
        for (int i = 0; i < radarDeg.Count; i++)
        {
            Radar(radarDeg[i]);
        }
                
    }

    void SpawnBombAtOffset(Transform bombOffset, float amount)
    {
        Vector2 offset = new Vector2(0, -0.2f);
        //instantiate bombprefab at vector3 inOffset
        for (int i = 0; i < amount; i++) {
            Instantiate(bombPrefab, bombOffset);
            bombOffset.position = (Vector2)bombOffset.position + offset;
        }
    }
    void SpawnCornerBomb(Transform position, Vector2 distance)
    {
        int corner = Random.Range(0, 4); //randomly select a corner, each time the method is called
        // randomly pick a corner, and spawn a bomb at a fixed distance from the player
        if (corner == 0)//top left (-x)
        {
            distance.x *= -1;
            position.position = (Vector2)position.position + distance;
            Instantiate(bombPrefab, position);
        }
        else if (corner == 1)//top right (no change)
        {
            position.position = (Vector2)position.position + distance;
            Instantiate(bombPrefab, position);
        }
        else if (corner == 2)//bottom right (-y)
        {
            distance.y *= -1;
            position.position = (Vector2)position.position + distance;
            Instantiate(bombPrefab, position);
        }
        else if (corner == 3)//bottom left (-x,-y)
        {
            distance *= -1;
            position.position = (Vector2)position.position + distance;
            Instantiate(bombPrefab, position);
        }
    }
    void Warp(Transform target, Transform pos, float ratio)
    {
        //Take the target's position, find the distance and direction, translate the player towards those coordinates 
        Vector2 warp = target.position - pos.position;
        if (ratio < 0)
        {
            ratio = 0;
        }
        else if (ratio > 1)
        {
            ratio = 1;
        }
        if (ratio != 0)
        {
            pos.position = ((Vector2)pos.position + warp) * ratio;
        }
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
        //Cannot figure this out

        if (currentVelocity.magnitude > maxSpeed)
        {
            currentVelocity = currentVelocity.normalized * maxSpeed;
        }
        

        transform.position = transform.position + (currentVelocity * Time.deltaTime);
    }

    void Radar(int i)
    {
        Vector2 currentPos = new Vector2(Mathf.Cos(i), Mathf.Sin(i))*radius;
        //currentPos = currentPos + (Vector2)transform.position;
        Debug.DrawLine(origin, currentPos , Color.green);
        origin = currentPos;
    }
}
