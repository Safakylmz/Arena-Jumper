using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform2D : MonoBehaviour
{
    public Transform pos1, pos2;
    public float speed;
    public Transform startPos;

    Vector3 nextPos;

    public float jumpForce = 15f;

    private void Start()
    {
        nextPos = startPos.position;
    }

    private void Update()
    {
        if(transform.position == pos1.position)
        {
            nextPos = pos2.position;
        }
        if(transform.position == pos2.position)
        {
            nextPos = pos1.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y <= 0f)
        {
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                Vector2 velocity = rb.velocity;
                velocity.y = jumpForce;
                rb.velocity = velocity;
            }
        }

    }

   /* private void OnDrawGizmos()
   / {
        Gizmos.DrawLine(pos1.position, pos2.position);
    }
   */
}
