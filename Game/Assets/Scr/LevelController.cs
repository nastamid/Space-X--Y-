using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    public static LevelController Instance = null;
    public GameObject ToLandObject;
    public float smooth = 2.0f;

    int currentLevelNum;
    GameObject currentLevel;
    public GameObject AlienObjects;
    public GameObject CricleAlien;

    public GameObject FadeImg;
    public float SmoothFade = 2.0f;

    public GameObject Moon_GO;
    public GameObject Asteroid_GO;
    public GameObject Mars_GO;

    public GameObject LevelText;



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
        LevelText.GetComponent<Text>().text = "LEVEL " + number;
        if (number > 3 && number <= 6)
            SetPlanet("Moon");
        else if (number > 6 && number <= 8)
            SetPlanet("Asteroid");
        else if (number > 8 && number <= 11)
            SetPlanet("Mars");


        print(number);
        currentLevelNum = number;
        currentLevel = Instantiate(LevelList[number], Vector3.zero, Quaternion.identity) as GameObject;
    }

    private void SetPlanet(string planetName)
    {
        switch (planetName)
        {
            case "Moon":
                ToLandObject.transform.Find("Sphere").GetComponent<Renderer>().enabled = false;
                Moon_GO.SetActive(true);
                break;
            case "Asteroid":
                Moon_GO.SetActive(false);
                Asteroid_GO.SetActive(true);
                break;
            case "Mars":
                Asteroid_GO.SetActive(false);
                Mars_GO.SetActive(true);
                break;
        }
    }

    public void GoToNextLevel()
    {
        LoadNextLevel();
        //GoingToNextLevel = true;
    }



    void LoadNextLevel()
    {
        Destroy(currentLevel);
        print("currentLevelNum: " + currentLevelNum);
        LoadLevel(currentLevelNum += 1);

        //RotatePlanetAnim();
    }

    void RotatePlanetAnim()
    {
      Transform toLandObject = ToLandObject.transform;
        Quaternion target = Quaternion.Euler(90, 0, 0);
       toLandObject.rotation = Quaternion.Slerp(toLandObject.rotation, target, Time.deltaTime * smooth);
    }


    public void RestartLevel()
    {
        Destroy(currentLevel);
        LoadLevel(currentLevelNum);
        print("REstarting");

    }
}
