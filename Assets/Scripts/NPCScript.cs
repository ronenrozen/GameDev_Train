using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCScript : MonoBehaviour
{
    public Transform[] stations;
    public float speed;
    public float waitBeforeLeavingStation;
    private int currentStation;
    private bool targetReached;

    private void Start()
    {
        targetReached = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (transform.position != stations[currentStation].position)
        {
           if(!targetReached)
            {
                Vector3 position = Vector3.MoveTowards(transform.position, stations[currentStation].position, speed * Time.deltaTime);
                GetComponent<Rigidbody>().MovePosition(position);
            }
           
            
        }
        else
        {
            currentStation = (currentStation + 1) % stations.Length;
            targetReached = true;
            GetComponent<NavMeshAgent>().enabled = true;
            GetComponent<NPCMovement>().enabled = true;
            GetComponent<NPCScript>().enabled = false;
        }

    }
}
