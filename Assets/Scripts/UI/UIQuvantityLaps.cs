using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIQuvantityLaps : MonoBehaviour
{
    TextMeshProUGUI text;
    UserHelper user;
    int _quantityLaps;
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        _quantityLaps = FindObjectOfType<GameHelper>().QuantityLaps;
    }

    void Update()
    {
        if (!user)
        {
            user = FindObjectOfType<UserHelper>();
        }
        text.text = user.GetLaps().ToString() + " / " + _quantityLaps; 
    }
}
