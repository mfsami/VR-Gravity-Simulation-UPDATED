using UnityEngine;
using TMPro;

public class ObjectGravityUI : MonoBehaviour
{
    public TextMeshPro gravityInfo;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MoonZone"))
            gravityInfo.text = "Moon Gravity:\n1.6 m/s²";
        else if (other.CompareTag("EarthZone"))
            gravityInfo.text = "Earth Gravity:\n9.8 m/s²";
    }
}
