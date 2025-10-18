using UnityEngine;

public class Fallingthoughlevel2 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // player gets caught and teleported back
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.position = new Vector3(745.8549f, 24.5f, 302.66f);
        }
    }
}
