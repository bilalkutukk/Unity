using System;
using System.Data.Common;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float boostSpeed = 20f;
    [SerializeField] float baseSpeed = 15f;

    InputAction moveAction;
    Rigidbody2D rb2D;
    Vector2 moveVector;
    SurfaceEffector2D surfaceEffector2D;
    public bool isOnGround = false;

    void Start()
    {
        enableControls();
        moveAction = InputSystem.actions.FindAction("Move");
        rb2D = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindFirstObjectByType<SurfaceEffector2D>();
    }

    void Update()
    {   
        if (!isOnGround)
        {
            rotatePlayer();
            boostPlayer();
        }
    }

    void rotatePlayer()
    {
        
        moveVector = moveAction.ReadValue<Vector2>();

        if (moveVector.x < 0)
            rb2D.AddTorque(torqueAmount);
        else if (moveVector.x > 0)
            rb2D.AddTorque(-torqueAmount);

    }

    void boostPlayer()
    {
        if (moveVector.y > 0)
            surfaceEffector2D.speed = boostSpeed;
        else
            surfaceEffector2D.speed = baseSpeed;
    }

    public void disableControls()
    {
        isOnGround = true;
    }

    void enableControls()
    {
        isOnGround = false;
    }
}
