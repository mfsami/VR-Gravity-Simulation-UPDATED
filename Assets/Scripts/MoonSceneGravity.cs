using UnityEngine;

public class MoonSceneGravity : MonoBehaviour
{
    
    void Start()
    {
        Physics.gravity = new Vector3(0, -1.635f, 0);
    }

    
}
