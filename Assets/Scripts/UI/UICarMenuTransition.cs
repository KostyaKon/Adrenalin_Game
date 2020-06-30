using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UICarMenuTransition : MonoBehaviour
{
    public UIWindow[] MenuWindows;

    public void ChangeCarMenu(int id)
    {
        foreach (var item in MenuWindows)
            if(item.gameObject.activeInHierarchy)
                item.IsOpened = false;
        if (id > 0)
            MenuWindows[id - 1].IsOpened = true;
    }
}
