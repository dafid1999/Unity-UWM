using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zad2 : MonoBehaviour
{
    public float doorSpeed = 2f;
    private bool isRunning = false;
    public float distance = 3.0f;
    private bool isRunningRight = false;
    private bool isRunningLeft = false;
    private float firstPosition;
    private float lastPosition;

    void Start()
    {
        lastPosition = transform.position.z + distance;
        firstPosition = transform.position.z;
    }

    void Update()
    {
        if (isRunningRight && transform.position.z <= firstPosition)
        {
            isRunning = false;
        }
        else if (isRunningLeft && transform.position.z >= lastPosition)
        {
            isRunning = false;
        }

        if (isRunning)
        {
            Vector3 move = transform.forward * doorSpeed * Time.deltaTime;
            transform.Translate(move);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Otwieram drzwi"); 
            if(isRunningLeft == false)
            {
                isRunningRight = false;
                isRunningLeft = true;
                doorSpeed = Mathf.Abs(doorSpeed);
                isRunning = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Zamykam drzwi");
            if(isRunningRight == false)
            {
                isRunningRight = true;
                isRunningLeft = false;
                doorSpeed = -doorSpeed;
                isRunning = true;
            }

        }
    }
}
