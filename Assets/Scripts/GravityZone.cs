using UnityEngine;

public class GravityZone : MonoBehaviour
{
    [Header("Gravity for this zone")]
    public Vector3 gravity = new Vector3(0, -9.81f, 0);

    [Header("Reference to XR Origin root")]
    public Transform xrRigRoot;

    [SerializeField] private AudioClip zoneMusic;

    private void OnTriggerEnter(Collider other)
    {
        // Only react when the XR rig root enters
        if (other.transform != xrRigRoot)
            return;

        // Set global gravity
        Physics.gravity = gravity;

        // Switch background music
        if (MusicManager.instance != null)
        {
            MusicManager.instance.PlayMusic(zoneMusic, 1f);
        }
    }
}
