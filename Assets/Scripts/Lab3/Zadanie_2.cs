using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadanie_2 : MonoBehaviour
{
    public float speed;
    private Transform target;
    private bool Forward = false;
    private bool Back = false;
    
    // Start is called before the first frame update
    void Start()
    {
    }
    
    // Update is called once per frame
    void Update()
    {
        if(transform.position.x == 0)
        {
            Forward = true;
            Back = false;
        }
        else if(transform.position.x == 10)
        {
            Forward = false;
            Back = true;
        }

        var step =  speed * Time.deltaTime;
        
        if(Forward)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(10f, 0.5f, 0.0f), step);
        }
        else if(Back)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(0f, 0.5f, 0.0f), step);
        }
        
    }
}
