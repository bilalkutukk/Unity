using UnityEngine;

public class Delivery : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    bool hasPackage = false;
    [SerializeField] float destroyDelay = 0.5f;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PackageIceCream") && !hasPackage)
        {
            hasPackage = true;
            Destroy(collision.gameObject, destroyDelay);
            GetComponent<ParticleSystem>().Play();
            Debug.Log("Package Picked Up");
        }
        else if (collision.CompareTag("Customer") && hasPackage)
        {
            hasPackage = false;
            Debug.Log("Package Delivered");
            Destroy(collision.gameObject, destroyDelay);
            GetComponent<ParticleSystem>().Stop();
        }            
    }
}
