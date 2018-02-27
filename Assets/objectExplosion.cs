using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectExplosion : MonoBehaviour {
    public ParticleSystem enemyExplosion;
    public bool _sabog;
    // Use this for initialization
    void Start () {
        _sabog = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnParticleCollision(GameObject other)
    {
        if (_sabog == false)
        {
            if (other.gameObject.tag == "bullet")
            {
                enemyExplosion.Play();
                _sabog = true;
            }
        }
    }
}
