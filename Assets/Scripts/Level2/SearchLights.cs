using UnityEngine;

public class SearchLights : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // player gets caught and teleported back
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.position = new Vector3(745.66f, 18.27f, 302.85f);
        }
    }
}
