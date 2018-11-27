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
    [SerializeField]
    int hits = 3;
    private ScoreBoard scoreBoard;
    // Use this for initialization
    void Start() {
        scoreBoard = FindObjectOfType<ScoreBoard>();

        AddNonTriggerBoxCollider();

    }

    private void AddNonTriggerBoxCollider() {
        BoxCollider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }

    private void OnParticleCollision(GameObject other) {
        ProcessHit();
        if (hits < 1) {
            KillEnemy();
        }
    }

    private void ProcessHit() {
        scoreBoard.ScoreHit(scoreWorth);
        hits -= 1;
        //consider additional FX
    }

    private void KillEnemy() {
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        scoreBoard.ScoreHit(scoreWorth); // todo: add another scoreValue

        Destroy(gameObject);
    }
}
