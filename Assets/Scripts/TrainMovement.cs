﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TrainMovement : MonoBehaviour
{
    [SerializeField]
    public float totalWaitTime;

    // Start is called before the first frame update

    [SerializeField]
    List<WayPoint> patrolPoints;

    //Animator animator;
    //public GameObject target;
    NavMeshAgent train1NavMeshAgent;
    
    int currentPatrolIndex;
    float waitTimer;
    CharacterController characterController;


    void Start()
    {
        train1NavMeshAgent = GetComponent<NavMeshAgent>();
        //animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        train1NavMeshAgent.Warp(transform.position);
        if (train1NavMeshAgent == null)
            Debug.Log("No NavMeshAgent or target assigned to " + this.name);
        else
        {
            
            if (patrolPoints != null && patrolPoints.Count >= 1)
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
        if (patrolPoints != null)
        {
           Vector3 targetVector = patrolPoints[currentPatrolIndex].transform.position;
           train1NavMeshAgent.SetDestination(targetVector);
        }
    }

    // Update is called once per frame
    void Update()
    {
        train1NavMeshAgent.SetDestination(patrolPoints[currentPatrolIndex].transform.position);
        if (train1NavMeshAgent.remainingDistance > 0)
        {
            waitTimer = 0f;
            float animationSpeed = 1f;
            //animator.SetFloat("Speed", animationSpeed);
        }
        else
        {
            //animator.SetFloat("Speed", 0f);
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
        currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Count;
    }
}
