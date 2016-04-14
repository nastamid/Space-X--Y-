using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


public class LevelGenerator : MonoBehaviour {

    public GameObject Rocket;
    public Vector3 RocketPos;
    public List<GameObject> GO_List;
    public List<Vector3>  CreatePos_List;
    //public List<Vector3> Rotation_List;
    Vector3 oldGravity;
    GameObject currentRocket;
    GameObject currentGO;
    void Awake()
    {
        oldGravity = Physics.gravity;
        Physics.gravity = Vector3.zero;
    }

	void Start () {

        SetRocket();
        SetLevel();
        Physics.gravity = oldGravity;
	}

    private void SetRocket()
    {
        currentRocket = Instantiate(Rocket, RocketPos, Quaternion.Euler(0, 180, 0)) as GameObject;
        currentRocket.transform.parent = transform;  
    }

    private void SetLevel()
    {
        for (int i = 0; i < GO_List.Count; i++)
        {

            currentGO = Instantiate(GO_List[i], CreatePos_List[i], Quaternion.Euler(new Vector3(0, 180, 0) /*+ Rotation_List[i]*/)) as GameObject;
            currentGO.transform.parent = transform;  

        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        for (int i = 0; i < GO_List.Count; i++)
        {
            //Matrix4x4 rotationMatrix = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(Rotation_List[i]),Vector3.one);
            //Gizmos.matrix = rotationMatrix;
           Gizmos.DrawWireCube(CreatePos_List[i], GO_List[i].GetComponent<BoxCollider>().size * GO_List[i].transform.localScale.x);
        }

        Gizmos.DrawWireCube(RocketPos, Rocket.GetComponent<BoxCollider>().size * Rocket.transform.localScale.x);
    }


	
}
