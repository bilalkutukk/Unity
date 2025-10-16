using System;
using System.Data.Common;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float boostSpeed = 20f;
    [SerializeField] float baseSpeed = 15f;

    InputAction moveAction;
    Rigidbody2D rb2D;
    Vector2 moveVector;
    SurfaceEffector2D surfaceEffector2D;
    ScoreManager scoreManager;
    public bool isOnGround = false;
    float previousRotation = 0f;
    float totalRotation = 0f;
    int flipCount = 0;


    void Start()
    {
        enableControls();
        moveAction = InputSystem.actions.FindAction("Move");
        rb2D = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindFirstObjectByType<SurfaceEffector2D>();
        scoreManager = FindFirstObjectByType<ScoreManager>();
    }

    void Update()
    {   
        if (!isOnGround)
        {
            rotatePlayer();
            boostPlayer();
            calculateFlips();
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

    void calculateFlips()
    {
        float currentRotation = transform.rotation.eulerAngles.z;

        totalRotation += Mathf.DeltaAngle(previousRotation, currentRotation);

        if (Mathf.Abs(totalRotation) >= 340f)
        {
            flipCount++;
            totalRotation = 0f;
            Debug.Log("Flips: " + flipCount);
            scoreManager.addScore(100);
        }

        previousRotation = currentRotation;
    }
    
    public void activatePowerup(PowerupSO powerup)
    {
        switch (powerup.GetPowerupType)
        {
            case "speed":
                baseSpeed += powerup.GetValueChange;
                boostSpeed += powerup.GetValueChange;
                break;
            case "torque":
                torqueAmount += powerup.GetValueChange;
                break;
            default:
                break;
        }
    }
}
