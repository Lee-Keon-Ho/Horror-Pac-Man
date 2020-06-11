using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Mini_Map_Camera : MonoBehaviour
{
    public GameObject camera;
    public GameObject light;
    public GameObject map;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (true/*camera.transform.rotation.eulerAngles.x > 80.0f && camera.transform.rotation.eulerAngles.x < 90.0f*/)
        {
            light.SetActive(true);
            map.SetActive(true);
        }
        else
        {
            light.SetActive(false);
            map.SetActive(false);
        }
    }
}
