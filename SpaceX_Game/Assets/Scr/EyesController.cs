using UnityEngine;
using System.Collections;

public class EyesController : MonoBehaviour {

    public int MinTime = 3;
    public int MaxTime = 6;
    float randomN;
    Animator anim;

	// Use this for initialization
	void Start () {
        randomN = Random.Range(MinTime, MaxTime);
        anim = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        randomN -= Time.deltaTime;
        if (randomN <=0)
        {
            triggerAnimation();
            resetRandomN();
        }
        
	
	}

    private void resetRandomN()
    {
        randomN = Random.Range(MinTime, MaxTime);
    }

    private void triggerAnimation()
    {
        anim.SetTrigger("Blink");
    }
}
