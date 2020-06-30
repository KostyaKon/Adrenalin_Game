using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UITransitionButton : MonoBehaviour, IPointerClickHandler
{
    private UIWindow current;

    [SerializeField]
    private UIWindow next;

    public void OnPointerClick(PointerEventData eventData)
    {
        next.IsOpened = current.IsOpened;
        current.IsOpened = !current.IsOpened;
    }

    void Awake()
    {
        current = GetComponentInParent<UIWindow>();
    }
}
