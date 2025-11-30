using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ResetObj : MonoBehaviour
{
    private Vector3 startPos;
    private Quaternion startRot;
    private Rigidbody rb;



    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        if (rb == null)
        {
            Debug.LogError("ResetObj on " + gameObject.name + " has NO Rigidbody!");
            return;
        }

        // store original positions
        startPos = transform.position;
        startRot = transform.rotation;
    }

    public void Reset()
    {
        if (rb == null)
        {
            Debug.LogError("ResetObj: rb is null on " + gameObject.name);
            return;
        }

        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        //rb.Sleep();

        transform.position = startPos;
        transform.rotation = startRot;
        //rb.Sleep();

    }
}
