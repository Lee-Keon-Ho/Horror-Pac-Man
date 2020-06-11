using GoogleVR.VideoDemo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Easy_monster : MonoBehaviour
{
    public GameObject anim;
    // Start is called before the first frame update
    void Start()
    {
        anim.GetComponent<Animator>();
        anim.GetComponent<Animator>().SetBool("isRun", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
