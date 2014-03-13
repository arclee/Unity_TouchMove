using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RightAreaTouch : MonoBehaviour {

	public GameObject targetmoveObj = null;

	public int currentTouchID = -1;

	public List<int> touchlist = new List<int>();
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		//加入.
		if (Input.touchCount > 0)
		{
			for (int touchidx = 0; touchidx < Input.touchCount; touchidx++)
			{
				Touch tch = Input.GetTouch (touchidx);
				if (tch.phase == TouchPhase.Canceled
				    || tch.phase == TouchPhase.Ended
				    )
				{
					if (currentTouchID == touchidx)
					{
						currentTouchID = -1;
					}
				}
			}
		}

		if (currentTouchID == -1)
		{
			//清空.
			touchlist.Clear();
			//加入.
			if (Input.touchCount > 0)
			{
				for (int touchidx = 0; touchidx < Input.touchCount; touchidx++)
				{
					Touch tch = Input.GetTouch (touchidx);
					if (tch.phase == TouchPhase.Began
					    //|| tch.phase == TouchPhase.Moved
					    //|| tch.phase == TouchPhase.Stationary
					    )
					{
						Vector2 tpos = tch.position;
						Vector3 wp = Camera.main.ScreenToWorldPoint(new Vector3 (tpos.x, tpos.y, 10));
						
						Collider2D[] c2d =  Physics2D.OverlapPointAll(new Vector2(wp.x, wp.y));
						foreach(Collider2D cd in c2d)
						{
							if (cd == collider2D)
							{
								touchlist.Add(touchidx);
							}
						}
					}
				}
			}

		}
		//找出.
		int newtouchid = -1;
		//保持.
		if (currentTouchID >= 0)
		{
			foreach(int tch in touchlist)
			{
				if (tch == currentTouchID)
				{
					newtouchid = currentTouchID;
					break;
				}
			}
		}

		//抓最小的(最先摸的).
		//if (currentTouchID == -1)
		{
			foreach(int tch in touchlist)
			{
				if (newtouchid != -1)
				{
					if (tch < newtouchid)
					{
						newtouchid = tch;
					}
				}
				else
				{
					newtouchid = tch;
				}
			}
		}

		currentTouchID = newtouchid;

		if (currentTouchID > -1)
		{
			Vector2 tpos = Input.GetTouch(currentTouchID).position;
			Vector3 wp = Camera.main.ScreenToWorldPoint(new Vector3 (tpos.x, tpos.y, 10));
			targetmoveObj.transform.position = wp;
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
