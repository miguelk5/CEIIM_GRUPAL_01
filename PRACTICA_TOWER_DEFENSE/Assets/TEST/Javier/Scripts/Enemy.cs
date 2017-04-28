using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public Transform player;
    public int type;
    public float speed;
    Vector3 direction;

    Vector3 zigZag;
    // Use this for initialization
    private void Awake()
    {
        zigZag = Vector3.zero;
        player = player.GetComponent<Transform>();
     
    }

    void Start () {
       // direction = player.transform.position - transform.position; 
        transform.up = direction;
    }
	
	// Update is called once per frame
	void Update () {

        direction = player.transform.position - transform.position;

        zigZag.x = Mathf.Sin(Time.time*3)*0.5f;

        transform.position += direction.normalized * speed * Time.deltaTime;
        transform.localPosition += zigZag.x * transform.right;
  
    }
}
