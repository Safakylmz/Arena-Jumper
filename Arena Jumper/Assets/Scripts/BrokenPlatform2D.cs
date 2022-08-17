using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenPlatform2D : MonoBehaviour
{
    private int hitCount = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {

            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                FindObjectOfType<Player2D>().CreateDust();
                hitCount++;
            }
            if (hitCount == 2)
            {
                FindObjectOfType<Player2D>().CreateDust();
                Destroy(gameObject);
            }
        

    }
}
