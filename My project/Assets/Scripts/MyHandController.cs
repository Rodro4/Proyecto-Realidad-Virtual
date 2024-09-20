using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
public class MyHandController : MonoBehaviour
{
    [SerializeField] InputActionReference actionGrip;
    [SerializeField] InputActionReference actionTrigger;
    private Animator handAnimator;

    private void Update()
    {
        if (!actionTrigger.action.IsPressed())
        {
            handAnimator.SetFloat("Trigger", 0);
        }
        if (!actionGrip.action.IsPressed())
        {
            handAnimator.SetFloat("Grip", 0);
        }
    }

    void Start()
    {
        actionTrigger.action.performed += TriggerPress;
        
        actionGrip.action.performed += GripPress;
        handAnimator = GetComponent<Animator>();
    }
    private void GripPress(InputAction.CallbackContext obj)
    {
        float value = obj.ReadValue<float>();
        handAnimator.SetFloat("Grip", value);
    }
    private void TriggerPress(InputAction.CallbackContext obj)
    {
        handAnimator.SetFloat("Trigger", obj.ReadValue<float>());
    }
}
