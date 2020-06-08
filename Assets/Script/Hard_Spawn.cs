using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hard_Spawn : MonoBehaviour
{
    public GameObject[] spawnpoint1 = new GameObject[12];
    public GameObject[] spawnpoint2 = new GameObject[14];
    public GameObject[] spawnpoint3 = new GameObject[16];
    public GameObject item;

    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(item, spawnpoint1[Random.Range(0, 11)].transform.position, Quaternion.identity);
        Instantiate(item, spawnpoint2[Random.Range(0, 13)].transform.position, Quaternion.identity);
        Instantiate(item, spawnpoint3[Random.Range(0, 15)].transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
