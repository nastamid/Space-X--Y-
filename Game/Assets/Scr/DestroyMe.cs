using UnityEngine;
using System.Collections;

public class DestroyMe : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    void OnMouseDown()
    {
        if (GlobalSettings.GameIsPaused) return;
        if (GlobalSettings.GameIsOver) return;
        Destroy(gameObject);
    }

    void OnBecameInvisible()
    {
        print ("ganadgurda" );
        Destroy(gameObject);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
