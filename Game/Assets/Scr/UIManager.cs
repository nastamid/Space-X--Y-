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
    public GameObject LevelSelectorPanel;
    public GameObject AllStages;
    public GameObject LevelText;

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

    public void GoToLevelSelector()
    {
        if (GameOverPanel.activeInHierarchy)
            GameOverPanel.SetActive(false);
        if (LevelText.activeInHierarchy)
            LevelText.SetActive(false);
        if (LevelController.Instance.FinishScreenPanel_GO.activeInHierarchy)
            LevelController.Instance.FinishScreenPanel_GO.SetActive(false);
        LevelController.Instance.DestoryCurrentLevel();
        Time.timeScale = 1;
        PausePanel.SetActive(false);
        LevelSelectorPanel.SetActive(true);
        disableActiveStage();

    }

    void disableActiveStage()
    {
        Transform parent = AllStages.transform;
        for (int i = 0; i < parent.childCount; i++)
        {
            if (parent.GetChild(i).gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().enabled == true)
           {
               parent.GetChild(i).gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
           }
        }
        if (LevelController.Instance.Platform_GO.activeInHierarchy)
        {
            LevelController.Instance.Platform_GO.SetActive(false);
        }
    }


}
