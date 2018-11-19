using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {
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

    [SerializeField]
    float positionPitchFactor = -3f;
    [SerializeField]
    float controlPitchFactor = -8f;
    [SerializeField]
    float positionYawFactor = 2f;
    [SerializeField]
    float positionRollFactor = -20f;

    float horizontalThrow, verticalThrow;
    // Update is called once per frame
    void Update() {

        
        //Process Translation
        HandleMovement();
        //Process Rotation
        AdjustRotation();
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
        float roll = horizontalThrow * positionRollFactor;
        transform.localRotation = Quaternion.Euler(pitch,yaw,roll);
    }

}
