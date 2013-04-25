using UnityEngine;
using System.Collections;

public class Waldo : MonoBehaviour {
	
	private bool haveHat = false;
	public float moveSpeed = 0f;
	public float turnSpeed = 0f;
	public GameObject waldites;
	public GameObject Gargoyle;
	public GameObject Guard;
	public bool disguised = false;
	int swapTimer = 0;
	public int maxSwapTimer = 10;
	
	void Start () {
		/* Keeps waldo from flying into space*/
		rigidbody.freezeRotation = true;
	}
	
	//TODO: waldo is invisible if looking at guards
	// Update is called once per frame
	void FixedUpdate () {
			/*basic movmement mechanics*/
			if(Input.GetKey(KeyCode.W)){
				transform.Translate(Vector3.forward*Time.deltaTime*moveSpeed, Space.Self);
			}
			if(Input.GetKey(KeyCode.S)){
				transform.Translate(Vector3.back*Time.deltaTime*moveSpeed, Space.Self);
			}
			if(Input.GetKey(KeyCode.D)){
				transform.Rotate(0, Input.GetAxis("Horizontal")*turnSpeed*Time.deltaTime, 0,Space.Self);
			}
			if(Input.GetKey(KeyCode.A)){
				transform.Rotate(0, Input.GetAxis("Horizontal")*turnSpeed*Time.deltaTime, 0,Space.Self);
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
				revert();
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
	
	void revert(){
		disguised = false;
		//anit-load meshes and switch tags back
	}
	
	void freeze(){
		Vector3 fwd = transform.TransformDirection(Vector3.forward);
			RaycastHit hit;
	        if (Physics.Raycast(transform.position,fwd,out hit,20)){
				if(hit.collider.tag == "gargoyle"){
				Debug.Log("GARGOYLE SAW BY WALDO");
	            	Gargoyle.SendMessage("visibleToWaldo");
				}
				if(hit.collider.tag == "guard"){
					Guard.SendMessage("invisiWaldo");//unimplented, make guard freeze or whatever
				}
			}
			else
				Gargoyle.SendMessage("invisibleToWaldo");
	}
	
	void Injured(){
		this.gameObject.SetActive(false);
		//go to end screen
	}
	
}
