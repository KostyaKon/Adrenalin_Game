using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenu : MonoBehaviour
{
    public UIWindow[] MenuWindows;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void CloseGame(float time)
    {
        foreach(var item in MenuWindows)
        {
            if (item.gameObject.activeInHierarchy)
                item.IsOpened = false;
        }
        NormTimeGame();
        Invoke("ExitGame", time);
    }

    void ExitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void ExitToMenu()
    {
        NormTimeGame();
        SceneManager.LoadScene(0);
    }

    public void RestartRace()
    {
        NormTimeGame();
        SceneManager.LoadScene(SettingClass.NamberTrack);
    }

    //public void PauseGame()
    //{
    //    Invoke("StopGame", 1.1F);
    //}

    public void PauseGame()
    {
        Time.timeScale = 0.0F;
    }

    //void StopGame()
    //{
    //    Time.timeScale = 0.0F;
    //}

    public void NormTimeGame()
    {
        Time.timeScale = 1.0F;
    }
}
