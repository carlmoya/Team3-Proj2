using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Cannon : MonoBehaviour
{
    [SerializeField] private Animator fireCannon;
    public void OnTriggerEnter(Collider other)
    {
        //when player places cannon ball near/in cannon
        if (other.gameObject.CompareTag("Cannonball"))
        {
            
            //add animation of the cannon fireing cannon with tag fire
            fireCannon.SetBool("CannonLoaded", true);
            //destroys cannon
            Destroy(other.gameObject);
            //should destroy glass
        }
    }
}
