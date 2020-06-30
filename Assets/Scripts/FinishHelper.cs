using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FinishHelper : MonoBehaviour
{
    public UIWindow WinPanel;
    public UIWindow NotWinPanel;

    int ScorePlase { get; set; }
    
    bool _isLastLaps; //последний ли круг(финишируют машины или нет)
    void Start()
    {
        ScorePlase = 1;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<FinishPlase>()) 
        {
            FinishPlase finishCar = other.GetComponent<FinishPlase>();

            if (finishCar.IsUser)
            {
                //FindObjectOfType<UserHelper>().NextLaps();
                _isLastLaps = FindObjectOfType<UserHelper>().IsCanUserFinish;
            }
            else
            {
                _isLastLaps = GameObject.FindObjectOfType<EnemyHelper>().IsCanEnemyFinish;
            }
            if (_isLastLaps)
            {
                if (!finishCar.IsFinished)
                {
                    finishCar.Finished(ScorePlase++);
                    if (finishCar.IsUser)
                    {
                        PlasePanel(finishCar.PlaseGamer);
                        finishCar.UserFinished();
                        Debug.Log("User " + other.GetComponentInParent<FinishPlase>().PlaseGamer);
                    }
                }
            }

            Debug.Log("Finish " + other.gameObject + " " + other.GetComponentInParent<FinishPlase>().PlaseGamer);
        }

    }

    void PlasePanel(int plase)
    {
        if(plase == 1)
        {
            WinPanel.IsOpened = true;
        }
        else
        {
            string msg = "-"+ (plase == 2 ? "nd" : plase == 3 ? "rd" : "th");
            NotWinPanel.GetComponentInChildren<TextMeshProUGUI>().text = "YOU " + plase + msg;
            NotWinPanel.IsOpened = true;
        }
    }
}
