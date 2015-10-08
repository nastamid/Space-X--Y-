using UnityEngine;
using System.Collections;

public class GlobalSettings : MonoBehaviour {

    public GameObject setGlobalPlanet;
    public static GameObject GlobalPlanet;

    public static bool GameIsPaused = false;
    public static bool GameIsOver = false;

    public float setGlobalGravity;
    public static float  GlobalGravity;
	// Use this for initialization
	void Start () {
        GlobalGravity = setGlobalGravity;
        GlobalPlanet = setGlobalPlanet;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
