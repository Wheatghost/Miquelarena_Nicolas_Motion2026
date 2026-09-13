using UnityEngine;
using UnityEngine.InputSystem;

public class VectorAddition : MonoBehaviour
{
    public Transform rTransform;
    public Transform bTransform;
    Vector2 origin = new Vector2(0, 0);


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 rPlusB = (rTransform.position + bTransform.position);

        if (Keyboard.current.rKey.isPressed)
        {
            Debug.DrawLine(origin, rTransform.position, Color.red);
        }
        if (Keyboard.current.bKey.isPressed)
        {
            Debug.DrawLine(origin, bTransform.position, Color.darkBlue);
        }
        if (Keyboard.current.bKey.isPressed && Keyboard.current.rKey.isPressed)
        {
            Debug.DrawLine(origin, rPlusB, Color.magenta);
        }

        float sizeOfRpB = Mathf.Sqrt(rPlusB.x * rPlusB.x + rPlusB.y * rPlusB.y);
        Debug.Log(sizeOfRpB);

        Vector2 fromRToB = bTransform.position - rTransform.position;
    }
}
