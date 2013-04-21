using UnityEngine;
using System.Collections;

public class Guard : MonoBehaviour {
	private bool hasSpotted;
	public GameObject waldo;
	public int xRange;
	public int yRange;
	public int zRange;

	// Use this for initialization
	void Start () {
		hasSpotted = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(waldo.transform.position.x <= xRange || waldo.transform.position.y <= yRange || waldo.transform.position.z <= zRange){
			hasSpotted = true;
		}
		if(hasSpotted == true){
			BroadcastMessage("SummonGargoyle", null);
		}
	
	}
}
