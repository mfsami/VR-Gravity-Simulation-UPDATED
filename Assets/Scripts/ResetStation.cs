using UnityEngine;

public class ResetStation : MonoBehaviour
{
    public ResetObj[] objects;

    private void Awake()
    {
        objects = GetComponentsInChildren<ResetObj>();
    }

    public void Reset()
    {
        foreach (var obj in objects)
        {
            obj.Reset();
        }

    }
 
}
