using UnityEngine;

public class Level1teleportDoor : MonoBehaviour
{
    private Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.position = new Vector3(-122.6907f, 9.611523f, -109.68f);
        }
        if (other.gameObject.CompareTag("Treasure"))
        {
            other.gameObject.transform.position = new Vector3(-122.6907f, 9.611523f, -109.68f);
        }
    }
}
