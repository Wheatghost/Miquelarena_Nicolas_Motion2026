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

    public Transform playerPos; //player position and everything

    public Vector2 spawnOffset; //offset variable
    public Vector2 pos;

    public float numberOfBombs; //number of bombs

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

        if (Keyboard.current.wKey.wasPressedThisFrame)
        {
            Warp(enemyTransform, playerPos);
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

    void Warp(Transform target, Transform pos)
    {
        //Take the target's position, find the distance and direction, translate the player towards those coordinates 
    }
}
