using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;

public class UISpeedUser : MonoBehaviour
{
    public Text text;
    private CarController carController;
    string KMH = " km/h";

    void Start()
    {
        //carController = FindObjectOfType<UserHelper>().GetComponent<CarController>();
    }

    void Update()
    {
        if(carController == null)
            carController = FindObjectOfType<UserHelper>().GetComponent<CarController>();
        text.text = ((int)carController.CurrentSpeed).ToString();// + KMH;
    }
}
