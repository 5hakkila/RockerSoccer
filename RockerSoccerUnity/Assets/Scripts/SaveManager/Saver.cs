using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Saver : MonoBehaviour {


    public Text levelText;
    public Text xp;
    public Slider sl;
    public Slider musicSlider;



    public int newTotalxp;
    public int level;
    public int levelAmount = 10;
    static int[] steps = { 25, 50, 100, 200, 400, 800, 1600, 3200, 6400, 12800 };

    private void Start()
    {
        Save();
        level = CheckCurrentLevel();
       // Debug.Log("currentLevel:" + level);
        levelText.text = "Level "+ level.ToString();
        xp.text =  newTotalxp + "/" + steps[level].ToString() + " xp";
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }


    public void Save()
    {
        int lastRoundxp = PlayerPrefs.GetInt("lastRoundXp");
        int totalxp = Load();
        newTotalxp = lastRoundxp + totalxp;
        PlayerPrefs.SetInt("totalxp", newTotalxp);
       // Debug.Log("total xp: " + totalxp);
        Delete();
    }
    public int Load()
    {
        int totalxp = PlayerPrefs.GetInt("totalxp");
        return totalxp;
    }

    public void Delete()
    {
        PlayerPrefs.SetInt("lastRoundXp", 0);
    }
    
    public int CheckCurrentLevel()
    {
        int returnLevel = 0;
        int i = 0;
        bool levelChecked = false;
        while (levelChecked == false)
        {
            if(newTotalxp < steps[i])
            {
                returnLevel = i;
                levelChecked = true;   
            }
            else
            {
                ++i;
            }
        }
        return (returnLevel);
    }
  
}
