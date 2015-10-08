using UnityEngine;
using System.Collections;

public class GravityToPlanet : MonoBehaviour
{
    float acceleration;
	// Use this for initialization
	void Awake () {
        acceleration = GlobalSettings.GlobalGravity;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        //print(GlobalSettings.GlobalPlanet.transform.position);
        gameObject.GetComponent<Rigidbody>().AddForce((GlobalSettings.GlobalPlanet.transform.position - transform.position).normalized * acceleration);
        //rigidbody.AddForce((planet.position - transform.position).normalized * acceleration);
	}
}
