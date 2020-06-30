using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHelper : MonoBehaviour
{
    //public ChangeColorHelper _playrCar;
    public Transform StartPosition;
    public GameObject[] RacePrefab;
    GameObject _playerCar;

    void Start()
    {
        //_playrCar.ChangeColor(0);
        _playerCar = Instantiate(RacePrefab[SettingClass.IdCar]) as GameObject; //, StartPosition.transform.position, StartPosition.transform.rotation) as GameObject;
        _playerCar.transform.rotation = Quaternion.identity;

        _playerCar.GetComponentInChildren<ChangeColorHelper>().LoadCar(SettingClass.PlayerCar);
    }

    void Update()
    {
        _playerCar.GetComponentInChildren<ChangeColorHelper>().LoadCar(SettingClass.PlayerCar);
    }

    public void StartRace()
    {
        SceneManager.LoadScene(SettingClass.NamberTrack);
    }

    public void ChengeCar(int id)
    {
        if (id != SettingClass.IdCar)
        {
            Destroy(_playerCar);
            SettingClass.IdCar = id;
            _playerCar = Instantiate(RacePrefab[SettingClass.IdCar]) as GameObject;
            _playerCar.transform.rotation = Quaternion.identity;
            _playerCar.GetComponentInChildren<ChangeColorHelper>().LoadCar(SettingClass.PlayerCar);
        }
    }
}
