using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroy : MonoBehaviour {
    public bool _collision;
    void Start () {
        _collision = true;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnParticleCollision(GameObject other){
        if (other.gameObject.tag == "enemy"){
            other.gameObject.tag = "Untagged";
            Destroy(other,1f);
           // Destroy(other.transform.parent.gameObject);
        }
    }
}
