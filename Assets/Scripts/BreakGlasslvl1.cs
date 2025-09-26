using UnityEngine;

public class BreakGlasslvl1 : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        //when cannon fire cannon ball at glass
        if (other.gameObject.CompareTag("fire"))
        {
            //destroys the glass
            Destroy(gameObject);
            //or add animation of glass breaking

            //should destroy glass
        }
    }
}
