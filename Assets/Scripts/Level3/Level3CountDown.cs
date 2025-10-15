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
        if (countingDown <= 0)
        {
            FindFirstObjectByType<SceneTransitionController>().ReloadScene();
        }


        if (countingDown < 60)
        {
            countDown.color = Color.red;
        }

        countingDown = Mathf.Max(countingDown - Time.deltaTime, 0);

        int minutes = Mathf.FloorToInt(countingDown / 60);
        int Seconds = Mathf.FloorToInt(countingDown % 60);

        countDown.text = string.Format ("COUNT DOWN: " + "{0:00}:{1:00}", minutes, Seconds );
    }
}
