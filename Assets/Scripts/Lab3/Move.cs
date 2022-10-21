using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed=1;
    private float i=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(i<10){
            transform.Translate(speed * Time.deltaTime, 0,0);
            i++;
        }
        else if(i==10){
            transform.Translate(speed * Time.deltaTime *-1, 0,0);
            i--;            
        }

    }
}
