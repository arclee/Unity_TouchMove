using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CollectTiggered : MonoBehaviour {

	public List<Collider2D> TiggeredCollects = new List<Collider2D>();
	//public Dictionary<int, Collider2D> TiggeredCollectsDic = new Dictionary<int, Collider2D>();
	// Use this for initialization

	public List<Collider2D> GetTiggeredCollects()
	{
		return TiggeredCollects;
	}

	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (!TiggeredCollects.Contains(other))
		{
			TiggeredCollects.Add(other);
		}
		

	}
}
