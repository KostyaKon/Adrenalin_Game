using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHelper : MonoBehaviour
{
    public Transform StartPosition;
    public GameObject[] RacePrefab;

    public PointHelper[] Points;
    public bool IsLaps = false;
    public int QuantityLaps = 3;

    GameObject _playerCar;

    public Transform[] StartPositionEnemy;
    GameObject[] EnemyCar = new GameObject[3];
 
    public GameObject EnemyPrefab;
    public int QuantityEnemy = 3;

    void Start()
    {
        SettingClass.PointsTrack = Points;
        SettingClass.IsLaps = IsLaps;
        SettingClass.QuantityLaps = QuantityLaps;
        // Car Player
        _playerCar = Instantiate(RacePrefab[SettingClass.IdCar]) as GameObject; //, StartPosition.transform.position, StartPosition.transform.rotation) as GameObject;
        //_playerCar.transform.position = new Vector3(-3.0f, -6.75f, -6.0f );
        _playerCar.transform.rotation = Quaternion.identity;
        _playerCar.transform.SetParent(StartPosition, false);

        _playerCar.GetComponentInChildren<ChangeColorHelper>().LoadCar(SettingClass.PlayerCar);

        for(int i = 0; i < QuantityEnemy; ++i)
        {
            EnemyCar[i] = GetEnemyCar(i);
            System.Threading.Thread.Sleep(12);
        }
    }

    void Update()
    {
        
    }

    private GameObject GetEnemyCar(int id)
    {
        GameObject enemy = Instantiate(EnemyPrefab, StartPositionEnemy[id].transform.position, StartPositionEnemy[id].transform.rotation) as GameObject;
        System.Random rand = new System.Random();
        enemy.GetComponentInChildren<UnityStandardAssets.Vehicles.Car.CarController>().MaxSpeed += rand.Next(-10, 10);
        enemy.GetComponentInChildren<UnityStandardAssets.Vehicles.Car.CarController>().SpeedMultipl += (rand.Next(-1, 1)) / 10;
        enemy.GetComponentInChildren<ChangeColorHelper>().ChangeColor(rand.Next(8));
        enemy.GetComponentInChildren<ChangeColorHelper>().ChangeSpoil(rand.Next(3));

        return enemy;
    }

}
