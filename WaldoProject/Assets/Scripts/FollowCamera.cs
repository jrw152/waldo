using UnityEngine;
using System.Collections;


public class FollowCamera : MonoBehaviour {
    public GameObject target;
    Vector3 offset;
	Vector3 yAdjust = new Vector3(0,5,0);
    void Start() {
		target = GameObject.FindGameObjectWithTag("Waldo");
        offset = target.transform.position - transform.position;
    }
	
	// Update is called once per frame
	void LateUpdate() {
	    float desiredAngle = target.transform.eulerAngles.y;
	    Quaternion rotation = Quaternion.Euler(-15, desiredAngle - 15, 0);
		transform.position = target.transform.position - (rotation * offset);
		
		
		transform.LookAt(target.transform);
		transform.position = transform.position + yAdjust;
	}
			
}