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
        FindFirstObjectByType<Pager>().messageQueue.Add("I want to thank you");

        FindFirstObjectByType<Pager>().messageQueue.Add("But now, you're not needed");

        FindFirstObjectByType<Pager>().messageQueue.Add("You were a great pawn");

        FindFirstObjectByType<Pager>().messageQueue.Add("Its too late to stop me");

        FindFirstObjectByType<Pager>().messageQueue.Add("What you've done...");

        FindFirstObjectByType<Pager>().messageQueue.Add("Are you really...");

        FindFirstObjectByType<Pager>().messageQueue.Add("Good...evil?");

        FindFirstObjectByType<Pager>().messageQueue.Add("This machine here");

        FindFirstObjectByType<Pager>().messageQueue.Add("Will cover up the sky");

        FindFirstObjectByType<Pager>().messageQueue.Add("For indeed, LIFE stands for");

        FindFirstObjectByType<Pager>().messageQueue.Add("Lve in FEAR");

        FindFirstObjectByType<Pager>().messageQueue.Add("Do you throw that at me ");

        FindFirstObjectByType<Pager>().messageQueue.Add("Or use that life to get to the machine");

        FindFirstObjectByType<Pager>().messageQueue.Add("Goodbye for now");

        FindFirstObjectByType<Pager>().messageQueue.Add("Oh, I never told you what L.I.F.E means");

        FindFirstObjectByType<Pager>().messageQueue.Add("LIFE - Live in FEAR");

        FindFirstObjectByType<Pager>().messageQueue.Add("This is it. Goodbye");

        StartCoroutine(ShootHazard());
    }

    // Coroutines

    private IEnumerator ShootHazard()
    {
        while (true) // Runs forever unless stopped
        {
            GameObject hazard = Instantiate(oneUseHazard, shootPoint.position, shootPoint.rotation);

            hazard.GetComponent<Rigidbody>().AddForce(transform.forward * 50f, ForceMode.Impulse);

            yield return new WaitForSeconds(3f);
        }
    }

    // Return Methods

    private bool LookingAtPlayer()
    {
        Ray ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            if (hitInfo.collider.CompareTag("Player"))
            {
                return true;
            }
        }

        return false;
    }
}
