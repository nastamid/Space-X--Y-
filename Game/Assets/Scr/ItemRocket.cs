using UnityEngine;
using System.Collections;

public class ItemRocket : MonoBehaviour {

    float WinningTimer = 2;
    public float LosingTimer = 5;
    bool isLanded = false;

    float oldWinTimer;

    public float RocketForce = 10;
    
    public float moveSpeed = 10f;
    public float turnSpeed = 50f;
     Vector3 eulerAngleVelocity;
    public Rigidbody rb;
	// Use this for initialization
	void Start () {
        oldWinTimer = WinningTimer;
        eulerAngleVelocity = new Vector3(0, 35, 0);
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

        //if (Input.GetKey(KeyCode.UpArrow))
        //    transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.UpArrow))
        {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 1, 0) * RocketForce);
        }
        if (Input.GetKey(KeyCode.DownArrow))
            transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Quaternion deltaRotation = Quaternion.Euler(eulerAngleVelocity * Time.deltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);
        }

        if (Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);

	}

    void OnMouseDown()
    {
        if (GlobalSettings.GameFinished) return;
        if (GlobalSettings.GameIsPaused) return;
        if (GlobalSettings.GameIsOver) return;
        UIManager.instance.GameOver();
        Time.timeScale = 0;
    }



    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Planet")
        {
            isLanded = true;
        }
    }


    void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "Planet")
        {
            WinningTimer -= Time.deltaTime;
            if (WinningTimer<0)
            {
                LevelController.Instance.GoToNextLevel();
            }
        }
    }

    void OnTriggerExit()
    {
        isLanded = false;
        WinningTimer = oldWinTimer;
    }

    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Planet")
        {

            if (isLanded) return;

            LosingTimer -= Time.deltaTime;
            if (LosingTimer < 0)
            {
                UIManager.instance.GameOver();
            }
        }

    }

    //void OnCollisionExit()
    //{
    //    LosingTimer = oldLoseTimer;
    //}

    void OnBecameInvisible()
    {
        if (gameObject.activeInHierarchy)
        {
            StartCoroutine(callGameOver());
        }
        //Destroy(gameObject);
        //UIManager.instance.GameOver();
            
    }

    IEnumerator callGameOver()
    {
        yield return new WaitForSeconds(1.5f);
        UIManager.instance.GameOver();
    }

}
