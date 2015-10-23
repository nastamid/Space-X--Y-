using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class StartGame : MonoBehaviour {

    public GameObject StartButton;
    public GameObject CreditsPanel;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void GoToGame()
    {
        StartButton.GetComponent<Button>().transform.GetChild(0).GetComponent<Text>().text = "Loading...";
        Application.LoadLevel("SpaceX_Game");
    }

    public void GoToCredits()
    {
        CreditsPanel.SetActive(true);

    }
    public void HideCredits()
    {
        if(CreditsPanel.activeInHierarchy)
             CreditsPanel.SetActive(false);
    }
}
