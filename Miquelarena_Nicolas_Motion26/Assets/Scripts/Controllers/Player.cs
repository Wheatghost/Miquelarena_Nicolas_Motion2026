using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;

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

        //get the player position relative to the asteroid field
        //distanceToRock = asteroidTransforms.position - playerPos.position;
        for (int i = 0; i < 20; i++)
        {
            distanceToRock = asteroidTransforms[i].position - playerPos.position;
            //check if the player is within range of an asteroid
            if (distanceToRock.x < maxRange.x || distanceToRock.y < maxRange.y)
            {
                Ping(asteroidTransforms[i], playerPos);
            }
        }
    }

    void SpawnBombAtOffset(Transform bombOffset, float amount)
    {
        Vector2 offset = new Vector2 (0, -0.2f);
        //instantiate bombprefab at vector3 inOffset
        for (int i = 0; i<amount; i++) {
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
    
    void Ping(Transform asteroidPos, Transform shipPos)//draws a normalized green line towards the nearest asteroid
    {
        Vector2 direction = asteroidPos.position - shipPos.position;
        Vector2 normalizedDirection = direction.normalized*2.5f;
        Debug.DrawLine(shipPos.position, normalizedDirection, Color.green, 0.2f);
    }
}
