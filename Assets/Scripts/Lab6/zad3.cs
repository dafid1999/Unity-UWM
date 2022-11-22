using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zad3 : MonoBehaviour
{
    public Vector3[] waypoints;
    public float platformSpeed = 2f;

    private int currentWP = 0;

    private bool isRunningForward = true;
    private bool isRunningBack = false;

    void Update()
    {
        if (isRunningForward)
        {
            if(Vector3.Distance(transform.position, waypoints[currentWP]) < 0.01)
            {
                currentWP++;
            }

        }
        else if(isRunningBack)
        {
            if(Vector3.Distance(transform.position, waypoints[currentWP]) < 0.01)
            {
                currentWP--;
            }
        }

        if(currentWP == 0)
        {
            isRunningForward = true;
            isRunningBack = false;
        }
        else if(currentWP == waypoints.Length)
        {
            isRunningForward = false;
            isRunningBack = true;
            currentWP--;
        }

        transform.LookAt(waypoints[currentWP]);
        transform.Translate(0,0, platformSpeed * Time.deltaTime);
    }
       
}
