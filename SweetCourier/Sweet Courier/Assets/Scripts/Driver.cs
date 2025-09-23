using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Driver : MonoBehaviour
{
    [SerializeField] float currentSpeed;
    [SerializeField] float steerSpeed;
    [SerializeField] float boostSpeed;
    [SerializeField] float regularSpeed;
    [SerializeField] float destroyDelay = 0.5f;
    [SerializeField] TMP_Text boostText;



    void Start()
    {
        boostText.gameObject.SetActive(false);
        currentSpeed = regularSpeed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boost") && currentSpeed != boostSpeed)
        {
            Destroy(collision.gameObject, destroyDelay);
            currentSpeed = boostSpeed;
            Debug.Log("Speed Boosted!");
            boostText.gameObject.SetActive(true);
        }      
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        currentSpeed = regularSpeed;
        Debug.Log("Speed Normalized");
        boostText.gameObject.SetActive(false);
    }

    void Update()
    {
        float move = 0f;
        float steer = 0f;

        if (Keyboard.current.wKey.isPressed)
        {
            move = 1f;
        }
        else if (Keyboard.current.sKey.isPressed)
        {
            move = -1f;
        }

        if (Keyboard.current.aKey.isPressed)
        {
            steer = 1f;
        }
        else if (Keyboard.current.dKey.isPressed)
        {
            steer = -1f;
        }

        float moveAmount = move * currentSpeed * Time.deltaTime;
        float steerAmount = steer * steerSpeed * Time.deltaTime;

        transform.Translate(0, moveAmount, 0);
        transform.Rotate(0, 0, steerAmount);
    }
}