using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Player : PlayableObject
{
    private string _name;
    [SerializeField] private float _speed = 100f;
    [SerializeField] private float _jumpForce = 5f;
    private Rigidbody2D _playerRB;
    private Camera _camera;

    private bool isGrounded;
    private int jumpCount = 0;
    private int maxJumps = 2;

    private InteractableObject currentInteractableObject;


    private void Start()
    {
        _playerRB = GetComponent<Rigidbody2D>();
        _camera = Camera.main;
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (isGrounded)
        {
            jumpCount = 0;
        }
    }

    public override void Move(Vector2 direction)
    {

        // Set player's horizontal velocity directly
        Vector2 newDirection = new Vector2(direction.x * _speed, _playerRB.velocity.y);
        _playerRB.velocity = newDirection;

    }

    public override void Jump()
    {
        if (jumpCount >= 1)
        {
            return;
        }

        isGrounded = false;

        // Apply the jump force without overriding horizontal movement
        Vector2 jumpVelocity = new Vector2(_playerRB.velocity.x, _jumpForce);
        _playerRB.velocity = jumpVelocity;

        jumpCount++;

        Debug.Log("Player Jump " + jumpCount);
    } // Double jump function

    public override void Attack()
    {

    } // setup later
    public override void Die()
    {

    } // setup later 

    public void Interact()
    {
        currentInteractableObject?.Interact();
    }

    private void OnDrawGizmos()
    {
        if (groundCheck != null)
        {
            // Set the color of the Gizmos
            Gizmos.color = Color.red;

            // Draw a wireframe sphere at the ground check position
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        InteractableObject obj = collision.transform.GetComponent<InteractableObject>();

        if (obj != null) 
        {
            currentInteractableObject = obj;
            obj.Interacter = gameObject;
        }


        Debug.Log("Maybe Can be interacted");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (currentInteractableObject != null) 
        {
            currentInteractableObject = null;
        }
    }

}
