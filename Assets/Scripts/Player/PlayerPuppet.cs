using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPuppet : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject puppet;
    public MouseInput mouseInput;
    public PlayerMovement playerMovement;
    public ChosenItem chosenItem;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayEnd()
    {
        mouseInput.isBlockMove = true;
        playerMovement.isDeath = true;
        chosenItem.gameObject.SetActive(false);
        puppet.SetActive(true);
        var animator = puppet.GetComponent<Animator>();
        animator.Play("Armature_End");
    }
}
