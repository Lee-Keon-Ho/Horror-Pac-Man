﻿using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCtrl : MonoBehaviour
{
    public GameObject head;
    public GameObject mainCam;
    public Image CursorGaugeImage;
    private AudioSource audio_source;
    public AudioClip audioClip;
    private Vector3 forward;
    private int layMask = 1 << 8;
    private int stage = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        //ScreenCenter = new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2);
        audio_source = gameObject.AddComponent<AudioSource>();
        audio_source.clip = audioClip;
        audio_source.volume = 1.0f;
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        forward = mainCam.transform.TransformDirection(Vector3.forward) * 20;
        if (Physics.Raycast(mainCam.transform.position, forward, out hit,layMask))
        {
            Debug.Log(hit.transform.gameObject.tag);
        }
        
        Debug.DrawRay(mainCam.transform.position, forward, Color.red);
        if (Input.GetMouseButton(0))
        {
            MoveForward();
        }
        if (Input.GetMouseButtonDown(0))
        {
            audio_source.Play();
        }
        if (Input.GetMouseButtonUp(0))
        {
            audio_source.Stop();
        }
        
    }

    void MoveForward()
    {
        if (stage == 1)
        {
            //head.transform.position = new Vector3(this.transform.position.x, 12.0f, this.transform.position.z);
            if (mainCam.transform.rotation.x <= 0.3f && mainCam.transform.rotation.x >= -0.3f)
            {
                head.transform.Translate(mainCam.transform.forward * 0.2f);
            }
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {

    }
}