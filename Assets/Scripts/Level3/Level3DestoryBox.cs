using UnityEngine;

public class Level3DestoryBox : MonoBehaviour
{
    //Level3MovingBox m_MovingBox;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Box"))
        {
            Destroy(other.gameObject);
        }
    }
}
