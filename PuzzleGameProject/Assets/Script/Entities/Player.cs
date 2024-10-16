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
    private Animator _animator;

    private AudioSource _audioSource; // For playing footstep sounds
    [SerializeField] private AudioClip footstepSound; // Footstep sound to assign in Inspector
    private bool isPlayingFootstep = false; // To avoid multiple footstep sounds playing at once

    private bool isGrounded;
    private int jumpCount = 0;
    private int maxJumps = 2;

    private InteractableObject currentInteractableObject;


    private void Start()
    {
        _playerRB = GetComponent<Rigidbody2D>();
        _camera = Camera.main;
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>(); // Get the AudioSource component
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (isGrounded)
        {
            jumpCount = 0;
        }

        // Play footstep sound when player is moving and grounded
        if (Mathf.Abs(_playerRB.velocity.x) > 0.1f && isGrounded && !isPlayingFootstep)
        {
            StartCoroutine(PlayFootstepSound());
        }
    }

    public override void Move(Vector2 direction)
    {
        // Set player's horizontal velocity directly
        Vector2 newDirection = new Vector2(direction.x * _speed, _playerRB.velocity.y);
        _playerRB.velocity = newDirection;

        if (Mathf.Abs(direction.x) > 0)
        {
            // Player is moving: set walking to true in Animator
            _animator.SetBool("Walking", true);
        }
        else
        {
            // Player is not moving: set walking to false in Animator
            _animator.SetBool("Walking", false);
        }

        // Rotate the player based on movement direction
        if (direction.x > 0)
        {
            // Face right (make sure to set the scale according to your sprite's default direction)
            transform.localScale = new Vector3(-1, 1, 1); // Flip to right
        }
        else if (direction.x < 0)
        {
            // Face left by flipping the sprite on the X axis
            transform.localScale = new Vector3(1, 1, 1); // Flip to left
        }
    }

    public override void Jump()
    {
        if (jumpCount >= maxJumps)
        {
            return;
        }

        isGrounded = false;

        // Apply the jump force without overriding horizontal movement
        Vector2 jumpVelocity = new Vector2(_playerRB.velocity.x, _jumpForce);
        _playerRB.velocity = jumpVelocity;

        jumpCount++;

        Debug.Log("Player Jump " + jumpCount);

        _animator.SetTrigger("Jump");
    }

    public override void Attack()
    {
        // Setup later
    }

    public override void Die()
    {
        // Setup later 
    }

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

    // Coroutine to play footstep sound at intervals while walking
    private IEnumerator PlayFootstepSound()
    {
        isPlayingFootstep = true;
        _audioSource.PlayOneShot(footstepSound); // Play footstep sound
        yield return new WaitForSeconds(0.5f); // Adjust this duration based on your footstep sound and speed
        isPlayingFootstep = false;
    }
}
