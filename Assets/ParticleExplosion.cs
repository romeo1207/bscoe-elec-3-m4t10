using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ParticleExplosion : MonoBehaviour {
    public ParticleSystem particleExplosion;
    Rigidbody _rigidbody;
    bool _shipCollided = false;
    AudioSource _audioSource;
    GameObject[] gameObjects;

    void Start() {
        _rigidbody = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {
       
    }

    IEnumerator ExecuteAfterTime(){
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("level1");
    }

    void OnCollisionEnter(Collision collision)
    {
        if(_shipCollided == false){
            if((gameObject.tag == "Player" && collision.collider.tag == "obstacle") || (gameObject.tag == "Player" && collision.collider.tag == "enemy"))
            {
                _audioSource.Play();
                particleExplosion.Play();
                print("Boom!");
                Destroy(GameObject.FindWithTag("bullet"));
                gameObjects = GameObject.FindGameObjectsWithTag("bullet");
                for (var i = 0; i < gameObjects.Length; i++)
                {
                    Destroy(gameObjects[i]);
                }
                _shipCollided = true;
                StartCoroutine("ExecuteAfterTime");
            }
            else if (gameObject.tag == "Player" && collision.collider.tag == "terrain")
            {
                particleExplosion.Play();
                _audioSource.Play();
                print("Terrain!");
                Destroy(GameObject.FindWithTag("bullet"));
                gameObjects = GameObject.FindGameObjectsWithTag("bullet");
                for (var i = 0; i < gameObjects.Length; i++)
                {
                    Destroy(gameObjects[i]);
                }
                _shipCollided = true;
                StartCoroutine("ExecuteAfterTime");
            }
        }
    }      
}
