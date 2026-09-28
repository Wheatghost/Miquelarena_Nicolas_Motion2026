using UnityEngine;

public class AngleTest : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float fortyFiveAngle = 45f;

        float fFDinR = fortyFiveAngle * Mathf.Deg2Rad;

        float tPR = 2 * Mathf.PI;

        float tPRinD = tPR * Mathf.Rad2Deg;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
