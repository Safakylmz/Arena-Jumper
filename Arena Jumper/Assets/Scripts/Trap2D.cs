using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap2D : MonoBehaviour
{
    [SerializeField] private float damage;
    public float rotationZ = 75;
    Vector3 initPos;

    private void Start()
    {
        initPos = transform.position;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Health2D>().TakeDamage(damage);
            FindObjectOfType<Player2D>().CreateBlood();
        }
    }

    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, -rotationZ) * Time.deltaTime);
    }
}
