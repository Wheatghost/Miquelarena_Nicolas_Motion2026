using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System;

public class Zoo : MonoBehaviour
{
    public List<string> animals;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animals.Add("Penguin");
        animals.Add("Triceratops");
        animals.Add("Sharks");

        animals.Remove("Triceratops");

        //Tiger [0]
        //Penguin [1]
        //Sharks [2]
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
