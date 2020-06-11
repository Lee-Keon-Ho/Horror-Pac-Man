using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject[] spawnpoint = new GameObject[15];
    public int max = 0;
    public int arr_max = 0;
    private int random = 0; 
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < max;)
        {
            random = UnityEngine.Random.Range(0, arr_max);
            if (spawnpoint[random].activeSelf == true)
            {

            }
            else
            {
                spawnpoint[random].SetActive(true);
                i++;
            }   
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
