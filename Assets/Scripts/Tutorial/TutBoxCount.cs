using UnityEngine;

public class TutBoxCount : MonoBehaviour
{
    private int boxAmount = 0;

    void Update()
    {
        if (boxAmount >= 3)
        {

        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Box"))
        {
            boxAmount += 1;
            Destroy(other.gameObject);
            Debug.Log("You have " + boxAmount + " boxes ");
        }
    }
    /*
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Box"))
        {
            boxAmount -= 1;
            Debug.Log("You have " + boxAmount + " boxes ");
        }
    }
    */
}
