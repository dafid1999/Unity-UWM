using Random = UnityEngine.Random;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class zadanie_1 : MonoBehaviour
{
    List<Vector3> positions = new List<Vector3>();
    public float delay = 3.0f;
    public int amount = 10;
    int objectCounter = 0;
    Collider m_Collider;
    Vector3 m_Min, m_Max;
    private Material blue;
    // obiekt do generowania
    public GameObject block;

    void Start()
    {
        //Fetch the Collider from the GameObject
        m_Collider = GetComponent<Collider>();
        //Fetch the minimum and maximum bounds of the Collider volume
        m_Min = m_Collider.bounds.min;
        m_Max = m_Collider.bounds.max;

        Debug.Log("Collider bound Minimum x : " + (int)m_Min.x);
        Debug.Log("Collider bound Maximum x : " + (int)m_Max.x);
        Debug.Log("Collider bound Minimum z : " + (int)m_Min.z);
        Debug.Log("Collider bound Maximum z : " + (int)m_Max.z);

        // w momecie uruchomienia generuje 10 kostek w losowych miejscach
        List<int> pozycje_x = new List<int>(Enumerable.Range((int)m_Min.x+1, (int)m_Max.x-(int)m_Min.x-1).OrderBy(x => Guid.NewGuid()).Take(amount));
        List<int> pozycje_z = new List<int>(Enumerable.Range((int)m_Min.z+1, (int)m_Max.z-(int)m_Min.z-1).OrderBy(x => Guid.NewGuid()).Take(amount));

        for(int i=0; i<amount; i++)
        {
            this.positions.Add(new Vector3(pozycje_x[i], 0.5f, pozycje_z[i]));
        }
        foreach(Vector3 elem in positions){
            Debug.Log(elem);
        }
        // uruchamiamy coroutine
        StartCoroutine(GenerujObiekt());
    }

    void Update()
    {
        
    }

    IEnumerator GenerujObiekt()
    {
        Material[] mats = Resources.LoadAll("Materials/Lab4_zad1/", typeof(Material)).Cast<Material>().ToArray();
        Debug.Log("wywołano coroutine");
        foreach(Vector3 pos in positions)
        {
            var rend = block.GetComponent<Renderer>();
            var los = Random.Range(0,5);
            rend.material = mats[los];
            Instantiate(this.block, this.positions.ElementAt(this.objectCounter++), Quaternion.identity);
            yield return new WaitForSeconds(this.delay);
        }
        // zatrzymujemy coroutine
        StopCoroutine(GenerujObiekt());
    }
}