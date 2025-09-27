using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class lvl1Keycard : MonoBehaviour
{
    [SerializeField] private Animator opengate;
    public void OnTriggerEnter(Collider other)
    {
        
        //when cannon fire cannon ball at glass
        if (other.gameObject.CompareTag("keycard"))
        {
            //plays animation of gate opening
            opengate.SetBool("lvl1OpenGate", true);
        }
    }
}
