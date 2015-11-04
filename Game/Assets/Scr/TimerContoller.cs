using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class TimerContoller : MonoBehaviour {
    int isTimeAttack;
    public GameObject TimerText;
    Text timerTxt;
    public static bool FirstTapHappend = false;
    public float elapsedTime = 0;

    System.DateTime StartTime;
    System.TimeSpan currentTime;

    public static string ElapsedTime;

	void Start () {
        isTimeAttack = PlayerPrefs.GetInt("IsTimeAttack");
        FirstTapHappend = false;
        if (isTimeAttack == 1)
        {
            TimerText.SetActive(true);
        }
        else
        {
            if (TimerText.activeInHierarchy)
            {
                TimerText.SetActive(false);
            }
        }
        timerTxt = TimerText.GetComponent<Text>();


	}

    bool beenHere = false;
    public void Update()
    {
        if (!FirstTapHappend) return;

        if (!beenHere)
        {
            StartTime = System.DateTime.Now;
            beenHere = true;
        }
        if (GlobalSettings.GameIsOver) return;

        currentTime = System.DateTime.Now - StartTime;
        ElapsedTime = currentTime.Minutes + ":" + currentTime.Seconds;
        timerTxt.text = ElapsedTime;
        //+":" + currentTime.Milliseconds;
    }


}
