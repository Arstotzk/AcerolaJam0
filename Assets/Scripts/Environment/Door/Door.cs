using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    public Collider iteractCollider;
    public bool isOpen = false;
    public Animator animator;
    public bool isCanAction = true;
    void Start()
    {
        animator.SetBool("open", isOpen);
    }

    public void Action()
    {
        if (!isCanAction)
        {
            animator.SetBool("tryOpen", true);
            return;
        }
        isOpen = !isOpen;
        animator.SetBool("open", isOpen);
    }
    public void ResetTryOpen()
    {
        animator.SetBool("tryOpen", false);
    }
}
