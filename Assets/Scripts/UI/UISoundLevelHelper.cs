using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISoundLevelHelper : MonoBehaviour
{
    private Slider slider;
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = SettingClass.SoundLevel;
    }

    void Update()
    {
        SettingClass.SoundLevel = slider.value;
    }
}
