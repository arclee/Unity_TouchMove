using UnityEngine;
using System.Collections;

public class touchctrl : MonoBehaviour {


	public bool begintouch = false;
	public Vector2 beginPos;
	public Vector2 endPos;
	
	public bool touchfinish = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.touchCount > 0)
		{
			if (!begintouch && (Input.GetTouch (0).phase == TouchPhase.Began))
			{
				touchfinish = false;
				begintouch = true;
				beginPos = Input.GetTouch(0).position;
			}
			else if (begintouch && (Input.GetTouch (0).phase == TouchPhase.Ended))
			{
				touchfinish = true;
				begintouch = false;
				endPos = Input.GetTouch(0).position;
				
				//hit test.
//				Vector3 b = Camera.main.ScreenToWorldPoint (new Vector3 (beginPos.x, beginPos.y, 0));
//				Vector3 e = Camera.main.ScreenToWorldPoint (new Vector3 (endPos.x, endPos.y, 0));
//				
//				RaycastHit2D hit2d = Physics2D.Raycast(b, e);
//				if (hit2d.rigidbody != null)
//				{
//					hit2d.rigidbody.AddForce(Vector3.up * 1000f);
//					
//					//float distanceToGround = hit.distance;			
//					
//				}
			}
		}
		
		
		if (!begintouch && Input.GetMouseButtonDown(0))
		{
			touchfinish = false;
			begintouch = true;
			beginPos = Input.mousePosition;
			//Debug.Log(beginPos);
		}
		else if (begintouch && Input.GetMouseButtonUp(0))
		{
			touchfinish = true;
			begintouch = false;
			endPos = Input.mousePosition;
			//Debug.Log(endPos);
			
			//			if (hit2d.rigidbody != null)
			//			{
			//				hit2d.rigidbody.AddForce(Vector3.up * 1000f);
			//				
			//				//float distanceToGround = hit.distance;
			//				
			//				
			//			}
		}
	}

	// Update is called once per frame
	void FixedUpdate ()
	{
		if (touchfinish)
		{
			touchfinish = false;
			
			Vector3 b = Camera.main.ScreenToWorldPoint (new Vector3 (beginPos.x, beginPos.y, 0));
			Vector3 e = Camera.main.ScreenToWorldPoint (new Vector3 (endPos.x, endPos.y, 0));
			
			Debug.DrawLine(b, e, Color.red, 1);
			RaycastHit2D[] hit2d = Physics2D.LinecastAll(b, e);
			
			foreach (RaycastHit2D rh in hit2d)
			{
				if (rh.rigidbody != null)
				{
					Quaternion.Euler(0, 0, 90.0f);
					//Vector2 dir = new Vector2(rh.rigidbody.transform.position.x, rh.rigidbody.transform.position.y) - rh.point;
					rh.rigidbody.AddForce(Quaternion.Euler(0, 0, 90.0f) * -rh.normal * 1000f );
				}
			}
		}
	}
}
