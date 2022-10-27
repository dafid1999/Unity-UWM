using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadanie_5 : MonoBehaviour
{
    public GameObject block;
    private int max = 10;

    // Start is called before the first frame update
   void Start()
    {
        List<Vector3> coords = new List<Vector3>();
        bool exist = false;
        for (int i=0; i<max; ++i)
        {
            int x = Random.Range(-50, 50);
            int z = Random.Range(-50, 50);
            foreach(Vector3 coord in coords)
            {
                if(coord == new Vector3(x,0.5f,z))
                {
                    exist = true;
                    break;
                }
                else
                {
                    exist = false;
                }
            }

            if(exist)
            {
                --i;
            }
            else{
                coords.Add(new Vector3(x,0.5f,z));
                Instantiate(block, new Vector3(x,0.5f,z), Quaternion.identity);
            }
        }       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
