using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour {

    public GameObject bullet;
    public Transform rotationAxe;
    Vector2 mousePosition;
    Vector2 direction;
    Transform rotationAtShoot;
    // Use this for initialization
    bool shoot;
    private void Awake()
    {
        rotationAxe = rotationAxe.GetComponent<Transform>();       
    }
	
	// Update is called once per frame
	void Update () {

        Direction();
        //Shoot();
	}

    void Direction()
    {
        mousePosition = (Camera.main.ScreenToWorldPoint(Input.mousePosition)); //toma la posición del ratón
        direction = new Vector2(mousePosition.x - rotationAxe.position.x, mousePosition.y - rotationAxe.position.y); // vector direccion tomando como punto final la posición del ratón y como punto inicial la del eje de rotación
        rotationAxe.right = direction;   //Hacer que el vector Right del eje de rotación tome la dirección calculada anteriormente
    }

    //void Shoot()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //     Instantiate(bullet,rotationAxe);           
    //}
}
