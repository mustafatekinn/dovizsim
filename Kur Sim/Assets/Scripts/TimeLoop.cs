using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeLoop : MonoBehaviour
{
    public int Seconds;
    public static int Clock;
    public string Time;
    void Start()
    {
        StartCoroutine(Timer());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Sleep();
        }
        Clock = Seconds;
    }


    IEnumerator Timer()
    {
        while (true)
        {
            if (Seconds >= 1440)
            {
                Seconds = 0;
            }
            Seconds++;
            Time = (Seconds / 60).ToString("00") + ";" + ((Seconds % 60).ToString("00"));
            yield return new WaitForSeconds(1);
        }
    }

    public void Sleep()
    {
        Seconds += 300;
    }
}