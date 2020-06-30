using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorHelper : MonoBehaviour
{
    public GameObject[] CarParts;

    public GameObject[] CarSpoils;

    public bool IsUser = false;

    //int _quantityColors = 8;

    CarModel _carModel = new CarModel();
    void Start()
    {
        //SaveCar();
    }

    void Update()
    {
        
    }

    public void LoadCar(CarModel model)
    {
        ChangeColor(model.Color);
        ChangeSpoil(model.Spoil);
    }

    public void SaveCar()
    {
        SettingClass.PlayerCar = _carModel;
    }

    public void ChangeSpoil(int id)
    {
        foreach (var item in CarSpoils)
            item.SetActive(false);
        CarSpoils[id].SetActive(true);

        _carModel.Spoil = id;
        if(IsUser)
            SaveCar();
    }

    public void ChangeColor(int color)
    {
        Color newColor = Color.white;
        bool userChange = false;

        switch (color)
        {
            case 0:
                newColor = Color.white;
                userChange = true;
                break;
            case 1:
                newColor = Color.green;
                userChange = true;
                break;
            case 2:
                newColor = Color.magenta;
                userChange = true;
                break;
            case 3:
                newColor = Color.yellow;
                userChange = true;
                break;
            case 4:
                newColor = Color.red;
                userChange = true;
                break;
            case 5:
                newColor = Color.blue;
                userChange = true;
                break;
            case 6:
                newColor = Color.black;
                userChange = true;
                break;
            case 7:
                newColor = Color.gray;
                userChange = true;
                break;
        }
        if (userChange)
        {
            foreach (var item in CarParts)
            {
                item.GetComponent<MeshRenderer>().material.color = newColor;
            }

            _carModel.Color = color;
            if (IsUser)
                SaveCar();
        }
    }
}
