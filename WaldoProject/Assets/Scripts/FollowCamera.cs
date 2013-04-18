using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

public class FollowCamera : MonoBehaviour {
    public GameObject target;
    Vector3 offset;
    void Start() {
        offset = target.transform.position - transform.position;
    }
	
	// Update is called once per frame
	void LateUpdate() {
	    float desiredAngle = target.transform.eulerAngles.y;
	    Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
		transform.position = target.transform.position - (rotation * offset);		
		transform.LookAt(target.transform);
	}
			
}
}