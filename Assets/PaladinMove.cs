using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PaladinMove : MonoBehaviour
{
    // Start is called before the first frame update

    public float attackDistance = 2;
    public float attackRate = 1;
    private float nextAttack;

    public float walkSpeed = 3.5f;
    public float runSpeed = 6f;

    private NavMeshAgent agent; 
    private Animator anim;

    private Transform targetedEnemy;
    private bool enemyClicked;
    private bool walking;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        anim.SetBool("isAttacking", false);

    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            agent.speed = runSpeed;
            //anim.SetBool("isRunning", true);
        } 
        else
        {
            agent.speed = walkSpeed;
            //anim.SetBool("isRunning", false);anim.SetBool("isWalking", true);
        }

        if (Input.GetMouseButtonDown(0))
        {
            if(Physics.Raycast(ray, out hit, 100)){

                if(hit.collider.tag == "Enemy"){
                    targetedEnemy = hit.transform;
                    enemyClicked = true;
                }
                else {
                    walking = true;
                    enemyClicked = false;
                    agent.isStopped = false;
                    agent.destination = hit.point;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            //die()

        }

        if(enemyClicked){
            Attack();
        }
        else {
             if(agent.remainingDistance <= agent.stoppingDistance){
            //walking = false;
            //anim.SetBool("isRunning", false);
        }
        else {
           // walking = true;
        }
        //anim.SetBool("isWalking", walking);
        anim.SetBool("isAttacking", false);
        }

         SetAnimationParameters();
    }
    private void SetAnimationParameters()
    {
        anim.SetFloat("Speed", agent.desiredVelocity.magnitude);
    }

    void Attack(){
        {
        StartCoroutine(SomeCoroutine());
        }

        IEnumerator SomeCoroutine()
        {

        if(targetedEnemy != null){
        agent.destination = targetedEnemy.position;
        
        if(agent.remainingDistance > attackDistance){
            agent.isStopped = false;
            walking = true;
        }
        else if(agent.remainingDistance <= attackDistance) {
            //anim.SetBool("isWalking", false);
            transform.LookAt(targetedEnemy);
            anim.SetBool("isAttacking", false);
            Vector3 attackDir = targetedEnemy.transform.position - transform.position;
            EnemyController enemy = targetedEnemy.transform.GetComponent<EnemyController>();
            
            
            if(Time.time > nextAttack){
                agent.speed = 0;
                nextAttack = Time.time + attackRate;
                anim.SetBool("isAttacking", true);
                yield return new WaitForSeconds (0.2f);
                if(enemy.GetComponentInChildren<Animator>()){
                    enemy.die();}
                
            }}
            agent.isStopped = true;
            //walking = false;
          }
    }
    }
}