using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;
    public Vector2 spawnOffset; //offset variable
    public Transform playerPos; //player position and everything

    void Update()
    {
        
        if (Keyboard.current.bKey.wasPressedThisFrame)
        {
            SpawnBombAtOffset(spawnOffset);
            Debug.Log(spawnOffset);
        }

        if (Keyboard.current.wKey.wasPressedThisFrame)
        {
            Warp(enemyTransform, playerPos);
        }

    }

    void SpawnBombAtOffset(Vector3 inOffset)
    {
        //instantiate bombprefab at vector3 inOffset
    }

    void Warp(Transform target, Transform pos)
    {
        //Take the target's position, find the distance and direction, translate the player towards those coordinates 
    }
}
