using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2D : MonoBehaviour
{

    [SerializeField] private float damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Spear"))
        {
            gameObject.SetActive(false);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<Health2D>().TakeDamage(damage);
            FindObjectOfType<Player2D>().CreateBlood();
        }
    }
}
