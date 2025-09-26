using UnityEngine;

public class Cannon : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        //when player places cannon ball near/in cannon
        if (other.gameObject.CompareTag("cannon"))
        {
            //destroys cannon
            Destroy(other.gameObject);
            //add animation of the cannon fireing cannon with tag fire

            //should destroy glass
        }
    }
}
