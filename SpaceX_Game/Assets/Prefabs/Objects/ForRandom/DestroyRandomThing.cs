using UnityEngine;
using System.Collections;

public class DestroyRandomThing : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void DestroyME()
    {
        Destroy(gameObject);
    }
}
