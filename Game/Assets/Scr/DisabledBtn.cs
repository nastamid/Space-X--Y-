using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisabledBtn : MonoBehaviour
{

	void Start () {
	    if (PlayerPrefs.GetInt("IsTimeAttack")==1)
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
        else
        {
            gameObject.GetComponent<Button>().interactable = true;
            
        }
	}

}
