using UnityEngine;
using System.Collections;

public class Guard : MonoBehaviour {
	private bool hasSpotted;
	public GameObject waldo;
	public float xRange = 10.0f;
	public float yRange = 10.0f;
	public float zRange = 10.0f;
	public float xRate = 1.0f;
	public float yRate = 1.0f;
	public float zRate = 1.0f;
	private Vector3 mover = Vector3.zero;
	// Use this for initialization
	void Start () {
		hasSpotted = false;
	}
	
	// Update is called once per frame
	void Update () {
		mover = this.transform.position;
		CharacterController controller = GetComponent<CharacterController>();
		if(waldo.transform.position.x <= xRange || waldo.transform.position.y <= yRange || waldo.transform.position.z <= zRange){
			hasSpotted = true;
			if(waldo.transform.position.x <= xRange){mover.x = mover.x + xRate;}
			if(waldo.transform.position.y <= yRange){mover.y = mover.y +yRate;}
			if(waldo.transform.position.z <= zRange){mover.z = mover.z + zRate;}
			controller.Move (mover*Time.deltaTime);
			
			
		}
		if(hasSpotted == true){
			BroadcastMessage("SummonGargoyle", null);
		}
	
	}
}
