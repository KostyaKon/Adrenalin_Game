using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class EnemyHelper : MonoBehaviour
{
    CarAIControl _carAIControl;
    CarController _carController;
    Transform _target;
    GameHelper _game;

    int _idTarget = 0; // номер текущей цели
    int _quantityLaps; // количество кругов
    bool _isLastLaps; // проверка на последний круг
    int _halfPoint; // для определения проехал ли игрок половину трассы
    public bool IsCanEnemyFinish { get; private set; }

    void Start()
    {
        _carAIControl = GetComponent<CarAIControl>();
        _carController = GetComponent<CarController>();
        //_quantityLaps = SettingClass.QuantityLaps;
        _game = GameObject.FindObjectOfType<GameHelper>();
        _quantityLaps = _game.QuantityLaps;
        _halfPoint = _game.Points.Length / 2;
        IsCanEnemyFinish = false;
        if (_game.IsLaps && _game.QuantityLaps > 1)
        {
            _isLastLaps = false;
        }
        else
        {
            _isLastLaps = true;
        }
    }

    void Update()
    {
        if (!_target)
        {
            _target = _game.Points[_idTarget].transform;
            //_target = SettingClass.GetTransformPoints(_idTarget);
            _carAIControl.SetTarget(_target);
        }
        if (Vector3.Distance(_target.position, transform.position) < (8 + _carController.CurrentSpeed/6))
        {
            _idTarget++;
            if(_game.IsLaps && _idTarget == _game.Points.Length)
            {
                --_quantityLaps;
                if(_quantityLaps > 0)
                {
                    _idTarget = 0;
                    if (_quantityLaps == 1)
                        _isLastLaps = true;
                }
            }
            if(_idTarget < _game.Points.Length)
            {
                _target = _game.Points[_idTarget].transform;
                _carAIControl.SetTarget(_target);
            }
            if (_isLastLaps && _idTarget == (_game.Points.Length - _halfPoint))
            {
                IsCanEnemyFinish = true;
            }
        }
    }

    public bool GetIsLastLaps()
    {
        return _isLastLaps;
    }
}
