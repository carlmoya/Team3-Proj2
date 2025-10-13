using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class Level3CountDown : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI countDown;
    private float countingDown = 180;

    // Update is called once per frame
    void Update()
    {
        if (countingDown > 0)
        {
            countingDown -= Time.deltaTime;
        }
        else if (countingDown < 0)
        {
            countingDown = 0;
            countDown.color = Color.red;
            //gameOver
        }
        /*else if (countingDown > 0 if boss is defected)
        {

        }
        */

        countingDown -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(countingDown / 60);
        int Seconds = Mathf.FloorToInt(countingDown % 60);
        countDown.text = string.Format ("Count Down: " + "{0:00} : {1:00}", minutes, Seconds );
    }
}
