using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {
    [Header("General")]
    [Tooltip("In ms^-1")]
    [SerializeField]
    float xMovementSpeed = 16f;

    [Tooltip("In ms^-1")]
    [SerializeField]
    float yMovementSpeed = 9f;
    //Values for Mathf.Clamp to prohi
    [Tooltip("local position Boundary")]
    [SerializeField]
    float xClampMinMax = 8.8f;
    [Tooltip("local position Boundary")]
    [SerializeField]
    float yClampMinMax = 4.7f;

    [Header("Screen-position based")]
    [SerializeField]
    float positionPitchFactor = -3f;
    [SerializeField]
    float positionYawFactor = 2f;
    [Header("Control-throw Based")]
    [SerializeField]
    float controlRollFactor = -20f;
    [SerializeField]
    float controlPitchFactor = -8f;
    float horizontalThrow, verticalThrow;
    bool isControlEnabled = true;
    // Update is called once per frame
    void Update() {

        if (isControlEnabled) {
        //Process Translation
        HandleMovement();
        //Process Rotation
        AdjustRotation();
        }
    }

    

    private void HandleMovement() {
        horizontalThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        verticalThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffset = horizontalThrow * xMovementSpeed * Time.deltaTime;
        float yOffset = verticalThrow * yMovementSpeed * Time.deltaTime;

        float rawNewXPos = transform.localPosition.x + xOffset;
        float rawNewYPos = transform.localPosition.y + yOffset;

        float clampedNewXPos = Mathf.Clamp(rawNewXPos, -1 * xClampMinMax, xClampMinMax);
        float clampedNewYPos = Mathf.Clamp(rawNewYPos, -1 * yClampMinMax, yClampMinMax);

        transform.localPosition = new Vector3(clampedNewXPos, clampedNewYPos, transform.localPosition.z);

    }

    private void AdjustRotation() {
        float pitch = transform.localPosition.y * positionPitchFactor + verticalThrow * controlPitchFactor;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = horizontalThrow * controlRollFactor +Mathf.Abs(transform.localPosition.x)*(-3* Mathf.Sign(transform.localPosition.x)* Mathf.Sign(transform.localPosition.y));
        transform.localRotation = Quaternion.Euler(pitch,yaw,roll);
    }
    private void OnPlayerDeath() { //called by string reference
        Debug.Log("OnPlayerDeath called");
    }
}
