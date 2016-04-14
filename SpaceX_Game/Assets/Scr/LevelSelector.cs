using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour {

    [Header  ("UI GOs")]
    public GameObject Moon_UI_GO;
    public GameObject Borrelly_UI_GO;
    public GameObject Phobos_UI_GO;
    public GameObject Deimos_UI_GO;
    public GameObject Mars_UI_GO;

    [Header("UI Imgs_ON")]

    public Sprite Moon_SP;
    public Sprite Borrelly_SP;
    public Sprite Phobos_SP;
    public Sprite Deimos_SP;
    public Sprite Mars_SP;



	void Start () {

	}


    public void ShouUpPlanets(int passedLvlNum)
    {

        if (passedLvlNum > 3)
        {
            Moon_UI_GO.GetComponent<Image>().sprite = Moon_SP;
            Moon_UI_GO.GetComponent<Button>().interactable = true;
        }
        if (passedLvlNum > 6)
        {
            Borrelly_UI_GO.GetComponent<Image>().sprite = Borrelly_SP;
            Borrelly_UI_GO.GetComponent<Button>().interactable = true;
        }
        if (passedLvlNum > 9)
        {
            Phobos_UI_GO.GetComponent<Image>().sprite = Phobos_SP;
            Phobos_UI_GO.GetComponent<Button>().interactable = true;
        }
        if (passedLvlNum > 12)
        {
            Deimos_UI_GO.GetComponent<Image>().sprite = Deimos_SP;
            Deimos_UI_GO.GetComponent<Button>().interactable = true;
        }
        if (passedLvlNum > 15)
        {
            Mars_UI_GO.GetComponent<Image>().sprite = Mars_SP;
            Mars_UI_GO.GetComponent<Button>().interactable = true;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
