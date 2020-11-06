using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRideTrain : MonoBehaviour
{
    public GameObject player;

    private void FixedUpdate()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            player.transform.parent = transform.parent.parent;
            player.transform.position = transform.position;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.gameObject == player)
        {
            player.transform.parent = null;
        }
    }
}
