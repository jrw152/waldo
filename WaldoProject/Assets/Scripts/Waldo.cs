using UnityEngine;
using System.Collections;

public class Waldo : MonoBehaviour {
	
	private bool haveHat = false;
	public float moveSpeed = 0f;
	public float turnSpeed = 0f;
	GameObject waldites = null;
	public bool disguised = false;
	int swapTimer = 0;
	public int maxSwapTimer = 10;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
			if(Input.GetKey(KeyCode.UpArrow)){
				//move forward
			}
			if(Input.GetKey(KeyCode.DownArrow)){
				//move backward
			}
			if(Input.GetKey(KeyCode.RightArrow)){
				//rotate camera
			}
			if(Input.GetKey(KeyCode.LeftArrow)){
				//rotate camera
			}
			//TODO: check if mouse over waldites
			if(Input.GetMouseButton(0)){
				teleport();
			}
			if(disguised == true){
				swapTimer++;
			}
			if(swapTimer == maxSwapTimer){
				swapTimer = 0;
				disguised = false;
			}
		
	}
	//TODO: message sent from hat object
	void GetHat(){
		haveHat = true;
	}
	//TODO: account for more than one group of waldites
	void teleport(){
		if(haveHat == true){
			Vector3 targetGroup = new Vector3(0,0,0);
			targetGroup = waldites.transform.position;
			transform.position = targetGroup;
		}
	}
	
	void skinSwap(){
		if(haveHat == true){
			//load like, mesh stuff
			disguised = true;
		}
	}
	
	
}
