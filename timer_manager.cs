using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class timer_manager : MonoBehaviour
{
    public bool hour, minute, second, milisecond;
    [Space]
    public Text time_txt;
    [Space]
    public MyEnum mode;
    [Space]
    public int start_hour;
    public int start_minute;
    public int start_second;
    [Space]

    public int end_hour;
    public int end_minute;
    public int end_second;

    public enum MyEnum
    {
        increase_time,
        decrease_time
    }

    Coroutine cr = null;
    void Start()
    {
        //im starting my timer for test here
        
        int s = start_second + (start_minute * 60) + (start_hour * 3600);
        int e = end_second + (end_minute * 60) + (end_hour * 3600);
        start_timer(s, e, mode);
    }


    //you can start timer with this function
    public void start_timer(int start_all_seconds, int end_all_seconds, MyEnum time_mode)
    {
        if (cr != null)
        {
            StopCoroutine(cr);
            cr = null;
        }
        if (time_mode == MyEnum.increase_time)
        {
            cr = StartCoroutine(increase_time(start_all_seconds, end_all_seconds));
        }
        else
        {
            cr = StartCoroutine(decrease_time(start_all_seconds, end_all_seconds));
        }

    }

    IEnumerator increase_time(int s, int e)
    {
        s = s * 10;
        e = e * 10;

        while (true)
        {
            if (s < e)
            {
                int ss = Mathf.FloorToInt(s / 10);

                int hours = Mathf.FloorToInt(ss / 3600);
                hours = Mathf.FloorToInt(hours % 24);

                int minutes = Mathf.FloorToInt(ss / 60);
                minutes = Mathf.FloorToInt(minutes % 60);

                int seconds = Mathf.FloorToInt(ss % 60);

                int milisec = Mathf.FloorToInt(s % 10);
                milisec = milisec * 10;

                show_time(hours, minutes, seconds, milisec);

                yield return new WaitForSeconds(0.1f);
                s++;
            }
            else
            {
                int ss = Mathf.FloorToInt(e / 10);

                int hours = Mathf.FloorToInt(ss / 3600);
                hours = Mathf.FloorToInt(hours % 24);

                int minutes = Mathf.FloorToInt(ss / 60);
                minutes = Mathf.FloorToInt(minutes % 60);

                int seconds = Mathf.FloorToInt(ss % 60);

                int milisec = 0;

                show_time(hours, minutes, seconds, milisec);

                On_End();
                yield break;
            }
        }
    }

    IEnumerator decrease_time(int s, int e)
    {
        s = s * 10;
        e = e * 10;

        while (true)
        {
            if (s > e)
            {
                int ss = Mathf.FloorToInt(s / 10);

                int hours = Mathf.FloorToInt(ss / 3600);
                hours = Mathf.FloorToInt(hours % 24);

                int minutes = Mathf.FloorToInt(ss / 60);
                minutes = Mathf.FloorToInt(minutes % 60);

                int seconds = Mathf.FloorToInt(ss % 60);

                int milisec = Mathf.FloorToInt(s % 10);
                milisec = milisec * 10;

                show_time(hours, minutes, seconds, milisec);

                yield return new WaitForSeconds(0.1f);  
                s--;
            }
            else
            {
                int ss = Mathf.FloorToInt(e / 10);

                int hours = Mathf.FloorToInt(ss / 3600);
                hours = Mathf.FloorToInt(hours % 24);

                int minutes = Mathf.FloorToInt(ss / 60);
                minutes = Mathf.FloorToInt(minutes % 60);

                int seconds = Mathf.FloorToInt(ss % 60);

                int milisec = 0;

                show_time(hours, minutes, seconds, milisec);
                
                On_End();
                yield break;
            }
        }
    }

    void show_time(int h, int m, int s, int ms)
    {
        string t = "";
        if (hour)
        {
            t = t + h;
        }
        if (minute)
        {
            if (t == "")
            {
                t = t + m;
            }
            else
            {
                t = t + " : " + m;
            }
            
        }
        if (second)
        {
            if (t == "")
            {
                t = t + s;
            }
            else
            {
                t = t + " : " + s;
            }
            
        }
        if (milisecond)
        {
            if (t == "")
            {
                if (ms == 0)
                {
                    t = t + "00";
                }
                else
                {
                    t = t + ms;
                }

            }
            else
            {
                if (ms == 0)
                {
                    t = t + " : " + "00";
                }
                else
                {
                    t = t + " : " + ms;
                }
            }
          

        }
        time_txt.text = t;
    }


    //end event
    // add your code here in this function
    void On_End()
    {
        Debug.Log("On_End Timer");
        if (cr != null)
        {
            StopCoroutine(cr);
            cr = null;
        }


    }
}
