using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		if (Input.touchCount > 0)
		{
			for (int touchidx = 0; touchidx < 4; touchidx++)
			{
				if (Input.GetTouch (touchidx).phase == TouchPhase.Ended)
				{
					Vector2 tpos = Input.GetTouch(touchidx).position;
					Vector3 p = Camera.main.ScreenToWorldPoint (new Vector3 (tpos.x, tpos.y, 0));
					
					RaycastHit2D hit2d = Physics2D.Raycast(p, p);
					if (hit2d.rigidbody != null)
					{
						hit2d.rigidbody.AddForce(Vector3.up * 1000f);

						//float distanceToGround = hit.distance;


					}
				}
			}			
		}

		
		if (Input.GetMouseButtonDown(0))
		{
			
			Vector3 p = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
			
			RaycastHit hit;
			Debug.DrawLine(p, new Vector3(p.x, p.y, 100), Color.red, 2);
			if (Physics.Raycast(p, -Vector3.forward, out hit, 100.0F))
			{
				hit.rigidbody.AddForce(Vector3.up * 1000f);
				
				//float distanceToGround = hit.distance;
				
				//Debug.DrawLine(p, new Vector3(p.x, p.y, 100), Color.red);
			}

			RaycastHit2D hit2d = Physics2D.Raycast(p, p);
			
			//Debug.DrawLine(p, p, Color.blue);
			//Debug.DrawLine(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 100), new Vector3(Input.mousePosition.x+10, Input.mousePosition.y+10, 100), Color.red);
			if (hit2d.rigidbody != null)
			{
				hit2d.rigidbody.AddForce(Vector3.up * 1000f);
				
				//float distanceToGround = hit.distance;
				
				//Debug.DrawLine(p, new Vector3(p.x, p.y, 100), Color.red);
			}
		}
	}
}
