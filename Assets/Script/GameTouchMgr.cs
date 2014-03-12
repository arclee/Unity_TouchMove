using UnityEngine;
using System.Collections;

public class GameTouchMgr : MonoBehaviour {

	public GameObject targetmoveObj = null;

	public int currentTouchID = -1;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{

		//沒摸, 或摸的大於1, 就重算.
		if (Input.touchCount < 0 
		    || Input.touchCount > 1 )
		{
			currentTouchID = -1;
		}

		//先確定先摸到這區的ID.
		if (currentTouchID == -1)
		{
			if (Input.touchCount > 0)
			{
				for (int touchidx = 0; touchidx < 4; touchidx++)
				{
					if (Input.GetTouch (touchidx).phase == TouchPhase.Began
					    || Input.GetTouch (touchidx).phase == TouchPhase.Moved
					    || Input.GetTouch (touchidx).phase == TouchPhase.Stationary)
					{
						Vector2 tpos = Input.GetTouch(touchidx).position;
						Vector3 wp = Camera.main.ScreenToWorldPoint(new Vector3 (tpos.x, tpos.y, 10));
						
						Collider2D[] c2d =  Physics2D.OverlapPointAll(new Vector2(wp.x, wp.y));
						foreach(Collider2D cd in c2d)
						{
							if (collider2D == cd)
							{
								currentTouchID = touchidx;
								break;
							}
						}

						if (currentTouchID != -1)
						{
							break;
						}
					}
				}
			}
		}

		//看離手了沒, 或移出了.
		if (currentTouchID >= 0)
		{
			if (Input.GetTouch (currentTouchID).phase == TouchPhase.Canceled
			    || Input.GetTouch (currentTouchID).phase == TouchPhase.Ended)
			{
				currentTouchID = -1;
			}
		}
				
		if (currentTouchID >= 0)
		{
			Vector2 tpos = Input.GetTouch(currentTouchID).position;
			Vector3 wp = Camera.main.ScreenToWorldPoint(new Vector3 (tpos.x, tpos.y, 10));
			
			Collider2D[] c2d =  Physics2D.OverlapPointAll(new Vector2(wp.x, wp.y));
			bool find = false;
			foreach(Collider2D cd in c2d)
			{
				if (collider2D == cd)
				{
					find = true;
					break;
				}
			}

			if (!find)
			{
				currentTouchID = -1;
			}
			
		}
//		
//		if (Input.touchCount > 0)
//		{
//			for (int touchidx = 0; touchidx < 4; touchidx++)
//			{
//				if (Input.GetTouch (touchidx).phase == TouchPhase.Began)
//				{
//		
//					Vector2 tpos = Input.GetTouch(0).position;
//					Vector3 wp = Camera.main.ScreenToWorldPoint(new Vector3 (tpos.x, tpos.y, 10));
//
//					Collider2D c2d =  Physics2D.OverlapPoint(new Vector2(wp.x, wp.y));
//					if (c2d  != null)
//					{
//						if (collider2D == c2d)
//						{
//							Vector3 mv = Camera.main.ScreenToWorldPoint(new Vector3 (tpos.x, tpos.y, 10));
//							
//							targetmoveObj.transform.position = mv;
//						}
//					}
//				}
//				else if (Input.GetTouch (touchidx).phase == TouchPhase.Ended)
//				{
//
//				}
//			}
//		}
	}

	void OnTriggerEnter2D()
	{

	}

}
