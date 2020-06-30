using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SettingClass
{
    public static int IdCar = 0;
    public static CarModel PlayerCar = new CarModel();

    public static int NamberTrack = 1;
    public static bool IsLaps = false;
    public static int QuantityLaps = 3;

    public static float SoundLevel = 1F; // Уровень звука

    public static PointHelper[] PointsTrack;

    public  static Transform GetTransformPoints(int id)
    {
        return PointsTrack[id].transform;
    }
}
