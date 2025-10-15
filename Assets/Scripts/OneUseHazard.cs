using UnityEngine;

public class OneUseHazard : MonoBehaviour
{
    // Collision Methods

    private void OnCollisionEnter(Collision collision)
    {
        // If the other object has health
        if (collision.gameObject.TryGetComponent(out HealthBase otherHealth))
        {
            // Damage the other object
            otherHealth.Modify(-1);

            // Destroy this object
            Destroy(gameObject);
        }
    }
}
