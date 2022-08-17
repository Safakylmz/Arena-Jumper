using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Platform") || collision.CompareTag("Coin") || collision.CompareTag("Powerup") || collision.CompareTag("Trap") || collision.CompareTag("Health") || collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
    }
}
