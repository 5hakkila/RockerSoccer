using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScene : MonoBehaviour {
        

    public void onStartClicked()
    {
        SceneManager.LoadScene("ai_s");
        PlayerPrefs.SetInt("nextScene", 2);
    }
  
}
