using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Xml;
using Bhaptics.SDK2;

public class Movement : MonoBehaviour
{
    private InputAction actionMove, actionNullifyMovement;
    [SerializeField] private InputActionAsset myActionsAsset;
    Rigidbody myRigidbody;
    [SerializeField] private float Speed;
    private float xValue;
    private float yValue;
    private bool pressedDown;

    public AudioSource izqAudio;
    public AudioSource derAudio;

    void Start()
    {
        UnityEngine.Application.targetFrameRate = 72;
        myRigidbody = GetComponent<Rigidbody>();
        actionMove = myActionsAsset.FindAction("XRI LeftHand Locomotion/Move");
        actionMove.performed += Move;
        actionMove.canceled += MoveCancel;
        // actionNullifyMovement = myActionsAsset.FindAction("XRI LeftHand Locomotion/Reset Rotation");
        // actionNullifyMovement.performed += NullifyMovement;
    }
    private void FixedUpdate()
    {
        if (pressedDown)
        {
            myRigidbody.AddRelativeForce(xValue * Speed * Time.fixedDeltaTime, 0, yValue * Speed * Time.fixedDeltaTime, ForceMode.Acceleration);
            if (xValue <= 0 && yValue <= 0)
            {
                izqAudio.Play();
                BhapticsLibrary.PlayParam(BhapticsEvent.BACKJET, -yValue * 0.05f, 1f, 0f, 0f);
                BhapticsLibrary.PlayParam(BhapticsEvent.RIGHTJET, -xValue * 0.05f, 1f, 0f, 0f);
            }
            else if (xValue <= 0 && yValue >= 0)
            {
                izqAudio.Play();
                BhapticsLibrary.PlayParam(BhapticsEvent.FRONT, yValue * 0.05f, 1f, 0f, 0f);
                BhapticsLibrary.PlayParam(BhapticsEvent.RIGHTJET, -xValue * 0.05f, 1f, 0f, 0f);
            }
            else if (xValue >= 0 && yValue >= 0)
            {
                derAudio.Play();
                BhapticsLibrary.PlayParam(BhapticsEvent.FRONT, yValue * 0.05f, 1f, 0f, 0f);
                BhapticsLibrary.PlayParam(BhapticsEvent.LEFTJET, xValue * 0.05f, 1f, 0f, 0f);
            }
            else if (xValue >= 0 && yValue <= 0)
            {
                derAudio.Play();
                BhapticsLibrary.PlayParam(BhapticsEvent.BACKJET, -yValue * 0.05f, 1f, 0f, 0f);
                BhapticsLibrary.PlayParam(BhapticsEvent.LEFTJET, xValue * 0.05f, 1f, 0f, 0f);
            }
        }
    }

    void Move(InputAction.CallbackContext context)
    {
        xValue = context.ReadValue<Vector2>().x;
        yValue = context.ReadValue<Vector2>().y;


        pressedDown = true;

    }

    void MoveCancel(InputAction.CallbackContext context)
    {
        pressedDown = false;
    }
}
