using UnityEngine;

public class PowerupManager : MonoBehaviour
{

    [SerializeField] PowerupSO powerup;

    PlayerController playerController;

    void Start()
    {
        playerController = FindFirstObjectByType<PlayerController>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        int layerIndex = LayerMask.NameToLayer("Player");

        if (collision.gameObject.layer == layerIndex)
        {
            playerController.activatePowerup(powerup);
        }

        Debug.Log("Powerup collected: " + powerup.powerupType);
        Destroy(gameObject);
    }
}
