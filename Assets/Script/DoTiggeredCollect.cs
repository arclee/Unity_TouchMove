using UnityEngine;
using System.Collections;

public class DoTiggeredCollect : MonoBehaviour {

	public int Touchid = 0;
	CollectTiggered mTiggeredCollect = null;
	// Use this for initialization
	void Start ()
	{
		mTiggeredCollect = gameObject.GetComponent<CollectTiggered>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButtonUp(Touchid))
		{
			if (mTiggeredCollect.TiggeredCollects.Count > 0)
			{
				foreach (Collider2D c2d in mTiggeredCollect.TiggeredCollects)
				{
					Vector2 f = new Vector2(1000* Random.Range(-1.0f, 1.0f), 1000*Random.Range(-1.0f, 1.0f));
					c2d.rigidbody2D.AddForce(f);
					c2d.gameObject.SetActive(false);
				}

			}
			mTiggeredCollect.TiggeredCollects.Clear();
		}
	}
}
