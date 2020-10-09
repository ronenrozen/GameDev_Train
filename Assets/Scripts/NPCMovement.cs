using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class NPCMovement : MonoBehaviour
{
    [SerializeField]
    public float totalWaitTime;

    // Start is called before the first frame update
    
    [SerializeField]
    List<WayPoint> patrolPoints;

    Animator animator;
    //public GameObject target;
    NavMeshAgent navigateAgent;
    int currentPatrolIndex;
    float waitTimer;
    CharacterController characterController;


    void Start()
    {
        navigateAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();

        if (navigateAgent == null)
            Debug.Log("No NavMeshAgent or target assigned to " + this.name);
        else
        {
            if(patrolPoints != null && patrolPoints.Count >= 1)
            {
                currentPatrolIndex = 0;
                SetDetination();
            }
            else
            {
                Debug.Log("Insufficient patrol points for basic patroling behaviour.");
            }
        }
    }

    private void SetDetination()
    {
        waitTimer = 0f;
        if(patrolPoints != null)
        {
            Vector3 targetVector = patrolPoints[currentPatrolIndex].transform.position;
            navigateAgent.SetDestination(targetVector);
        }
    }

    // Update is called once per frame
    void Update()
    {
        navigateAgent.SetDestination(patrolPoints[currentPatrolIndex].transform.position);
        if (navigateAgent.remainingDistance > 0)
        {
            waitTimer = 0f;
            float animationSpeed = patrolPoints[currentPatrolIndex].CompareTag("Character") ? 1.5f : 0.6f;
            animator.SetFloat("Speed", animationSpeed);
        }
        else
        {
            animator.SetFloat("Speed", 0f);
            waitTimer += Time.deltaTime;

            if (waitTimer >= totalWaitTime)
            {

                ChangePatrolPoint();
                SetDetination();
            }

            //ChangePatrolPoint();
            //SetDetination();
        }
    }

    private void ChangePatrolPoint()
    {
        currentPatrolIndex = UnityEngine.Random.Range(0, patrolPoints.Count);
    }

    private void OnCollisionStay(Collision collision)
    {
        navigateAgent.Move(Vector3.left * 2);
        
    }

}
