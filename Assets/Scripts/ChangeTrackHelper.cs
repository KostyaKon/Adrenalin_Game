using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTrackHelper : MonoBehaviour
{
    public int QuantityTrack = 1;

    public Text Track;

    int _namberTrack;
 
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ChangeTrack(int id)
    {
        if(id >= 0 && id <= QuantityTrack)
            SettingClass.NamberTrack = id;
    }
    public void ChangeNameTrack(string nameTrack)
    {
        Track.text = nameTrack.ToString();
    }
}
