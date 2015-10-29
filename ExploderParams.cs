using UnityEngine;
using System.Collections;

public class ExploderParams : MonoBehaviour {

	public float minDistance;
	public float maxDistance;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public float getMin(){
		return minDistance;
	}

	public float getMax(){
		return maxDistance;
	}
}
