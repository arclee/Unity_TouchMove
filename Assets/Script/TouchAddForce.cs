using UnityEngine;
using System.Collections;

public class TouchAddForce : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (Input.GetMouseButtonDown(0))
		{

			Vector3 p = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));

			Vector3 dir = -(transform.position - p);

			rigidbody2D.AddForce(dir.normalized * 1000f);
		}
	}
}
