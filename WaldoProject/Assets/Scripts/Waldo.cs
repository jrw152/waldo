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
	
	void Start () {

	}
	
	//TODO: waldo is invisible if looking at guards
	// Update is called once per frame
	void Update () {
			/*basic movmement mechanics*/
			if(Input.GetKey(KeyCode.W)){
				transform.Translate(Vector3.forward*Time.deltaTime*moveSpeed);
			}
			if(Input.GetKey(KeyCode.S)){
				transform.Translate(Vector3.back*Time.deltaTime*moveSpeed);
			}
			if(Input.GetKey(KeyCode.D)){
				transform.Rotate(Vector3.right*Time.deltaTime);
			}
			if(Input.GetKey(KeyCode.A)){
				transform.Rotate(Vector3.left*Time.deltaTime);
			}
		
			//teleport mechanics
			//TODO: check if mouse over waldites?
			// or maybe we will just limit it to once per run
			if(Input.GetMouseButton(0)){
				teleport();
			}
		
			/* skin swap timer mechanics*/
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
	//TODO: account for more than one group of waldites?
	void teleport(){
		if(haveHat == true){
			Vector3 targetGroup = new Vector3(0,0,0);
			targetGroup = waldites.transform.position;
			transform.position = targetGroup;
			//maybe play sound effect?
		}
	}
	
	void skinSwap(){
		if(haveHat == true){
			//load like, mesh stuff
			disguised = true;
		}
	}
	
	
}
