using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class moveplane : MonoBehaviour {

	public List<GameObject>  stayobjs = new List<GameObject>();

	Vector3 lasttrs;
	public float forcescale = 1.0f;
	// Use this for initialization
	void Start () {
		lasttrs = new Vector3(transform.position.x, transform.position.y, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (!stayobjs.Contains(other.gameObject))
		{
			//stayobjs.Add(other.gameObject);
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (stayobjs.Contains(other.gameObject))
		{
			//stayobjs.Remove(gameObject);
		}
	}

	void LateUpdate()
	{
		Vector3 mv = transform.position - lasttrs;
		foreach (GameObject go in stayobjs)
		{
			//go.rigidbody2D.AddForce(mv * forcescale);
			go.transform.Translate(mv);
		}
		lasttrs = new Vector3(transform.position.x, transform.position.y, transform.position.z);
	}
	
	void OnCollisionEnter2D(Collision2D coll)
	{

		if (!stayobjs.Contains(coll.gameObject))
		{
			stayobjs.Add(coll.gameObject);
		}
	}

	void OnCollisionExit2D(Collision2D coll)
	{
		if (stayobjs.Contains(coll.gameObject))
		{
			stayobjs.Remove(coll.gameObject);
		}
	}


	void FixedUpdate()
	{
		//rigidbody.AddForce(Vector3.up);
	}
}
