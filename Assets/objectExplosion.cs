using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectExplosion : MonoBehaviour {
    public ParticleSystem enemyExplosion;
    public ParticleSystem enemyDamaged;
    public bool _sabog;
    public int _EnemyHealth;
    public bool _isDamaged;
    // Use this for initialization
    void Start () {
        _sabog = false;
        _isDamaged = false;
        _EnemyHealth = 100;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnParticleCollision(GameObject other)
    {
        if (!_sabog)
        {
            if (other.gameObject.tag == "bullet" && _EnemyHealth > 0)
            {
                _EnemyHealth--;
                print(_EnemyHealth);
            }
            if (_EnemyHealth <= 50 && !_isDamaged)
            {
                enemyDamaged.Play();
                _isDamaged = true;
            }
            if(_EnemyHealth <= 0 && !_sabog)
            {
                Destroy(gameObject, 1f);
                enemyExplosion.Play();
                _sabog = true;
            }
        }
    }
}
