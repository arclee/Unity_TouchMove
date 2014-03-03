using UnityEngine;
using System.Collections;

[RequireComponent (typeof(GUIText))]
public class ScreenSize : MonoBehaviour {

	// Use this for initialization
	void Start () {
		guiText.text = Screen.width.ToString() + "  "+ Screen.height.ToString()+ "\n" + Screen.currentResolution.width.ToString() + "  " +Screen.currentResolution.height.ToString() ;
/*
		float h, w, Q;
		float near_plane;
		const float far_plane;
		const float fov_horiz;
		const float fov_vert;

		w = (float)1/Mathf.Tan(fov_horiz*0.5);  // 1/tan(x) == cot(x)
		h = (float)1/Mathf.Tan(fov_vert*0.5);   // 1/tan(x) == cot(x)
		Q = far_plane/(far_plane - near_plane);

		camera.projectionMatrix.*/
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
