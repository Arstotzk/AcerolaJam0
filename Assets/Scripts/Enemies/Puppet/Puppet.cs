using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.AI;
public class Puppet : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public bool isCanMove = false;
    public float lastmoveTime;
    public float moveAfterTime = 10f;
    private float moveTime;
    public int moveChance = 500;
    private Animator animator;
    public float speed = 5;
    private int runNum = 0;
    private NavMeshAgent agent;

    public Collider damageCollider;
    public Collider fearCollider;
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player").FirstOrDefault();
        lastmoveTime = Time.time;
        Debug.Log("Time:" + lastmoveTime);
        moveTime = moveAfterTime;
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        if (isCanMove && Time.time > moveTime && lastmoveTime < moveTime)
        {
            var random = Random.Range(1, moveChance);
            if (random <= 1)
            {
                moveTime = Time.time + moveAfterTime;
                lastmoveTime = Time.time;
                Debug.Log("MoveTime:" + lastmoveTime);
                agent.destination = player.transform.position;
                agent.speed = speed;
                damageCollider.enabled = true;
                fearCollider.enabled = true;
                runNum = Random.Range(0,2);
                animator.SetBool("run" + runNum, true);
            }
        }
    }
    public void StopMove()
    {
        animator.SetBool("run" + runNum, false);
        agent.speed = 0;
        damageCollider.enabled = false;
        fearCollider.enabled = false;
    }
}
