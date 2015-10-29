using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ExploderController : MonoBehaviour {

	public GameObject player;
	public float defaultMaxDistance;
	public float defaultMinDistance;
	public GameObject debuggin;

	private string debugStr;
	private Text debugText;
	private GameObject[] expObjs;



	void Start () {
		debugStr = "";
		debugText = debuggin.GetComponent<Text>();
		expObjs = GameObject.FindGameObjectsWithTag ("ExpObj");
	}
	


	
	void Update () {

		debugText.text = debugStr;
		debugStr = "";

		foreach (GameObject expObj in expObjs) {

			// Check for individually defined min and max values
			float minDistance;
			float maxDistance;


			if(expObj.GetComponent<ExploderParams>()){
				if(expObj.GetComponent<ExploderParams>().minDistance != null && expObj.GetComponent<ExploderParams>().minDistance != 0){
					minDistance = expObj.GetComponent<ExploderParams>().minDistance;
				} else {
					minDistance = defaultMinDistance;
				}

				if(expObj.GetComponent<ExploderParams>().maxDistance != null && expObj.GetComponent<ExploderParams>().maxDistance != 0){
					maxDistance = expObj.GetComponent<ExploderParams>().maxDistance;
				} else {
					maxDistance = defaultMaxDistance;
				}
			} else {
				minDistance = defaultMinDistance;
				maxDistance = defaultMaxDistance;
			}

			// Check current distance
			float distance = Vector3.Distance (player.transform.position, expObj.transform.position);
			float linearVal;

			debugStr += distance.ToString () + "\n";

			if (distance > maxDistance) {
				linearVal = 1;
			} else if (distance < minDistance) {
				linearVal = 0;
			} else {
				linearVal = distance - minDistance; // Now were on scale from 0-45
				linearVal = linearVal / (maxDistance - minDistance);
			}

			float expVal = Mathf.Pow (2, linearVal * 10);

			debugStr += linearVal.ToString () + "\n";
		
			expObj.GetComponent<Renderer> ().material.SetFloat ("V_FR_Fragmentum", linearVal + Random.value/8);
			expObj.GetComponent<Renderer> ().material.SetFloat ("V_FR_DisplaceAmount", expVal);
			expObj.GetComponent<Renderer> ().material.SetFloat ("V_FR_RotateSpeed", linearVal / 25);
			//expObj.GetComponent<Renderer> ().material.SetFloat ("V_FR_FragmentsScale", Mathf.Min (Random.value * linearVal * 15, 10));
			expObj.GetComponent<Renderer> ().material.SetFloat ("V_FR_FragmentsScale", linearVal * 3);

		} 

	}
}
