using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCam : MonoBehaviour {

    public GameObject camTarget;
    public float rotateSpeed = 5;
    Vector3 offset;

    void Start()
    {
        offset = camTarget.transform.position - transform.position;
    }

    void LateUpdate()
    {
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;
        camTarget.transform.Rotate(0, horizontal, 0);

        float desiredAngle = camTarget.transform.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
        transform.position = camTarget.transform.position - (rotation * offset);

        transform.LookAt(camTarget.transform);
    }
}

