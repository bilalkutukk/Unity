using UnityEngine;

public class FinishLine : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collision)
    {
        int layerIndex = LayerMask.NameToLayer("Player");

        if (collision.gameObject.layer == layerIndex)
        {
            Debug.Log("You reached the finish line!");
        }
        // if (collision.tag == "Player")
        // {
        //     Debug.Log("You reached the finish line!");
        // }
    }
}
