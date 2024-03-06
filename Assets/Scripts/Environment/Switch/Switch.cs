using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;
    public bool isOn = false;
    public Door door;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Action()
    {
        if (!isOn)
        {
            animator.SetBool("on", true);
            isOn = true;
            if(door != null)
            {
                door.isCanAction = true;
            }
        } 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Item")
        {
            Action();
        }
    }
}
