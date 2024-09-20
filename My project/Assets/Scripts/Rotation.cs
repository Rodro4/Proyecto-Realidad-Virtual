using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Xml;
using Unity.XR.CoreUtils;
using UnityEngine.XR.Interaction.Toolkit;
using Bhaptics.SDK2;

public class Rotation : MonoBehaviour
{
    private InputAction actionRotate, actionNullifyRotation;
    [SerializeField] private InputActionAsset myActionsAsset;
    Rigidbody myRigidbody;
    [SerializeField] private float Speed;
    private float xValue;
    private float yValue;
    private bool pressedDown;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        actionRotate = myActionsAsset.FindAction("XRI RightHand Locomotion/Move");
        actionRotate.performed += Rotate;
        actionRotate.canceled += RotateCancel;
        actionNullifyRotation = myActionsAsset.FindAction("XRI RightHand Locomotion/Cancel Angular Velocity");
        actionNullifyRotation.performed += NullifyRotation;
    
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (pressedDown)
        {
            myRigidbody.AddRelativeTorque(Vector3.up * xValue * Speed * Time.fixedDeltaTime, ForceMode.Acceleration);
            myRigidbody.AddRelativeTorque(Vector3.left * yValue * Speed * Time.fixedDeltaTime, ForceMode.Acceleration);

            if (xValue <= 0 && yValue <= 0)
            {
                BhapticsLibrary.PlayParam(BhapticsEvent.PANEOARRIBA, -yValue * 0.5f, 1f, 0f, 0f);
                BhapticsLibrary.PlayParam(BhapticsEvent.RIGHTSPIN, -xValue, 1f, 0f, 0f);
            }
            else if (xValue <= 0 && yValue >= 0)
            {
                BhapticsLibrary.PlayParam(BhapticsEvent.PANEOABAJO, yValue * 0.5f, 1f, 0f, 0f);
                BhapticsLibrary.PlayParam(BhapticsEvent.RIGHTSPIN, -xValue, 1f, 0f, 0f);
            }
            else if (xValue >= 0 && yValue >= 0)
            {
                BhapticsLibrary.PlayParam(BhapticsEvent.PANEOABAJO, yValue * 0.5f, 1f, 0f, 0f);
                BhapticsLibrary.PlayParam(BhapticsEvent.LEFTSPIN, xValue, 1f, 0f, 0f);
            }
            else if (xValue >= 0 && yValue <= 0)
            {
                BhapticsLibrary.PlayParam(BhapticsEvent.PANEOARRIBA, -yValue * 0.5f, 1f, 0f, 0f);
                BhapticsLibrary.PlayParam(BhapticsEvent.LEFTSPIN, xValue, 1f, 0f, 0f);

            }
        }
    }

    void Rotate(InputAction.CallbackContext context)
    {

        xValue = context.ReadValue<Vector2>().x;
        yValue = context.ReadValue<Vector2>().y;

        pressedDown = true;

    }

    void RotateCancel(InputAction.CallbackContext context)
    {
        pressedDown = false;
    }

    void NullifyRotation(InputAction.CallbackContext context)
    {
        BhapticsLibrary.PlayParam(BhapticsEvent.ESTABILIZADOR, 0.7f, 1f, 0f, 0f);
        myRigidbody.velocity = Vector3.zero;
        myRigidbody.angularVelocity= Vector3.zero;
    }
}
