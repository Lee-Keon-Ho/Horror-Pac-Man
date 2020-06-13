using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class empt_PlayerCtrl : MonoBehaviour
{
    public GameObject head;
    public GameObject mainCam;
    public GameObject rain;
    public GameObject clear;
    private float GaugeTimer;
    public Image CursorGaugeImage;
    private AudioSource audio_source;
    public AudioClip audioClip;
    private Vector3 forward;
    public GameObject end_Game;
    int stage = 0;
    RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        audio_source = gameObject.AddComponent<AudioSource>();
        audio_source.clip = audioClip;
        audio_source.volume = 0.3f;
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
            rain.transform.position = new Vector3(head.transform.position.x, 160.0f, head.transform.position.z);

            head.GetComponent<Rigidbody>().velocity = Vector3.zero;
            CursorGaugeImage.fillAmount = GaugeTimer;
            forward = mainCam.transform.TransformDirection(Vector3.forward);

            if (Physics.Raycast(mainCam.transform.position, forward, out hit, 10.0f) && hit.transform.gameObject.tag == "door")
            {
                GaugeTimer += 1.0f;

                if (GaugeTimer >= 1.0f && Input.GetMouseButtonDown(0))
                {
                    hit.transform.gameObject.SetActive(false);
                    stage++;
                    //Destroy(hit.transform.gameObject);
                }
            }
            else
            {
                GaugeTimer = 0.0f;
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
        if (mainCam.transform.rotation.x <= 0.5f && mainCam.transform.rotation.x >= -0.5f)
        {
            head.transform.Translate(mainCam.transform.forward * 0.2f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Monster")
        {
            end_Game.SetActive(true);
            //SceneManager.LoadScene("End_Game", LoadSceneMode.Single);
        }
    }
}
