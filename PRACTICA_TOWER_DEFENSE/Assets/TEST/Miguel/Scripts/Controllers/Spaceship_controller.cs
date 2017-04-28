using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship_controller : MonoBehaviour {

    GameObject canyon;
    Vector3 direccion;

	// Use this for initialization
	void Start () {
        canyon = gameObject.transform.Find("Rotation_axis").gameObject;


    }
	
	// Update is called once per frame
	void Update () {
        direccion = Input.mousePosition;        
        //canyon.transform.right = direccion;
        canyon.transform.rotation = Quaternion.Euler(0, 0, direccion.x);



    }
}
