using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pilot : MonoBehaviour {

	public float speed = 20f;
	public float minSpeed = 10f;


	// Use this for initialization
	void Start () {
		Debug.Log ("pilot script added to " + gameObject.name);	
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 moveCamTo = transform.position - transform.forward * 10.0f + Vector3.up * 5.0f;
		Camera.main.transform.position = moveCamTo;
		Camera.main.transform.LookAt (transform.position);
		transform.position += transform.forward * Time.deltaTime * speed;

		speed -= transform.forward.y * Time.deltaTime * 5.0f;
		if (speed < minSpeed)
			speed = minSpeed;


		transform.Rotate (Input.GetAxis("Vertical"),0,-Input.GetAxis("Horizontal"));

		float relativeAltitude = Terrain.activeTerrain.SampleHeight (transform.position);
		if (relativeAltitude > transform.position.y) {

			Debug.Log ("Crashed");
			transform.position = new Vector3 (transform.position.x,relativeAltitude,transform.position.z);
		}
	}
}
