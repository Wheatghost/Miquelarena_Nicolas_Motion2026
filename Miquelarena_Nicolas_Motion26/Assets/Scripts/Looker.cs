using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Looker : MonoBehaviour
{
    public List<Transform> target;
    int i = 0;
    float facingAngle;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //get the angle of difference from the looker to the target[i] get the angle using the 2 vector positions
        //using euler angles, change the angle of the looker by that difference
        //press space to move down the list and repeat
        facingAngle = ATanMath.VectorToAngle(target[i].position-transform.position);
        transform.eulerAngles = new Vector3(0, 0, facingAngle - 90f);
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            i++;
            if (i == target.Count)
            {
                i = 0;
            }
        }
    }
}