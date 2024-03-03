using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Puppet : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public bool isMove = false;
    public bool isCanMove = false;
    public float lastmoveTime;
    public float moveAfterTime = 10f;
    private float moveTime;
    public int moveChance = 500;
    private Animator animator;
    public float speed = 5;
    private int runNum = 0;
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player").FirstOrDefault();
        lastmoveTime = Time.time;
        Debug.Log("Time:" + lastmoveTime);
        moveTime = moveAfterTime;
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isMove)
        {
            Vector3 targetPostition = new Vector3(player.transform.position.x,
                                       transform.position.y,
                                       player.transform.position.z);
            transform.LookAt(targetPostition);
            transform.position += transform.forward * Time.deltaTime * speed;
        }

        if (isCanMove && Time.time > moveTime && lastmoveTime < moveTime)
        {
            var random = Random.Range(1, moveChance);
            if (random <= 1)
            {
                moveTime = Time.time + moveAfterTime;
                lastmoveTime = Time.time;
                Debug.Log("MoveTime:" + lastmoveTime);
                isMove = true;
                runNum = Random.Range(0,2);
                animator.SetBool("run" + runNum, true);
            }
        }
    }
    public void StopMove()
    {
        animator.SetBool("run" + runNum, false);
        isMove = false;
    }
}
