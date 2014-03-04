using UnityEngine;
using System.Collections;

public class CameraFllowObject : MonoBehaviour {

	public Transform mFllowObjectTrans;
	public Vector3 mDeltaPos;
	

	// Use this for initialization
	void Start ()
	{
		mDeltaPos = transform.position - mFllowObjectTrans.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = mFllowObjectTrans.position + mDeltaPos;
	}
}
