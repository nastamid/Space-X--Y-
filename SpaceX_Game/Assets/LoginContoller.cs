using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoginContoller : MonoBehaviour {
    public Text NameInput;
    public static string nameScore = "";
    public static bool isSAved = false;
    public Text LeaderBoardText;
    void Start()
    {
       // PlayerPrefs.DeleteAll();
    }


    public void SaveName ()
    {

        if (!isSAved)
        {
            nameScore = NameInput.text;
            if (nameScore == "") return;
            isSAved = true;
            StartGame.instance.StartTimeAttack();
        }


    }

    public void ShowLeaderBoard()
    {
        
        LeaderBoardText.text = PlayerPrefs.GetString("PlayerScores");
        
    }


}
