using UnityEngine;

public class CannonBall : MonoBehaviour
{
    // Fields

    private Rigidbody rb;

    private bool dealDamage = false;

    // Methods

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Fire()
    {
        rb.AddForce(transform.forward * 50f, ForceMode.Impulse);

        dealDamage = true;
    }

    // Collision Methods

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.GetComponent<Cannon>() != null) { return; }

        if (dealDamage == true)
        {
            // Check if other object has a health component
            if (collision.gameObject.TryGetComponent(out HealthBase otherHealth))
            {
                otherHealth.Modify(-1);
            }

            dealDamage = false;
        }
    }
}
