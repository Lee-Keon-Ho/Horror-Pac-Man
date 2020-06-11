using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;

public class main_loding : MonoBehaviour
{
    [SerializeField]
    Image loadingBar;
    // Start is called before the first frame update
    void Start()
    {
        loadingBar.fillAmount = 0;
        StartCoroutine(LoadAsyncScene());
    }
    public static void LoadScene(string sceneName)
    {
        SceneManager.LoadScene("Main_loding");
    }

    IEnumerator LoadAsyncScene()
    {
        yield return null;
        AsyncOperation asyncScene = SceneManager.LoadSceneAsync("Main");
        asyncScene.allowSceneActivation = false;
        float timec = 0;
        while (!asyncScene.isDone)
        {
            yield return null;
            timec += Time.deltaTime;
            if (asyncScene.progress >= 0.9f)
            {
                loadingBar.fillAmount = Mathf.Lerp(loadingBar.fillAmount, 1, timec);
                if (loadingBar.fillAmount == 1.0f)
                {
                    asyncScene.allowSceneActivation = true;
                }
            }
            else
            {
                loadingBar.fillAmount = Mathf.Lerp(loadingBar.fillAmount, asyncScene.progress, timec);
                if (loadingBar.fillAmount >= asyncScene.progress)
                {
                    timec = 0f;
                }
            }
        }
        // Update is called once per frame
        void Update()
        {

        }
    }
}
