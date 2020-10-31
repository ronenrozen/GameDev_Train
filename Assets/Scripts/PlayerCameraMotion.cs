using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraMotion : MonoBehaviour
{
    float angularSpeed;

    // Start is called before the first frame update
    void Start()
    {
        angularSpeed = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, Input.GetAxis("Mouse X") * angularSpeed, 0);
    }
}