using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible2D : MonoBehaviour
{
    [SerializeField] private float healthValue;
    public float amp = 0.20f;
    public float freq = 1.25f;
    Vector3 initPos;

    private void Start()
    {
        initPos = transform.position;
    }
    private void Update()
    {
        transform.position = new Vector3(initPos.x, Mathf.Sin(Time.time * freq) * amp + initPos.y, initPos.z);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        other.GetComponent<Health2D>().AddHealth(healthValue);
        gameObject.SetActive(false);
    }
}
