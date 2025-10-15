using System.Collections;
using UnityEngine;

public class BossController : MonoBehaviour
{
    // Fields

    public GameObject oneUseHazard;

    public Transform shootPoint;

    // Methods

    private void Start()
    {
        StartCoroutine(ShootHazard());
    }

    // Coroutines

    private IEnumerator ShootHazard()
    {
        while (true) // Runs forever unless stopped
        {
            GameObject hazard = Instantiate(oneUseHazard, shootPoint.position, shootPoint.rotation);

            hazard.GetComponent<Rigidbody>().AddForce(transform.forward * 50f, ForceMode.Impulse);

            //hazard.GetComponent<Rigidbody>().AddForce(transform.up * 10f, ForceMode.Impulse);

            yield return new WaitForSeconds(3f);
        }
    }
}
