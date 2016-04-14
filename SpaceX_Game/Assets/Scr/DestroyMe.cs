using UnityEngine;
using System.Collections;

public class DestroyMe : MonoBehaviour {


    void OnMouseDown()
    {
        if (!TimerContoller.FirstTapHappend)
        {
            TimerContoller.FirstTapHappend = true;
        }
        if (GlobalSettings.GameIsPaused) return;
        if (GlobalSettings.GameIsOver) return;
        Destroy(gameObject);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
	

}
