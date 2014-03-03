using UnityEngine;
using System.Collections;

public class TouchMoveObj : MonoBehaviour {

	public int touchid = 0;
	
	
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
			if (!begintouch && (Input.GetTouch (touchid).phase == TouchPhase.Began))
			{
				touchfinish = false;
				begintouch = true;
				beginPos = Input.GetTouch(touchid).position;
			}
			else if (begintouch && (Input.GetTouch (touchid).phase == TouchPhase.Ended))
			{
				touchfinish = true;
				begintouch = false;
				endPos = Input.GetTouch(touchid).position;				
				
			}
			
			if (Input.GetTouch (touchid).phase == TouchPhase.Moved)
			{
				Vector2 tpos = Input.GetTouch(touchid).position;
				Vector3 mv = Camera.main.ScreenToWorldPoint(new Vector3 (tpos.x, tpos.y, 10));
				transform.position = mv;
			}
			
		}

	}

}
