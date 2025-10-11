using UnityEngine;
using UnityEngine.SceneManagement;

public class FloorDetect : MonoBehaviour
{
    [SerializeField] float delayBeforeReload = 1f;
    [SerializeField] ParticleSystem floorEffect;
    PlayerController playerController;

    void Start()
    {
        playerController = FindFirstObjectByType<PlayerController>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        int layerIndex = LayerMask.NameToLayer("Floor");

        if (collision.gameObject.layer == layerIndex)
        {
            Debug.Log("Player is on the floor.");
            playerController.disableControls();
            Invoke("ReloadScene", delayBeforeReload);
            floorEffect.Play();

            //SceneManager.LoadScene(0);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
    
}

