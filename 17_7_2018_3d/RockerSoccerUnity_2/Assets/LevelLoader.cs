using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour {

    public float minTime; //Minimum loading time
    public GameObject loadingScreen;
    public Slider slider;
    public Text progressText;
    private float loadingStarted;
    private int nextScene;

    public void Start()
    {
        nextScene = PlayerPrefs.GetInt("nextScene");
        LoadLevel();
        //loadingStarted = Time.time;
        
    }
   /* public void SetMinimumLoadingTime(float minTimef)
    {
        minTime = minTimef;
    } */


    public void LoadLevel ()
    {
        int sceneIndex = nextScene;
        StartCoroutine(LoadAsynchronously(sceneIndex));
       // Debug.Log("minimum set to" + minTime);


    }

    IEnumerator LoadAsynchronously (int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        loadingScreen.SetActive(true);
     
        
            while (!operation.isDone)
            {

                float progress = Mathf.Clamp01(operation.progress / .9f);
                slider.value = progress;
                progressText.text = progress * 100f + "%";
                yield return null;
            }
            Debug.Log("loading started = " + loadingStarted);
       
           
    }
    private void Update()
    {
        //LoadLevel();
    }

}
