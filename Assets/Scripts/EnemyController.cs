using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    /* 
    EnemyController enemy = hit.transform.GetComponent<EnemyController>();

    if (enemy != null)
    {
        enemy.die();
    }
    */



    // Start is called before the first frame update
    void Start()
    {
        setRigidBodyState(true);
        setColliderState(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {

        }
    }

    public void die()
    {
          
        GetComponentInChildren<AIController>().enabled = false;
        GetComponentInChildren<Animator>().enabled = false;
        GetComponentInChildren<MoveRandomly>().enabled = false;
        Destroy(gameObject, 2f);
        
        setRigidBodyState(false);
        setColliderState(true);
    }

    void setRigidBodyState(bool state)
    {
        Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();

        foreach(Rigidbody rigidbody in rigidbodies)
        {   
            rigidbody.isKinematic = state;

            Vector3 dir = new Vector3(Random.Range(-2, 2), Random.Range(0, 2), Random.Range(-2, 2));
            rigidbody.AddForce(dir * 8, ForceMode.Impulse);
            
            
        }

        GetComponent<Rigidbody>().isKinematic = !state;
    }
        void setColliderState(bool state)
    {
        Collider[] colliders = GetComponentsInChildren<Collider>();

        foreach(Collider collider in colliders)
        {
            collider.enabled = state;
        }

        GetComponent<Collider>().enabled = !state;
    }
}
