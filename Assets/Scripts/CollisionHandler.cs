using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour {
    [Tooltip("In seconds")][SerializeField]
    float levelLoadDelay = 1f;
    [SerializeField]
    GameObject explosion;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other) {
        StartDeathSequence();
    }

    private void StartDeathSequence() {
        Debug.Log("OnPlayerDeath called from collisionHandler");
        SendMessage("OnPlayerDeath");
        if (explosion) {
            explosion.SetActive(true);
        }
        StartCoroutine(ReloadLevel());
    }

    private IEnumerator ReloadLevel() {
        yield return new WaitForSeconds(levelLoadDelay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
