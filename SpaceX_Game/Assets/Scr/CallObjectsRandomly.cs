using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class CallObjectsRandomly : MonoBehaviour {


    public GameObject Tringle;
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.K))
        {
            Instantiate(Tringle, new Vector3(-10, 0, 0),Quaternion.identity);
        }
	
	}

    
}
