using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextDisabledEffect : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Color textColor = gameObject.GetComponent<Text>().color;
        if (PlayerPrefs.GetInt("IsTimeAttack") == 1)
        {
            gameObject.GetComponent<Text>().color = new Color(textColor.r, textColor.g, textColor.b, 0.5f);
        }
        else
        {
            gameObject.GetComponent<Text>().color = new Color(textColor.r, textColor.g, textColor.b, 1);
        }
	}
	

}
