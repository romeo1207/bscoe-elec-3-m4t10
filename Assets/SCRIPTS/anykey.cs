using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class anykey : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    void LoadGameScene()
    {
        SceneManager.LoadScene("level1");
    }

    // Update is called once per frame
    void Update () {
        if (Input.anyKey)
        {
            LoadGameScene();
        }
    }
}
