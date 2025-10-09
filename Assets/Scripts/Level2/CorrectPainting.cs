using UnityEngine;

public class CorrectPainting : MonoBehaviour
{
    public GameObject destroyBlock;
    public GameObject showPainting;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        showPainting.SetActive(false);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.position = new Vector3(746f, 19.85f, 302.52f);
            //showPainting.SetActive(true);
            Destroy(destroyBlock);
        }
    }
}
