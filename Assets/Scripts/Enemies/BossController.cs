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
        FindFirstObjectByType<Pager>().messageQueue.Add("i wanna thank u 4 everything btw");

        FindFirstObjectByType<Pager>().messageQueue.Add("but i have 2 kill u now");

        FindFirstObjectByType<Pager>().messageQueue.Add("u were the best pawn i ever had tho");

        FindFirstObjectByType<Pager>().messageQueue.Add("btw pls don't try 2 stop me");

        FindFirstObjectByType<Pager>().messageQueue.Add("bc its too late now");

        FindFirstObjectByType<Pager>().messageQueue.Add("we were the bad guys the whole time");

        FindFirstObjectByType<Pager>().messageQueue.Add("now watch as i nuke the sun");

        FindFirstObjectByType<Pager>().messageQueue.Add("oh don't destroy my machine btw");

        FindFirstObjectByType<Pager>().messageQueue.Add("i need it for evil");

        FindFirstObjectByType<Pager>().messageQueue.Add("it just takes a while to charge up");

        FindFirstObjectByType<Pager>().messageQueue.Add("i scheduled these in advance");

        FindFirstObjectByType<Pager>().messageQueue.Add("so hopefully i'm not dead");

        FindFirstObjectByType<Pager>().messageQueue.Add("but if i am you'll still get these");

        FindFirstObjectByType<Pager>().messageQueue.Add("okay bye now");

        FindFirstObjectByType<Pager>().messageQueue.Add("oh i never said what L.I.F.E means");

        FindFirstObjectByType<Pager>().messageQueue.Add("it means Live In F Ear");

        FindFirstObjectByType<Pager>().messageQueue.Add("okay bye for real now");

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
