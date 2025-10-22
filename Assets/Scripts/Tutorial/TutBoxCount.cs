using UnityEngine;

public class TutBoxCount : MonoBehaviour
{
    // Fields

    private Pager pager;

    private int boxesDelivered = 0;

    // Methods

    private void Start()
    {
        // Get reference to pager
        pager = FindFirstObjectByType<Pager>();

        pager.messageQueue.Add("Welcome to the tutorial");

        pager.messageQueue.Add("Put 3 boxes in the green bin pls");

        pager.messageQueue.Add("Pick them up with left click");

        pager.messageQueue.Add("Use the scroll wheel for distancing");
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Box"))
        {
            boxesDelivered += 1;

            FindFirstObjectByType<PlayerGrab>().LetGoOfObject(other.transform.GetComponent<Rigidbody>());

            Destroy(other.gameObject);

            if (boxesDelivered == 2)
            {
                pager.messageQueue.Add("1 box left");
            }

            if (boxesDelivered >= 3)
            {
                FindFirstObjectByType<SceneTransitionController>().LoadIntroCutscene();
            }
        }
    }
}
