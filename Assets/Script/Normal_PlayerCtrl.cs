using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Normal_PlayerCtrl : MonoBehaviour
{
    public GameObject head;
    public GameObject mainCam;
    public GameObject[] monster = new GameObject[2];
    public GameObject clear;
    private AudioSource audio_source;
    public AudioClip audioClip;
    private Vector3 forward;
    private float GaugeTimer;
    private int stage = 0;
    public Image CursorGaugeImage;

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
        if (stage >= 5)
        {
            audio_source.Stop();
            clear.SetActive(true);
            Time.timeScale = 0.0f;
            if (Input.GetMouseButtonDown(0))
            {
                Time.timeScale = 1.0f;
                SceneManager.LoadScene("Main_loding", LoadSceneMode.Single);
            }
        }
        else
        {
            head.GetComponent<Rigidbody>().velocity = Vector3.zero;
            RaycastHit hit;
            CursorGaugeImage.fillAmount = GaugeTimer;
            forward = mainCam.transform.TransformDirection(Vector3.forward);
            head.gameObject.transform.position = new Vector3(this.transform.position.x, 2.0f, this.transform.position.z);

            if (Physics.Raycast(mainCam.transform.position, forward, out hit, 1.0f) && hit.transform.gameObject.tag == "door")
            {
                GaugeTimer += 1.0f;

                if (GaugeTimer >= 1.0f && Input.GetMouseButtonDown(0))
                {
                    hit.transform.gameObject.SetActive(false);
                    stage++;
                }
            }
            else
            {
                GaugeTimer = 0.0f;
            }

            if (stage >= 1)
            {
                monster[0].SetActive(true);
                monster[1].SetActive(true);
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
        
    }

    void MoveForward()
    {
        if (mainCam.transform.rotation.x <= 0.3f && mainCam.transform.rotation.x >= -0.3f)
        {
            head.transform.Translate(mainCam.transform.forward * 0.05f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Monster")
        {
            SceneManager.LoadScene("End_Game", LoadSceneMode.Single);
        }
    }
}
