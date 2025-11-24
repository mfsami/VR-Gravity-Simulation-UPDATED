using UnityEngine;

namespace AdamBielecki.SolarSystem
{
  public class ObjectRotation : MonoBehaviour
  {

    public static float planetSpeedRotation = 10f;

    // Update is called once per frame
    void LateUpdate()
        {
            transform.Rotate(Vector3.up * planetSpeedRotation * Time.deltaTime);
        }
  }
}