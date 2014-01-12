using UnityEngine;
using System.Collections;

public class TouchMove : MonoBehaviour {
	
	private Vector3 _destination;
	// Use this for initialization
	void Start () {
		_destination = transform.position;
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		_destination.z = transform.position.z;
		Vector3 dir = -(transform.position - _destination);
		
		if (dir.magnitude > 0.1f)
			transform.Translate(dir.normalized * 10f * Time.deltaTime);

		if (Input.GetMouseButtonDown(0)) {

			Vector3 p = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
			_destination = p;
		}
	}
}
