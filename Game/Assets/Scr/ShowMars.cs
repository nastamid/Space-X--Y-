using UnityEngine;
using System.Collections;

public class ShowMars : MonoBehaviour {
    bool marsOn = false;
    public GameObject earth;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.M))
        {
            marsOn = !marsOn;
            earth.GetComponent<MeshRenderer>().enabled = !marsOn;
            gameObject.GetComponent<MeshRenderer>().enabled = marsOn;
        }
	
	}
}
