using System.Collections;
using UnityEngine;

public class Level3SodaSpawn : MonoBehaviour
{
    [SerializeField]

    public GameObject _Soda;
    public int SodaCount = 0;
    Vector3 ImpulseVectorLR = new Vector3(0f, 0f, 0f);
    IEnumerator Soda()
    {
        //right to left
        Vector3 spawnPosition = Vector3.zero;

        while (true)
        {
            if (SodaCount >= 0)
            {
                yield return new WaitForSeconds(10f);
                SodaCount += 1;
                //spawning
                spawnPosition.x = 40.43f;
                spawnPosition.y = 1.07f;
                spawnPosition.z = -8.85f;
                GameObject Soda = Instantiate(_Soda, spawnPosition, Quaternion.identity);
                Soda.GetComponent<Rigidbody>().AddForce(ImpulseVectorLR, ForceMode.Impulse);
            }
            else
            {
                Debug.Log("COllect Soda");
            }


        }
    }
    void Start()
    {
        StartCoroutine(Soda());
        GetComponent<Rigidbody>();

    }
}
