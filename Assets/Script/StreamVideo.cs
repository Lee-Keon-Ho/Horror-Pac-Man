using GoogleVR.VideoDemo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class StreamVideo : MonoBehaviour
{
    public static string s;
    public RawImage rawImage;
    public VideoPlayer[] videoPlayer_arr=new VideoPlayer[4];
    public AudioSource[] audioSources_arr = new AudioSource[3];
    private VideoPlayer videoPlayer;
    private float item = 0;
    int i;

    // Start is called before the first frame update
    void Start()
    {
        i = Random.Range(0, 4);
        Debug.Log(i);
        if (i == 0)
        {
            videoPlayer = videoPlayer_arr[0];
        }else if (i == 1)
        {
            videoPlayer = videoPlayer_arr[1];
        }else if (i == 2)
        {
            videoPlayer = videoPlayer_arr[2];
        }else if (i == 3)
        {
            videoPlayer = videoPlayer_arr[3];
        }
        
        StartCoroutine(PlayVideo());
    }

    IEnumerator PlayVideo()
    {
        videoPlayer.Prepare();
        WaitForSeconds waitForSeconds = new WaitForSeconds(1);
        while (!videoPlayer.isPrepared)
        {
            yield return waitForSeconds;
            break;
        }
        rawImage.texture = videoPlayer.texture;
        audioSources_arr[0].Play();
        audioSources_arr[1].Play();
        audioSources_arr[2].Play();
        videoPlayer.Play();
        rawImage.color = new Color(255, 255, 255);
    }

    // Update is called once per frame
    void Update()
    {
        item += Time.deltaTime;
        if (item >= 5.0f)
        {
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("Main_loding", LoadSceneMode.Single);
            }
        }
    }
}
