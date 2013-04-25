//Justin White (jrw152)

using UnityEngine;
using System.Collections;

public class Guard : MonoBehaviour {
	GameObject[] gos;
	public GameObject Gargoyle;
	public GameObject Waldo;
	GameObject closest;
	public int speed = 50;
	public int sightRange=1400;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
        gos = GameObject.FindGameObjectsWithTag("Waldo");
		
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
		if (sightRange>distance){
		Gargoyle.SendMessage("SummonGargoyle");
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
	void invisiWaldo(){
		
		
	}
	
	void OnTriggerEnter(Collider other) {
        if (other.tag==("Waldo")){
		Waldo.SendMessage("Injured");
		}
    }
}

	
	
//using UnityEngine;
//using System.Collections;

//public class Guard : MonoBehaviour {
//	private bool hasSpotted;
//	public GameObject waldo;
//	public float xRange = 10.0f;
//	public float yRange = 10.0f;
//	public float zRange = 10.0f;
//	public float xRate = 1.0f;
//	public float yRate = 1.0f;
//	public float zRate = 1.0f;
//	private Vector3 mover = Vector3.zero;
//	// Use this for initialization
//	void Start () {
//		hasSpotted = false;
//	}
//	
//	// Update is called once per frame
//	void Update () {
//		mover = this.transform.position;
//		CharacterController controller = GetComponent<CharacterController>();
//		if(waldo.transform.position.x <= xRange || waldo.transform.position.y <= yRange || waldo.transform.position.z <= zRange){
//			hasSpotted = true;
//			if(waldo.transform.position.x <= xRange){mover.x = mover.x + xRate;}
//			if(waldo.transform.position.y <= yRange){mover.y = mover.y +yRate;}
//			if(waldo.transform.position.z <= zRange){mover.z = mover.z + zRate;}
//			controller.Move (mover*Time.deltaTime);
//			
//			
//		}
//		if(hasSpotted == true){
//			BroadcastMessage("SummonGargoyle", null);
//		}
//	
//	}
//}
