using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Normal_PlayerCtrl : MonoBehaviour
{
    public GameObject head;
    public GameObject mainCam;
    private AudioSource audio_source;
    public AudioClip audioClip;
    private int stage = 1;
    public float s = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        audio_source = gameObject.AddComponent<AudioSource>();
        audio_source.clip = audioClip;
        audio_source.volume = 1.0f;
        audio_source.loop = true;
    }

    // Update is called once per frame
    void Update()
    {
        head.gameObject.transform.position = new Vector3(this.transform.position.x, 0.5f, this.transform.position.z);

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
                head.transform.Translate(mainCam.transform.forward*s);
            }
        }

    }
}
