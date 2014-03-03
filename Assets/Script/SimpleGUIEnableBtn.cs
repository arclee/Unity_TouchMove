using UnityEngine;
using System.Collections;

public class SimpleGUIEnableBtn : MonoBehaviour {

	public float guiScale = 1.0f;
	bool isEnable = true;
	public string BtnMsg = "btn msg";
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public static Rect GetResizedRect(Rect rect)
	{
		Vector2 position = GUI.matrix.MultiplyVector(new Vector2(rect.x, rect.y));
		Vector2 size = GUI.matrix.MultiplyVector(new Vector2(rect.width, rect.height));
		
		return new Rect(position.x, position.y, size.x, size.y);
	}

	public static void AutoResize(int screenWidth, int screenHeight)
	{
		Vector2 resizeRatio = new Vector2((float)Screen.width / screenWidth, (float)Screen.height / screenHeight);
		GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3(resizeRatio.x, resizeRatio.y, 1.0f));
	}

	void OnGUI()
	{
		int w = (int)((float)Screen.width/guiScale);
		int h = (int)((float)Screen.height/guiScale);

		AutoResize(w, h);
		if (GUILayout.Button(BtnMsg))
		{
			isEnable = !isEnable;
			Transform pTransform = GetComponent<Transform>();
			
			foreach (Transform trs in pTransform)
			{
				trs.gameObject.SetActive(isEnable);			
			}

		}
	}
}
