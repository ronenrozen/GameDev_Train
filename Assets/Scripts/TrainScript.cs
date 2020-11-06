using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TrainScript : MonoBehaviour
{
    public Transform[] stations;
    public float speed;
    public float waitBeforeLeavingStation;
    private int currentStation;
    private float waitTimer;

    // Update is called once per frame
    void Update()
    {
        if (waitForPassangers(waitBeforeLeavingStation))
        {
            if (transform.position != stations[currentStation].position)
            {

                Vector3 position = Vector3.MoveTowards(transform.position, stations[currentStation].position, speed * Time.deltaTime);
                GetComponent<Rigidbody>().MovePosition(position);

            }
            else
            {
                currentStation = (currentStation + 1) % stations.Length;
                waitTimer = 0f;
            }
        }   
    }

    private bool waitForPassangers(float timeToWait)
    {
        waitTimer += Time.deltaTime;
        if (waitTimer >= timeToWait)
            return true;
        return false;
    }
}
