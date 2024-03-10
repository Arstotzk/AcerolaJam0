using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;
    public bool isOn = false;
    public Door door;
    public Color colorClosed;
    public Color colorOpen;
    public Light doorLight;
    void Start()
    {
        animator = GetComponent<Animator>();
        doorLight.color = colorClosed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Action()
    {
        if (!isOn)
        {
            doorLight.color = colorOpen;
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
