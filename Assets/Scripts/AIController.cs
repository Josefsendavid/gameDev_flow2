using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using UnityEngine.UI;
 using UnityEngine.AI;
 public class AIController : MonoBehaviour
 {
 
     private NavMeshAgent agent; 
     private Animator anim;
     public Transform Player;
     int MoveSpeed = 2;
     int MaxDist = 10;
     int MinDist = 5;
 
 
 
 
     void Start()
     {
         agent = GetComponent<NavMeshAgent>();
         anim = GetComponent<Animator>();
     }
 
     void Update()
     {
         transform.LookAt(Player);
 
         if (Vector3.Distance(transform.position, Player.position) <= MaxDist)
        {               
            transform.position += transform.forward * MoveSpeed * Time.deltaTime;
            anim.SetFloat("Speed", agent.speed);   
            if (Vector3.Distance(transform.position, Player.position) <= MinDist)
            {
                //Here Call any function you want, like Shoot or something
            }   
        }
     }
 }