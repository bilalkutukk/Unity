using UnityEngine;

public class FloorDetect : MonoBehaviour
{
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        int layerIndex = LayerMask.NameToLayer("Floor");

        if (collision.gameObject.layer == layerIndex)
        {
            Debug.Log("Player is on the floor.");
        }
        // if (collision.tag == "Ground")
        // {
        //     Debug.Log("Player is on the ground.");
        // }
    }
}
