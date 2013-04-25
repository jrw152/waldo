//Justin White (jrw152)

using UnityEngine;
using System.Collections;

public class Gargoyle : MonoBehaviour {
	GameObject[] gos;
	GameObject closest;
	public int speed = 2;
	public GameObject Waldo;
	bool visible=false;
	bool called=false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
        gos = GameObject.FindGameObjectsWithTag("Waldo");
        //Debug.Log(visible);
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
		
		//Loops through the waldos and finds the closest waldo to the gargoyle's location
		//Only more then one waldo if the waldo uses the skin swap ability
        foreach (GameObject go in gos) {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance) {
                closest = go;
                distance = curDistance;
            }
        }
		
		//Indicates whether the gargoyle should move towards waldo or not
		if (visible == false && called == true){
		Transform playerTransform = closest.transform;
		//move guard towards prisoner's position.
		Vector3 v1 = playerTransform.position;
        transform.position = Vector3.MoveTowards(transform.position, v1, speed*Time.deltaTime);
		Vector3 v2 = transform.position;
			
			
			////indicates that the prisoner should be attacked by the guard
			if(v1==v2){
				
				Waldo.SendMessage("Injured");
			}
	}
	}
	void SummonGargoyle(){
	called = true;	
	}
	
	void visibleToWaldo(){
	visible = true;	
	}
	
	void invisibleToWaldo(){
	visible = false;	
	}
	
	
}
