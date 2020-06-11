using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour
{
    public GameObject item_point;
    public GameObject item_;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (item_.activeSelf == false)
        {
            item_point.SetActive(false);
        }
    }
}
