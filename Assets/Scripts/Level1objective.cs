using UnityEngine;
using TMPro;
public class Level1objective : MonoBehaviour
{
    //public GameObject mission1;
    //public GameObject mission2;
    //public GameObject mission3;
    public TMP_Text missionText1;
    public TMP_Text missionText2;
    public TMP_Text missionText3;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        missionText1.color = Color.red;
        missionText2.color = Color.red;
        missionText3.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        //other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Treasure")
    }
    public void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Cannonball"))
        {
            missionText1.color = Color.green;
        }
        if(other.gameObject.TryGetComponent(out CannonBall cannonBall))
        {
            missionText2.color = Color.green;
        }
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Treasure"))
        {
            missionText3.color = Color.green;
        }

    }
}
