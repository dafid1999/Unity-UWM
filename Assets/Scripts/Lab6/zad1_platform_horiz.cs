using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zad1_platform_horiz : MonoBehaviour
{
    public float elevatorSpeed = 2f;
    private bool isRunning = false;
    public float distance = 6.6f;
    private bool isRunningRight = true;
    private bool isRunningLeft = false;
    private float firstPosition;
    private float lastPosition;
    private Transform oldParent;

    void Start()
    {
        lastPosition = transform.position.z + distance;
        firstPosition = transform.position.z;
    }

    void Update()
    {
        if (isRunningRight && transform.position.z >= lastPosition)
        {
            isRunning = false;
        }
        else if (isRunningLeft && transform.position.z <= firstPosition)
        {
            isRunning = false;
        }

        if (isRunning)
        {
            Vector3 move = -transform.forward * elevatorSpeed * Time.deltaTime;
            transform.Translate(move);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player wszedł na windę.");
            // zapamiętujemy "starego rodzica"
            oldParent = other.gameObject.transform.parent;
            // skrypt przypisany do windy, ale other może być innym obiektem
            other.gameObject.transform.parent = transform;
            if (transform.position.z >= lastPosition)
            {
                isRunningRight = true;
                isRunningLeft = false;
                elevatorSpeed = -elevatorSpeed;
            }
            else if (transform.position.z <= firstPosition)
            {
                isRunningRight = false;
                isRunningLeft = true;
                elevatorSpeed = Mathf.Abs(elevatorSpeed);
            }
            isRunning = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player zszedł z windy.");
            // other.gameObject.transform.parent = oldParent;
        }
    }
}
