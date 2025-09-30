using UnityEngine;

public class BreakGlasslvl1 : MonoBehaviour
{
    private int glassHP = 1;
    public void OnTriggerEnter(Collider other)
    {
        //when cannon fire cannon ball at glass
        if (other.gameObject.CompareTag("Fire"))
        {
            //destroys the glass
            glassHP -= 1;
            Debug.Log("glass Hp " +  glassHP);
            if (glassHP <= 0)
            {
                Debug.Log("glass is destroyed");
                Destroy(gameObject);
            }
            //destroys cannonball
            Destroy(other.gameObject);
            //or add animation of glass breaking

            //should destroy glass
        }
    }
}
