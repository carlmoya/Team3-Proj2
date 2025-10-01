using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class lvl1BIgDInoBite : MonoBehaviour
{
    [SerializeField] private Animator BiteDown;
    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            //BiteDown.SetBool("IsBite", false);
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //BiteDown.SetBool("IsBite", true);
        }
    }
}
