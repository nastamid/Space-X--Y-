using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ImgDisabledEffect : MonoBehaviour {


    void Start()
    {
        Color textColor = gameObject.GetComponent<Image>().color;
        if (PlayerPrefs.GetInt("IsTimeAttack") == 1)
        {
            gameObject.GetComponent<Image>().color = new Color(textColor.r, textColor.g, textColor.b, 0.5f);
        }
        else
        {
            gameObject.GetComponent<Image>().color = new Color(textColor.r, textColor.g, textColor.b, 1);
        }
    }

}
