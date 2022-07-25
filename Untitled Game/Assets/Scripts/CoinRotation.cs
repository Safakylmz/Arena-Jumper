using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotation : MonoBehaviour
{
    public float amp = 0.20f;
    public float freq = 1.25f;
    Vector3 initPos;
    private void Start()
    {
        initPos = transform.position;

    }
    void Update()
    {
        transform.Rotate(new Vector3(25, 0, 0) * Time.deltaTime);
        transform.position = new Vector3(initPos.x, Mathf.Sin(Time.time * freq) * amp + initPos.y, initPos.z);
    }
}

