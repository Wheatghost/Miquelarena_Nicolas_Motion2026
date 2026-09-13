using UnityEngine;

public class TestScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector2 originPosition = new Vector2(0, 0);
        Vector2 currentPosition = new Vector2(3, -2);

        Debug.DrawLine(originPosition, currentPosition, Color.gray, 15f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
