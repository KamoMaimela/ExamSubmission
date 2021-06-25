using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float walkSpeed;
    public bool mustPatrol;
    private bool mustTurn;

    public Rigidbody2D rb;

    void Start()
    {
        mustPatrol = true;
    }

    void Update()
    {
        if (mustPatrol)
        {
            Patrol();
        }
    }

    void Patrol()
    {

        transform.Translate(Vector2.up * walkSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y * -1);
            walkSpeed *= -1;
          
        }

        if (collision.gameObject.CompareTag("Fire"))
        {
            transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y * -1);
            walkSpeed *= -1;

        }

        if (collision.gameObject.CompareTag("Earth"))
        {
            transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y * -1);
            walkSpeed *= -1;

        }

        if (collision.gameObject.CompareTag("Lava"))
        {
            transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y * -1);
            walkSpeed *= -1;

        }

    }

}
