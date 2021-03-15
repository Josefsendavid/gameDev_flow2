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
            die();
        }
    }

    void die()
    {
        Destroy(gameObject, 5f);
        GetComponent<Animator>().enabled = false;
        GetComponent<MoveRandomly>().enabled = false;
        setRigidBodyState(false);
        setColliderState(true);
    }

    void setRigidBodyState(bool state)
    {
        Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();

        foreach(Rigidbody rigidbody in rigidbodies)
        {
            rigidbody.isKinematic = state;
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
