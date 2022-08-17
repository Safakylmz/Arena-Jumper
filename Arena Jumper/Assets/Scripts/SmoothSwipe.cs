using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothSwipe : MonoBehaviour
{

    private bool fingerDown;
    [HideInInspector] public Vector2 startPos;
    public int pixelDistToDetect = 1;
    public float speed = 0.80f;

    // Update is called once per frame
    void Update()
    {
        if (!fingerDown && Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;
            fingerDown = true;
        }
        if (fingerDown)
        {
            if (Input.mousePosition.x >= startPos.x + pixelDistToDetect)
            {
                gameObject.transform.position += new Vector3(speed, 0, 0);
                startPos = Input.mousePosition;
                return;

            }
            if (Input.mousePosition.x <= startPos.x - pixelDistToDetect)
            {
                gameObject.transform.position -= new Vector3(speed, 0, 0);
                startPos = Input.mousePosition;
                return;

            }
        }

        if (fingerDown && Input.GetMouseButtonUp(0))
        {
            fingerDown = false;
        }
    }
}

