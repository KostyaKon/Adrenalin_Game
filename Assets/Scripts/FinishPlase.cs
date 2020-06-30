using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishPlase : MonoBehaviour
{
    public bool IsUser = false;
    public bool IsFinished { get; private set; }
    public int PlaseGamer { get; private set; }

    void Start()
    {
        IsFinished = false;
    }

    void Update()
    {
        
    }

    public void Finished(int plase)
    {
        IsFinished = true;
        PlaseGamer = plase;
    }

    public void UserFinished()
    {
        Invoke("LoadMainScene", 6f);
    }

    void LoadMainScene()
    {
        SceneManager.LoadScene(0);
    }
}
