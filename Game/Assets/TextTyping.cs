using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class TextTyping : MonoBehaviour {

	// Use this for initialization
    public float typeTimeInterval;
    Text CreditsText;
	void Start () {
          CreditsText = gameObject.GetComponent<Text>();


	}


    IEnumerator typeText()
    {

        for (int i = 0; i < CreditsText.text.Length; i++)
        {
            CreditsText.text += "asd";
        }
        yield return new WaitForSeconds(typeTimeInterval);
    }
	
	// Update is called once per frame
	void Update () {
       
	}
}
