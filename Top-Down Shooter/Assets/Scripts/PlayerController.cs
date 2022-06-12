using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Public Fields
    public float moveSpeed = 5f;            // Determines how fast the player moves
    public Rigidbody2D rb;                  // Holds Player's rigidbody
    public Launcher rLauncher;              // Reference to the Player's rocket launcher

    // Private Fields
    Vector2 moveDirection;                  // Holds x and y for directional movements

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
        CheckFire();
    }

    void FixedUpdate()
    {
        Move();
    }

    /* Checks the H/V axis and creates a new Vector2 based on them (moveDirection) */
    void CalculateMovement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    /* Changes the player's velocity based on the moveDirection and moveSpeed */
    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    /* Checks if the left mouse button is held, then calls fire on the launcher */
    void CheckFire()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rLauncher.Fire();
        }
    }
}
