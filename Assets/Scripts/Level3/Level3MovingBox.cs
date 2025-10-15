using System.Collections;
using UnityEngine;

public class Level3MovingBox : MonoBehaviour
{
    [SerializeField]

    public GameObject _Box;
    //
    Vector3 ImpulseVectorLR = new Vector3(0f, 0f, 43.24f);
    IEnumerator Box()
    {
        //right to left
        Vector3 spawnPosition = Vector3.zero;

        while (true)
        {
            yield return new WaitForSeconds(6f);

            //spawning
            spawnPosition.x = -27.39f;
            spawnPosition.y = 4f;
            spawnPosition.z = -41.53f;
            GameObject Box = Instantiate(_Box, spawnPosition, Quaternion.identity);
            Box.GetComponent<Rigidbody>().AddForce(ImpulseVectorLR, ForceMode.VelocityChange);

        }
    }
    void Start()
    {
        StartCoroutine(Box());
        GetComponent<Rigidbody>();

    }
}
