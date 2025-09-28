using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Lvl1OpenBackDoor : MonoBehaviour
{
    [SerializeField] private Animator opendoor;
    public void OnTriggerEnter(Collider other)
    {

        //when cannon fire cannon ball at glass
        if (other.gameObject.CompareTag("key"))
        {
            //plays animation of gate opening
            opendoor.SetBool("OpenBackDoor", true);
        }
    }
}
