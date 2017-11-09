using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumbInputScript : MonoBehaviour {

    public float turnSpeed = 10;
    public float speed = 10;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.Rotate(Vector3.up * Time.deltaTime * horizontal * turnSpeed);
        transform.position = transform.position + Time.deltaTime * transform.forward * vertical * speed;
	}
}
