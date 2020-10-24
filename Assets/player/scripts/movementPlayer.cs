using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementPlayer : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float dirction = -1f;
    public Transform body;
    public Animator animtion;
    public Rigidbody2D rb;
    public BoxCollider2D boxCollider;
    [SerializeField] private LayerMask groundLayerMask;

    void jump()
    {
        if (isGround() && Input.GetKey(KeyCode.Space))
        {
            float jump = 12f;
            rb.velocity = Vector2.up * jump;
        }
    }
    private bool isGround()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(boxCollider.bounds.center,
            boxCollider.bounds.size, 0f, Vector2.down, .1f, groundLayerMask);
        return raycastHit2D.collider != null;
    }
    private void movement()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0);
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            if (dirction == -1)
            {
                body.Rotate(0, 180, 0);
                dirction = 1;
            }

        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0);
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            if (dirction == 1)
            {
                body.Rotate(0, -180, 0);
                dirction = -1;
            }
        }
    }
    void FixedUpdate()
    {
        jump();
        movement();
    }
}
