using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using Bhaptics.SDK2;

public class VerticalMovement : MonoBehaviour
{
    [SerializeField] private InputActionAsset myActionsAsset;
    private InputAction actionUp, actionDown;

    Rigidbody myRigidbody;
    [SerializeField] private float Speed;
    private bool downPressed;
    private bool upPressed;

    public AudioSource izqAudio;
    public AudioSource derAudio;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        actionUp = myActionsAsset.FindAction("XRI RightHand Locomotion/Move Upwards");
        actionUp.performed += MoveUp;
        actionUp.canceled += UpCancel;
        actionDown = myActionsAsset.FindAction("XRI RightHand Locomotion/Move Downwards");
        actionDown.performed += MoveDown;
        actionDown.canceled += DownCancel;
    }

    void FixedUpdate()
    {
        if (upPressed)
        {
            derAudio.Play();
            izqAudio.Play();
            myRigidbody.AddRelativeForce(0, Speed * Time.fixedDeltaTime, 0, ForceMode.Acceleration);
            BhapticsLibrary.PlayParam(BhapticsEvent.UPJETPACK, 0.1f, 1f, 0f, 0f);
        }
        if (downPressed)
        {
            derAudio.Play();
            izqAudio.Play();
            myRigidbody.AddRelativeForce(0, -Speed * Time.fixedDeltaTime, 0, ForceMode.Acceleration);
            BhapticsLibrary.PlayParam(BhapticsEvent.DOWNJETPACK, 0.1f, 1f, 0f, 0f);
        }
    }

    void MoveUp(InputAction.CallbackContext context)
    {
        upPressed = true;
    }

    void UpCancel(InputAction.CallbackContext context)
    {
        upPressed = false;
    }

    void MoveDown(InputAction.CallbackContext context)
    {
        downPressed = true;
    }

    void DownCancel(InputAction.CallbackContext context)
    {
        downPressed = false;
    }
}
