using UnityEngine;
using UnityEngine.InputSystem;

public class SquareSpawner : MonoBehaviour
{
    public Transform pos;// position of the empty
    public Transform corner1; //Corners that draw the box around the mouse
    public Transform corner2; 
    public Transform corner3;
    public Transform corner4;
    public float scalar = 1f;

    Vector2 corner1Origin = new Vector2(-1, 1);
    Vector2 corner2Origin = new Vector2(1, 1);
    Vector2 corner3Origin = new Vector2(1, -1);
    Vector2 corner4Origin = new Vector2(-1, -1);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        //mouse scrolling
        Vector2 scrollValue = Mouse.current.scroll.ReadValue();

        //Mouse Tracking
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()); //tracking the mouse
        transform.position = mousePos;

        //Tracking the corners of the box to the mouse
        corner1.position = ((Vector2)transform.position - corner1Origin)*scalar;
        corner2.position = ((Vector2)transform.position -corner2Origin)*scalar;
        corner3.position = ((Vector2)transform.position -corner3Origin)*scalar;
        corner4.position = ((Vector2)transform.position -corner4Origin)*scalar;

        //Drawing the box around the mouse
        Debug.DrawLine(corner1.position, corner2.position, Color.white);
        Debug.DrawLine(corner2.position, corner3.position, Color.white);
        Debug.DrawLine(corner3.position, corner4.position, Color.white);
        Debug.DrawLine(corner4.position, corner1.position, Color.white);

        //Drawing the box when the mouse is clicked
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Debug.DrawLine(corner1.position, corner2.position, Color.white, 1000000);
            Debug.DrawLine(corner2.position, corner3.position, Color.white, 1000000);
            Debug.DrawLine(corner3.position, corner4.position, Color.white, 1000000);
            Debug.DrawLine(corner4.position, corner1.position, Color.white, 1000000);
        }
        
        //increase or decrease the size of the box
        if (scrollValue.y > 0)
        {
            scalar+= 0.1f;
            Debug.Log("scrolling");
        }
        else if (scrollValue.y < 0)
        {
            scalar-= 0.1f;
        }
    }
}
