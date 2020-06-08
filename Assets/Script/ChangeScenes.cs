using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{
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
        SceneManager.LoadScene(4, LoadSceneMode.Single);
    }
    public void ChangeNormal()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
    public void ChangeEasy()
    {
        SceneManager.LoadScene(3, LoadSceneMode.Single);
    }
}
