using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    public GameObject LevelSelectorPanel;

    public static LevelController Instance = null;
    public GameObject Earth_GO;
    public float smooth = 2.0f;

    int currentLevelNum;
    public static int CurrentLevelNum;

    GameObject currentLevel;
    public GameObject AlienObjects;
    public GameObject CricleAlien;

    public GameObject FadeImg;
    public float SmoothFade = 2.0f;

    public GameObject Platform_GO;
    public GameObject Moon_GO;
    public GameObject Asteroid_GO;
    public GameObject Phobos_GO;
    public GameObject Deimos_GO;
    public GameObject Mars_GO;

    public GameObject FinishScreenPanel_GO;
    public GameObject FireWorks_GO;


    public GameObject LevelText;
    public GameObject FinishLevelAndText;

    string levelTxt;

    // Use this for initialization

    public List<GameObject> LevelList;


    void Start()
    {
        LoadLevel(1);
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            for (int i = 0; i < 10; i++)
            {
                Instantiate(AlienObjects, new Vector3(0, 11, 0), Quaternion.identity);
            }
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            for (int i = 0; i < 10; i++)
            {

                Instantiate(CricleAlien, new Vector3(Random.Range(-2, 2), 11 + Random.Range(1, 5), Random.Range(-2, 2)), Quaternion.identity);
            }
        }

        if(Input.GetKey(KeyCode.Space))
        {
            //RotatePlanetAnim();
        }
    }


    public void LoadLevel(int number)
    {

        if (PlayerPrefs.GetInt("PassedLevel") < number)
        {
            print("passed LEvel:" + PlayerPrefs.GetInt("PassedLevel"));
            PlayerPrefs.SetInt("PassedLevel", number);
        }


        if (GlobalSettings.GameIsPaused) GlobalSettings.GameIsPaused = false;
        if (GlobalSettings.GameIsOver) GlobalSettings.GameIsOver = false;
        if (currentLevel != null)
            Destroy(currentLevel);
        if (!LevelSelectorPanel.activeInHierarchy)
        {
            LevelSelectorPanel.SetActive(false);
        }
        if (!UIManager.instance.PauseBTN.activeInHierarchy)
        {
            UIManager.instance.PauseBTN.SetActive(true);
        }
        if (!UIManager.instance.LevelText.activeInHierarchy)
        {
            UIManager.instance.LevelText.SetActive(true);
        }
        if (UIManager.instance.LevelSelectorPanel.activeInHierarchy)
        {
            UIManager.instance.LevelSelectorPanel.SetActive(false);
        }

       
        

        if (number>3)
        {
            Earth_GO.transform.position = new Vector3(Earth_GO.transform.position.x,-10.45f,Earth_GO.transform.position.z);
        }
        if (number>3 && (Platform_GO.activeInHierarchy ==true))
        {
            Platform_GO.SetActive(false);
        }
        else if (number<=3&&(Platform_GO.activeInHierarchy==false))
        {
            Platform_GO.SetActive(true);
        }
        if (number<=3)
        {
             levelTxt = "Earth - " + number;
             if (!Earth_GO.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().enabled)
             {
                 Earth_GO.transform.position = new Vector3(Earth_GO.transform.position.x, -10.80f, Earth_GO.transform.position.z);
                 Earth_GO.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().enabled = true;
             }
             if (!Platform_GO.activeInHierarchy)
                 Platform_GO.SetActive(true);
        }
        if (number > 3 && number <= 6)
        {
            levelTxt = "Moon - " + (number-3);
            SetPlanet("Moon");
        }
        else if (number > 6 && number <= 9)
        {
            levelTxt = "Comet Borrelly - " + (number-6);
            SetPlanet("Asteroid");

        }
        else if (number > 9 && number <= 12)
        {
            levelTxt = "Phobos - " + (number-9);
            SetPlanet("Phobos");
        }
        else if (number > 12 && number <= 15)
        {
            levelTxt = "Deimos - " + (number-12);
            SetPlanet("Deimos");
        }
        else if (number > 15 && number <= 18)
        {
            levelTxt = "Mars - " + (number-15);
            SetPlanet("Mars");
        }
        LevelText.GetComponent<Text>().text = levelTxt;

        currentLevelNum = number;
        CurrentLevelNum = currentLevelNum;
        currentLevel = Instantiate(LevelList[number], Vector3.zero, Quaternion.identity) as GameObject;

       
    }

    private void SetPlanet(string planetName)
    {
        switch (planetName)
        {
            case "Moon":
                Earth_GO.transform.GetChild(0).GetComponent<Renderer>().enabled = false;
                Moon_GO.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = true;
                break;
            case "Asteroid":
                Moon_GO.transform.GetChild(0).GetComponent<Renderer>().enabled = false;
                Asteroid_GO.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = true;
                break;
            case "Phobos":
                Asteroid_GO.transform.GetChild(0).GetComponent<Renderer>().enabled = false;
                Phobos_GO.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = true;
                break;
            case "Deimos":
                Phobos_GO.transform.GetChild(0).GetComponent<Renderer>().enabled = false;
                Deimos_GO.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = true;
                break;
            case "Mars":
                Deimos_GO.transform.GetChild(0).GetComponent<Renderer>().enabled = false;
                Mars_GO.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = true;
                break;
        }
    }

    public void GoToNextLevel()
    {
        LoadNextLevel();
    }



    void LoadNextLevel()
    {
        if (currentLevelNum + 1 > 18)
        {
            FinishTheGame();
            return;
        }
        Destroy(currentLevel);
        LoadLevel(currentLevelNum += 1);
    }

    void RotatePlanetAnim()
    {
      Transform toLandObject = Earth_GO.transform;
        Quaternion target = Quaternion.Euler(90, 0, 0);
       toLandObject.rotation = Quaternion.Slerp(toLandObject.rotation, target, Time.deltaTime * smooth);
    }


    public void RestartLevel()
    {
        Destroy(currentLevel);
        LoadLevel(currentLevelNum);

    }

    public void DestoryCurrentLevel()
    {
        Destroy(currentLevel);
    }

    public void FinishTheGame()
    {
        FinishLevelAndText.GetComponent<Text>().text = "Time-" + TimerContoller.ElapsedTime + "/Level-" + LevelController.CurrentLevelNum; 

        FinishScreenPanel_GO.SetActive(true);
        //FireWorks_GO.SetActive(true);
        if (LevelText.activeInHierarchy)
            LevelText.SetActive(false);
        if (UIManager.instance.PauseBTN.activeInHierarchy)
            UIManager.instance.PauseBTN.SetActive(false);
    }

}
