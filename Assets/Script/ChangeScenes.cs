using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{
    public static string s;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeHard()
    {
        s = "empt";
        SceneManager.LoadScene("Loding", LoadSceneMode.Single);
    }
    public void ChangeNormal()
    {
        s = "Normal";
        SceneManager.LoadScene("Loding", LoadSceneMode.Single);
    }
    public void ChangeEasy()
    {
        s = "Easy";
        SceneManager.LoadScene("Loding", LoadSceneMode.Single);
    }
}
