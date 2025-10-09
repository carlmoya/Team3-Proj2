using UnityEngine;

public class PickupController : MonoBehaviour
{
    // Fields

    private AudioSource audioSource;

    // Methods

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Pickup()
    {
        audioSource.Play();

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;

        Invoke(nameof(Despawn), 1.5f);
    }

    private void Despawn()
    {
        Destroy(gameObject);
    }

    // Triggers

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup();
        }
    }
}
