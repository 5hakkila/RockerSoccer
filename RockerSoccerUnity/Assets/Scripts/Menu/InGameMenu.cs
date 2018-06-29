using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenu: MonoBehaviour
{
    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}