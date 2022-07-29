using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    public GameObject target;

    void LateUpdate()
    {
        if (target.transform.position.y > transform.position.y)
        {
            Vector3 newPos = new Vector3(transform.position.x, target.transform.position.y, transform.position.z);
            transform.position = newPos;
        }
    }
}
