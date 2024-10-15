using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayableObject : MonoBehaviour
{
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float groundCheckRadius = 0.2f;


    public abstract void Move(Vector2 direction);
    public abstract void Jump();
    public abstract void Die();
    public abstract void Attack();
}
