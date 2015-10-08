using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	// Use this for initialization


    public static UIManager instance = null;
    public GameObject PausePanel;
    public GameObject LevelControllerGO;
    public GameObject setGameOverPanel;
    public GameObject GameOverPanel;
    public GameObject PauseBTN;

    LevelController levelController;
	void Start () {

        if (instance!=null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }

        levelController = LevelControllerGO.GetComponent<LevelController>();
        GameOverPanel = setGameOverPanel;
	}
	


    public void RestartLevel()
    {
        GlobalSettings.GameIsOver = false;

        levelController.RestartLevel();
        ResumeGame();
        GameOverPanel.SetActive(false);

    }


    public void PauseGame()
    {
        Time.timeScale = 0;
        PausePanel.SetActive(true);
        GlobalSettings.GameIsPaused = true;
        PauseBTN.SetActive(false);
    }

    public void ResumeGame()
    {

        Time.timeScale = 1;
        PausePanel.SetActive(false);
        GlobalSettings.GameIsPaused = false;
        PauseBTN.SetActive(true);



    }

    public void GoToHome()
    {

        Time.timeScale = 1;
        GlobalSettings.GameIsPaused = false;
        GameOverPanel.SetActive(false);
        PausePanel.SetActive(false);
        Application.LoadLevel("Menu");

    }


    public  void GameOver()
    {
        GlobalSettings.GameIsOver = true;
            GameOverPanel.SetActive(true);
            PauseBTN.SetActive(false);
    }
}
