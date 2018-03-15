using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectExplosion : MonoBehaviour {
    public ParticleSystem enemyExplosion;
    public ParticleSystem enemyDamaged;
    public bool _sabog;
    public int _EnemyHealth;
    public int _HalfLife;
    public bool _isDamaged;
    public int AddScore;
    AudioSource _audioSource;
    // Use this for initialization
    void Start () {
        _sabog = false;
        _isDamaged = false;
        _audioSource = GetComponent<AudioSource>();
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
            if (_EnemyHealth <= _HalfLife && !_isDamaged)
            {
                enemyDamaged.Play();
                _isDamaged = true;
            }
            if(_EnemyHealth <= 0 && !_sabog)
            {
                gameObject.tag = "Untagged";
                Destroy(gameObject, 1f);
                Destroy(gameObject.transform.parent);
                enemyExplosion.Play();
                _sabog = true;
                ScoreManager.Score += AddScore;
                _audioSource.Play();
            }
        }
    }
}
