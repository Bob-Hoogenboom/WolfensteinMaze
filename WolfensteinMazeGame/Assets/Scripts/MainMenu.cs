using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public void LevelOne()
    {
        SceneManager.LoadScene(sceneBuildIndex:1);
    }
    public void QuitGame()
    {
        Debug.Log("Quit!!");
        Application.Quit();
    }
    
    
    
}
