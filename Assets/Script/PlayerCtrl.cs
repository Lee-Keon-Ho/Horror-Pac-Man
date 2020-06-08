using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCtrl : MonoBehaviour
{
    public GameObject head;
    public GameObject mainCam;
    public GameObject rain;
    public Image CursorGaugeImage;
    private AudioSource audio_source;
    public AudioClip audioClip;
    private Vector3 forward;
    private int stage = 1;
    private float GaugeTimer;
    
    // Start is called before the first frame update
    void Start()
    {
        //ScreenCenter = new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2);
        audio_source = gameObject.AddComponent<AudioSource>();
        audio_source.clip = audioClip;
        audio_source.volume = 1.0f;
        audio_source.loop = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        rain.transform.position = new Vector3(head.transform.position.x,160.0f,head.transform.position.z);
        //head.GetComponent<Rigidbody>().velocity = new Vector3(0, -1, 0);
        RaycastHit hit;
        CursorGaugeImage.fillAmount = GaugeTimer;
        forward = mainCam.transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(mainCam.transform.position, forward, out hit,10.0f)&&hit.transform.gameObject.tag=="door")
        {
            GaugeTimer += 1.0f;

            if (GaugeTimer >= 1.0f && Input.GetMouseButtonDown(0))
            {
                Destroy(hit.transform.gameObject);
                stage++;
            }
        }
        else
        {
            GaugeTimer=0.0f;
        }

        if (head.transform.position.z >= 120.0f)
        {
            if (head.transform.position.y >= 104.0f)
            {
                rain.SetActive(true);
            }
            else
            {
                rain.SetActive(false);
            }
        }
        else
        {
            rain.SetActive(true);
        }

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
        //head.transform.position = new Vector3(this.transform.position.x, 12.0f, this.transform.position.z);
        if (mainCam.transform.rotation.x <= 0.3f && mainCam.transform.rotation.x >= -0.3f)
        {
            head.transform.Translate(mainCam.transform.forward * 0.2f);
        }    
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag != "door")
        {
            
        }
    }
}
