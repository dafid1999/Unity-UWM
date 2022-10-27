using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadanie_6 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Smooth towards the height of the target

    public Transform target;
    public float minimum = -10.0F;
    public float maximum =  10.0F;

    float smoothTime = 0.1f;
    float yVelocity = 1.0f;

    static float t = 0.0f;

    void Update()
    {
        float newPositionY = Mathf.SmoothDamp(transform.position.y, target.position.y, ref yVelocity, smoothTime);
        float newPositionX = Mathf.SmoothDamp(transform.position.x, target.position.x, ref yVelocity, smoothTime);
        float newPositionZ = Mathf.SmoothDamp(transform.position.z, target.position.z, ref yVelocity, smoothTime);
        // transform.position = new Vector3(newPositionX, newPositionY, newPositionZ);
        transform.position = new Vector3(Mathf.Lerp(minimum, maximum, t), 0, 0);
        t += 0.5f * Time.deltaTime;
        if (t > 1.0f)
        {
            float temp = maximum;
            maximum = minimum;
            minimum = temp;
            t = 0.0f;
        }
    }
}
