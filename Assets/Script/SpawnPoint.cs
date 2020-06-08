using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject[] spawnpoint = new GameObject[15];
    public GameObject item;
    private int count = 0;
    private int random = 0; 
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 15; i++)
        {
            random = UnityEngine.Random.Range(0, 2);
            if (random == 0)
            {
                count++;
                Instantiate(item, spawnpoint[i].transform.position, Quaternion.identity);
            }
            if (count > 4)
            {
                break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
