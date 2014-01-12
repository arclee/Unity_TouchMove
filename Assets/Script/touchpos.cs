using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class touchpos : MonoBehaviour {

	public GameObject mDrawObject = null;
	List<GameObject> mClones = new List<GameObject>();
	// Use this for initialization
	void Start () {
		for (int i = 0; i < 4; i++)
		{
			GameObject obj = (GameObject)Instantiate (mDrawObject);
			mClones.Add(obj);
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (Input.touchCount > 0)
		{
			for (int touchidx = 0; touchidx < 4; touchidx++)
			{
				if (Input.GetTouch (touchidx).phase == TouchPhase.Moved)
				{
					Vector2 tpos = Input.GetTouch(touchidx).position;
					Vector3 p = Camera.main.ScreenToWorldPoint (new Vector3 (tpos.x, tpos.y, 0));
					mClones[touchidx].transform.position = new Vector3(p.x, p.y, mClones[touchidx].transform.position.z);				
				}
			}

		}


	}
}
