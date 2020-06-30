using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCarUserHelper : MonoBehaviour
{
    CarModel _carModel = new CarModel();
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void SaveCar()
    {
        SettingClass.PlayerCar = _carModel;
    }

    public void ChangeSpoil(int id)
    {
        _carModel.Spoil = id;
        SaveCar();
    }

    public void ChangeColor(int color)
    {
        _carModel.Color = color;
        SaveCar();
    }
}
