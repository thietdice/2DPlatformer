using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sp;
    private BoxCollider2D coll;
    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 6f;
    [SerializeField] private float jumpForce = 11f;
    [SerializeField] private LayerMask Jumpable;
    private enum MovementState {idle,running,jumping,falling};

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {

        dirX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(0, jumpForce);
        }
        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        MovementState state = MovementState.idle;
        if (dirX == 0f ) {
            state = MovementState.idle;
        }
        else if (dirX > 0f) {
            state = MovementState.running;
            sp.flipX = false;
        }
        else if (dirX < 0f) {
            state = MovementState.running;
            sp.flipX = true;
        }
        if (rb.velocity.y > 1f) {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -1f) {
            state = MovementState.falling;
        }
        anim.SetInteger("State", (int)state);
    }
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, Jumpable);
    }
}
