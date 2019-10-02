using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpSpeed;

    private bool grounded = true;

    private Rigidbody2D rb2d;
    private Collider2D coll2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        coll2d = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 velocity = rb2d.velocity;
        if (horizontal != 0)
        {
            velocity.x = horizontal * moveSpeed;
        }
        else
        {
            velocity.x = rb2d.velocity.x * 0.9f;
        }
        if (vertical > 0 && grounded)
        {
            velocity.y = vertical * jumpSpeed;
            grounded = false;
        }
        rb2d.velocity = velocity;
    }

    private void FixedUpdate()
    {
        if (rb2d.velocity.y == 0)
        {
            grounded = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (ContactPoint2D cp2d in collision.contacts)
        {
            if (cp2d.point.y <= rb2d.centerOfMass.y
                && cp2d.point.x > coll2d.bounds.min.x
                && cp2d.point.x < coll2d.bounds.max.x)
            {
                grounded = true;
                break;
            }
        }
    }
}
