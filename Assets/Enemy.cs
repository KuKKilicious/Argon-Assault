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
    int scoreWorth;
	// Use this for initialization
	void Start () {
        AddNonTriggerBoxCollider(); 
        
	}

    private void AddNonTriggerBoxCollider() {
        BoxCollider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }

    private void OnParticleCollision(GameObject other) {
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);

        fx.transform.parent = parent;
        Destroy(gameObject);
    }
}
