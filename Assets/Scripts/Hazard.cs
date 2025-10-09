using UnityEngine;

public class Hazard : MonoBehaviour
{
    // Trigger Methods

    private void OnTriggerEnter(Collider other)
    {
        // Check if other object has a health component
        if (other.gameObject.TryGetComponent(out HealthBase otherHealth))
        {
            otherHealth.Modify(-1);
        }
    }
}
