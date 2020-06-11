using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;

public class Loading : MonoBehaviour
{
    [SerializeField]
    Image loadingBar;
    string s;
    // Start is called before the first frame update
    void Start()
    {
        s = ChangeScenes.s;
        loadingBar.fillAmount = 0;
        StartCoroutine(LoadAsyncScene());
    }

    public static void LoadScene(string sceneName)
    {
        SceneManager.LoadScene("Loading");
    }

    IEnumerator LoadAsyncScene()
    {
        yield return null;
        AsyncOperation asyncScene = SceneManager.LoadSceneAsync(s);
        asyncScene.allowSceneActivation = false;
        float timec = 0;
        while (!asyncScene.isDone)
        {
            yield return null;
            timec += Time.deltaTime;
            if (asyncScene.progress >= 0.9f)
            {
                loadingBar.fillAmount = Mathf.Lerp(loadingBar.fillAmount, 1, timec);
                if (loadingBar.fillAmount == 1.0f && Input.GetMouseButtonDown(0))
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
