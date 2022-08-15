using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump2D : MonoBehaviour
{

    [Header("zýplama gücü ve düþüþ hýzý")]
    public float jumpVelocity;
    public float fallMultiplier = 2.5f;

    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform") && (collision.relativeVelocity.y >= 0f))
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpVelocity;
            FindObjectOfType<Player2D>().CreateDust();
        }
    }

    public void Update()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
    }
}