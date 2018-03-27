using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ParticleExplosion : MonoBehaviour {
    public ParticleSystem particleExplosion;
    public Slider HealthSlider;
    public int PlayerHealth;
    Rigidbody _rigidbody;
    bool _shipCollided = false;
    AudioSource _audioSource;
    GameObject[] gameObjects;

    void Start() {
        _rigidbody = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
        PlayerHealth = 100;
    }

    // Update is called once per frame
    void Update() {
        HealthSlider.value = PlayerHealth;
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
                PlayerHealth-=20;
               /* _audioSource.Play();
                particleExplosion.Play();
                print("Boom!");
                Destroy(GameObject.FindWithTag("bullet"));
                gameObjects = GameObject.FindGameObjectsWithTag("bullet");
                for (var i = 0; i < gameObjects.Length; i++)
                {
                    Destroy(gameObjects[i]);
                }
                _shipCollided = true;
                StartCoroutine("ExecuteAfterTime");*/
            }
            else if (gameObject.tag == "Player" && collision.collider.tag == "terrain")
            {
                PlayerHealth-=20;
                /*particleExplosion.Play();
                _audioSource.Play();
                print("Terrain!");
                Destroy(GameObject.FindWithTag("bullet"));
                gameObjects = GameObject.FindGameObjectsWithTag("bullet");
                for (var i = 0; i < gameObjects.Length; i++)
                {
                    Destroy(gameObjects[i]);
                }
                _shipCollided = true;
                StartCoroutine("ExecuteAfterTime");*/
            }
            if (PlayerHealth <= 0)
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
