using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{

    [Header("Target")]
    public Transform target;
    [Header("Distances")]
    public float distance = 7f;
    public float minDistance = 1f;
    public float maxDistance = 11f;
    public Vector3 offset;
    [Header("Speeds")]
    public float smoothSpeed = 5f;
    public float scrollSensitivity = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(!target){
            print("No target");
            return;
        }

        float num = Input.GetAxis("Mouse ScrollWheel");
        distance -= num * scrollSensitivity;
        distance = Mathf.Clamp(distance, minDistance, maxDistance);

        Vector3 pos = target.position + offset;
        pos -= transform.forward * distance;

        transform.position = Vector3.Lerp(transform.position, pos, smoothSpeed * Time.deltaTime);
    }
}
