using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour {

    
    public Transform rotationAxe;
    Vector2 mousePosition;
    Vector2 direction;
    // Use this for initialization

    private void Awake()
    {
        rotationAxe = rotationAxe.GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update () {

        mousePosition = (Camera.main.ScreenToWorldPoint(Input.mousePosition));
        direction = new Vector2(mousePosition.x - rotationAxe.position.x, mousePosition.y - rotationAxe.position.y);
        rotationAxe.right = direction;   
	}
}
