using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{

    [SerializeField] float delayBeforeReload = 1f;
    [SerializeField] ParticleSystem finishEffect;
    ScoreManager scoreManager;

    void Start()
    {
        scoreManager = FindFirstObjectByType<ScoreManager>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        int layerIndex = LayerMask.NameToLayer("Player");

        if (collision.gameObject.layer == layerIndex)
        {
            Debug.Log("You reached the finish line!");

            Invoke("ReloadScene", delayBeforeReload);
            finishEffect.Play();
            scoreManager.addScore(500);
            //SceneManager.LoadScene(0);

        }


    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
