using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserHelper : MonoBehaviour
{
    int _idTarget = 0; // номер текущей цели
    int _quantityLaps; // количество кругов
    int _quantityLapsInTrack; // количество кругов на трассе
    bool _isLastLaps; // проверка на последний круг
    public bool IsCanUserFinish { get; private set; } //разрешено ли финишировать игроку

    GameHelper _game;
    Transform _target;
    int _halfPoint; // для определения проехал ли игрок половину трассы

    void Start()
    {
        _game = FindObjectOfType<GameHelper>();
        IsCanUserFinish = false;
        _isLastLaps = !(_game.IsLaps && _game.QuantityLaps > 1);
        _quantityLaps = 1;
        _quantityLapsInTrack = _game.QuantityLaps;
        _halfPoint = _game.Points.Length / 2;
    }

    void Update()
    {
        if (!_target)
        {
            _target = _game.Points[_idTarget].transform;
        }
        if (Vector3.Distance(_target.position, transform.position) < 40)
        {
            _idTarget++;
            if (_game.IsLaps && _idTarget == _game.Points.Length)
            {
                _quantityLaps++;
                if (_quantityLaps <= _quantityLapsInTrack)
                {
                    _idTarget = 0;
                    if (_quantityLaps == _quantityLapsInTrack)
                        _isLastLaps = true;
                }
            }
            if (_idTarget < _game.Points.Length)
            {
                _target = _game.Points[_idTarget].transform;
            }
            if(_isLastLaps && _idTarget == (_game.Points.Length - _halfPoint))
            {
                IsCanUserFinish = true;
            }
        }
    }

    public bool GetIsLastLaps()
    {
        return _isLastLaps;
    }
    public int GetLaps()
    {
        return _quantityLaps;
    }
    public void NextLaps()
    {
        _quantityLaps++;
    }
}
