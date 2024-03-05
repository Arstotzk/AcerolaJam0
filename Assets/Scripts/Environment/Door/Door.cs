using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    public Collider iteractCollider;
    public bool isOpen = false;
    public Animator animator;
    void Start()
    {
        animator.SetBool("open", isOpen);
    }

    public void Action()
    {
        isOpen = !isOpen;
        animator.SetBool("open", isOpen);
    }
}
