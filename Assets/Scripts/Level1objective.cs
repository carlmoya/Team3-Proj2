using UnityEngine;
using TMPro;
public class Level1objective : MonoBehaviour
{
    PlayerGrab grabTreasure;
    CannonBall fires;
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
    public void OnTriggerStay(Collider other)
    {
        // when player find cannon ball
        if (other.gameObject.CompareTag("Player"))
        {
            missionText1.color = Color.green;
        }
        // when player brings cannon to the treasure room
        if (other.gameObject.CompareTag("Cannon"))
        {
            missionText2.color = Color.green;
        }

    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Vent"))
        {
            //when player open vent
            missionText3.color = Color.green;
        }
    }
}
