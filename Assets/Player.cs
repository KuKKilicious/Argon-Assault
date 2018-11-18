using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {
    [Tooltip("In ms^-1")]
    [SerializeField]
    float xMovementSpeed = 5f;

    [Tooltip("In ms^-1")]
    [SerializeField]
    float yMovementSpeed = 5f;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        HandleMovement();
    }

    private void HandleMovement() {
        float horizontalThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float verticalThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffset = horizontalThrow * xMovementSpeed * Time.deltaTime;
        float yOffset = verticalThrow * yMovementSpeed * Time.deltaTime;

        print(xOffset);
        /* if (horizontalThrow > Mathf.Epsilon) {
             transform.position =
         }

         if (verticalThrow > Mathf.Epsilon) {
             transform.position = 
         }
         */
    }
}
