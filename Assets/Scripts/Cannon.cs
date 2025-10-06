using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Cannon : MonoBehaviour
{
    // Fields

    public Transform shootPoint;

    // Methods

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out CannonBall cannonBall))
        {
            PlayerGrab playerGrab = FindFirstObjectByType<PlayerGrab>();

            playerGrab.LetGoOfObject(collision.transform.GetComponent<Rigidbody>());

            collision.transform.position = shootPoint.position;

            collision.transform.rotation = shootPoint.rotation;

            cannonBall.Fire();
        }
    }
}
