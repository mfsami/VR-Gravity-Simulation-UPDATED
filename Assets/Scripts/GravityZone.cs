using UnityEngine;

public class GravityZone : MonoBehaviour
{
    [Header("Gravity for this zone")]
    public Vector3 gravity = new Vector3(0, -9.81f, 0);   // default Earth

    [Header("Reference to XR Origin root")]
    public Transform xrRigRoot;  

    private void OnTriggerEnter(Collider other)
    {
        // Only change gravity when the XR rig enters
        if (other.transform == xrRigRoot)
        {
            Physics.gravity = gravity;
            Debug.Log("Gravity changed to: " + gravity);
        }
    }
}
