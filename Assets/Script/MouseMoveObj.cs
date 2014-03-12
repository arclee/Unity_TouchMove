using UnityEngine;
using System.Collections;

public class MouseMoveObj : MonoBehaviour {
	
	public int touchid = 0;
	public bool begintouch = false;
	public Vector2 beginPos;
	public Vector2 endPos;
	
	public bool touchfinish = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Application.platform == RuntimePlatform.WindowsEditor
		    || Application.platform == RuntimePlatform.WindowsPlayer)
		{
			if (!begintouch && Input.GetMouseButtonDown(touchid))
			{
				touchfinish = false;
				begintouch = true;
				beginPos = Input.mousePosition;
				//Debug.Log(beginPos);
			}
			else if (begintouch)
			{
				//結束.
				if (Input.GetMouseButtonUp(touchid))
				{
					touchfinish = true;
					begintouch = false;
					endPos = Input.mousePosition;
					
					
				}
				else
				{
					//移動.
					
					Vector3 mv = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 10));
					
					transform.position = mv;	
					
				}
			}
		}
	}
}
