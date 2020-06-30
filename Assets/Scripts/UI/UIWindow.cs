using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWindow : MonoBehaviour
{
    private Animator animator;

    public bool IsOpened
    {
        get { return animator.GetBool("IsOpen"); }
        set
        {
            if (!gameObject.activeInHierarchy)
                gameObject.SetActive(true);
            animator.SetBool("IsOpen", value);
        }
    }

    private void OnEnable()
    {
        if (animator) return;
        animator = GetComponent<Animator>();
    }
}
