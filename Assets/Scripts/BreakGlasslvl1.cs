using UnityEngine;

public class BreakGlasslvl1 : MonoBehaviour
{
    public int glassHP = 3;
    public void OnTriggerEnter(Collider other)
    {
        //when cannon fire cannon ball at glass
        if (other.gameObject.CompareTag("Fire"))
        {
            //destroys the glass
            glassHP -= 1;
            if (glassHP <= 0)
            {
                Destroy(gameObject);
            }
            //destroys cannonball
            Destroy(other.gameObject);
            //or add animation of glass breaking

            //should destroy glass
        }
    }
}
