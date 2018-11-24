using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    [SerializeField]
    GameObject deathFX;
    [SerializeField]
    Transform parent;
    [SerializeField]
    int scoreWorth = 17;
    private ScoreBoard scoreBoard;
	// Use this for initialization
	void Start () {
        scoreBoard = FindObjectOfType<ScoreBoard>();

        AddNonTriggerBoxCollider(); 
        
	}

    private void AddNonTriggerBoxCollider() {
        BoxCollider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }

    private void OnParticleCollision(GameObject other) {
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        
        fx.transform.parent = parent;

        scoreBoard.ScoreHit(scoreWorth);
        Destroy(gameObject);
    }
}
