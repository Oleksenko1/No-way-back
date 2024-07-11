using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCntrl : MonoBehaviour
{
    [Header("Player Movement")]
    public float moveSpeed;

    [Header("Player Rotation")]

    public Transform weaponTransform;
    public float rotationSpeed = 10f;
    public float rotationTreshold = 0.1f;

    [Header("Animation")]

    public Animator playerAnimator;

    [Header("Gun")]

    public PlayerGunHandler gunScript;

    //[Header("Other")]
    //public Camera mainCamera;

    Rigidbody2D rb;
    Vector2 movementVector;
    Vector3 mousePosition;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Move();

        Rotate();
    }

    private void Move()
    {
        rb.velocity = movementVector.normalized * moveSpeed;

        playerAnimator.SetFloat("Speed", movementVector.magnitude);
    }
    void Rotate()
    {
        var weaponDirection = (Vector3)mousePosition - weaponTransform.position;

        if (weaponDirection.magnitude > rotationTreshold) // Checking if cursor is not very close to a player
        {
            float weaponAngle = Mathf.Atan2(weaponDirection.y, weaponDirection.x) * Mathf.Rad2Deg; // Calculating angle of weapon
            var playerAngle = weaponAngle - 90f; // Calculating angle gor player

            var rotationStep = rotationSpeed * Time.deltaTime;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, playerAngle), rotationStep);
        }
    }
    public void HandleShoot() // Handled through inputHandler event system
    {
        Debug.Log("Shoot");
        gunScript.ShootBullet();
    }
    public void HandleMousePosition(Vector2 mousePos) // Handled through inputHandler event system
    {
        mousePosition = mousePos;
    }
    public void HandleReload()
    {
        Debug.Log("Reloading");
        gunScript.Reload();
        //Animation
    }
    public void HandleMovementVector(Vector2 moveVector) // Handled through inputHandler event system
    {
        movementVector = moveVector;
    }
}
