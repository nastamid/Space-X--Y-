using UnityEngine;
using System.Collections;

public class GlobalSettings : MonoBehaviour {

    public GameObject setGlobalPlanet;
    public static GameObject GlobalPlanet;
    public static bool GameFinished = false;

    public static bool GameIsPaused = false;
    public static bool GameIsOver = false;

    public float setGlobalGravity;
    public static float  GlobalGravity;


	// Use this for initialization
	void Start () {
        if(LoginContoller.isSAved)
            LoginContoller.isSAved = false;
        if (GameIsPaused) GameIsPaused = false;
        if (GameIsOver) GameIsOver = false;
        if (GameFinished) GameFinished = false;
        GlobalGravity = setGlobalGravity;
        GlobalPlanet = setGlobalPlanet;
	}
	

}
