using UnityEngine;
using UnityEngine.InputSystem;

public class MenuToggleAndPosition : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform xrCamera;         // your VR camera (HMD)
    [SerializeField] private GameObject menuRoot;        // the menu Canvas root
    [SerializeField] private InputActionReference menuAction; // button action

    [Header("Placement")]
    [SerializeField] private float distanceInFront = 1.5f;
    [SerializeField] private float verticalOffset = -0.2f; // little bit below eye level

    private void OnEnable()
    {
        if (menuAction != null)
        {
            menuAction.action.performed += OnMenuPressed;
            menuAction.action.Enable();
        }
    }

    private void OnDisable()
    {
        if (menuAction != null)
        {
            menuAction.action.performed -= OnMenuPressed;
            menuAction.action.Disable();
        }
    }

    private void OnMenuPressed(InputAction.CallbackContext ctx)
    {
        if (xrCamera == null || menuRoot == null) return;

        // Toggle active state
        bool newActive = !menuRoot.activeSelf;
        menuRoot.SetActive(newActive);

        if (!newActive) return; // if we're closing, no need to reposition

        // Place menu in front of camera
        Vector3 forward = xrCamera.forward;
        // keep it level on y so it doesn't tilt up/down with head pitch
        forward.y = 0f;
        forward.Normalize();

        Vector3 targetPos = xrCamera.position + forward * distanceInFront;
        targetPos.y += verticalOffset;

        menuRoot.transform.position = targetPos;

        // Rotate menu to face the camera
        menuRoot.transform.rotation = Quaternion.LookRotation(forward, Vector3.up);
    }
}
