//Justin White (jrw152)

using UnityEngine;
using System.Collections;

public class Gargoyle : MonoBehaviour {
	GameObject[] gos;
	GameObject closest;
	public int speed = 2;
	public bool lookedAt=false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
        gos = GameObject.FindGameObjectsWithTag("Waldo");
        
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
		
		//Loops through the prisoners and finds the closest prisoner to the guard's location
        foreach (GameObject go in gos) {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance) {
                closest = go;
                distance = curDistance;
            }
        }
		
		//Indicates whether the closest prisoner is within range of the guard
		if (lookedAt==false){
		Transform playerTransform = closest.transform;
		//move guard towards prisoner's position.
		Vector3 v1 = playerTransform.position;
        transform.position = Vector3.MoveTowards(transform.position, v1, speed*Time.deltaTime);
		Vector3 v2 = transform.position;
			
			
			////indicates that the prisoner should be attacked by the guard
			if(v1==v2){
				
				closest.SendMessage("Injured",gameObject.tag);
			}
	}
	}
	
	void OnTriggerEnter(Collider other) {
        if (other.tag==("player_shank")){
		other.SendMessage("Injured",gameObject.tag);
		}
    }
}
