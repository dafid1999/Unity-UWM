using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadanie_3 : MonoBehaviour
{
    public float speed;
    private bool Right = false;
    private bool Down = false;
    private bool Left = false;
    private bool Up = false;
    
    // Start is called before the first frame update
    void Start()
    {

    }
    
    // Update is called once per frame
    void Update()
    {
        if(transform.position.x == 0 && transform.position.z == 0)
        {
            Right = true;
            Down = false;
            Left = false;
            Up = false;
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else if(transform.position.x == 10 && transform.position.z == 0)
        {
            Right = false;
            Down = true;
            Left = false;
            Up = false;
            transform.Rotate(0.0f, 90.0f, 0.0f, Space.World);
        }        
        else if(transform.position.z == -10 && transform.position.x == 10)
        {
            Right = false;
            Down = false;
            Left = true;
            Up = false;
            transform.Rotate(0.0f, 90.0f, 0.0f, Space.World);
        }
        else if(transform.position.z == -10 && transform.position.x == 0)
        {
            Right = false;
            Down = false;
            Left = false;
            Up = true;
            transform.Rotate(0.0f, 90.0f, 0.0f, Space.World);
        }

        var step =  speed * Time.deltaTime;
        
        if(Right)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(10f, 0.5f, 0.0f), step);
        }
        else if(Down)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(10f, 0.5f, -10.0f), step);
        }
        else if(Left)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(0f, 0.5f, -10.0f), step);
        }
        else if(Up)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(0f, 0.5f, 0.0f), step);
        }
    }
}