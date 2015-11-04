using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeAttackGameOverScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {

        if (PlayerPrefs.GetInt("IsTimeAttack") == 1)
            gameObject.SetActive(true);
        else
            gameObject.SetActive(false);


        GetComponent<Text>().text = "Time-" + TimerContoller.ElapsedTime + "/Level-" + LevelController.CurrentLevelNum;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
