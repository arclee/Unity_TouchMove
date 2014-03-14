using UnityEngine;
using System.Collections;
 
//將此腳本放置在有LineRenderer組件的物件身上，並指定一個Target即可看到效果
 
public class Lightning: MonoBehaviour 
{
 
	public GameObject targetObj; 		//閃電連線目標
	public float CD = 0.05f;	 		//CD時間
	public float randomPosX = 0.4f;	 	//閃電的X範圍
	public float randomPosY = 0.4f;	 	//閃電的Y範圍
	public int maxVertex = 5;	 		//線段數量
	public float Lwidth = 0.2f;			//線段寬度 
	
	LineRenderer lineRenderer; 			//存放物件身上的LineRenderer
	float t_time;						//計時器
	 
	void Start () 
	{
		//取的物件身上的LineRenderer組件
		lineRenderer = GetComponent<LineRenderer>();
		lineRenderer.SetVertexCount(maxVertex);
		lineRenderer.SetWidth(Lwidth,Lwidth);
	}
	 
	void Update () 
	{
		//計時器，方便調整閃電頻率
		t_time += Time.deltaTime;
		if(t_time >= CD)
		{
			t_time = 0;
			LightningFX();
		}
	}
	 
	//閃電效果
	void LightningFX()
	{
		//將LineRenderer中第0點設為本身座標 
		lineRenderer.SetPosition(0,this.transform.position);
		 
		//這邊讓i從1到(maxVertex-1)，也就是減掉LineRenderer中的第0個座標
		for(int i = 1; i < (maxVertex - 1.0f); i++)
		{
			//將變數pos放入本身座標到目標座標，並根據現有線段數量將他分開
			Vector3 pos = Vector3.Lerp(this.transform.position,targetObj.transform.position,(float)i/ ((float)maxVertex - 1.0f));
			 
			//亂數改變pos位置
			pos.x += Random.Range(-randomPosX,randomPosX);
			pos.y += Random.Range(-randomPosY,randomPosY);
			 
			lineRenderer.SetPosition(i,pos);
		}
	 
		//設定最後一點到指定目標，maxVertex-1是因為起始值為0，故需要-1 
		lineRenderer.SetPosition(maxVertex-1,targetObj.transform.position);
	}
}
