using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AdamBielecki.SolarSystem
{
  public class FollowOrbit : MonoBehaviour
  {

    public GameObject orbitToFollow;
    public float orbitSpeed;

    private int numberOfpositions;
    private LineRenderer lineRenderer;

    public int earthOffset = 1;

    private Vector3[] localOrbitPositions;

    private int startEarthOffset;
    // Use this for initialization
    void Start()
    {

      if (orbitToFollow != null)
      {
        startEarthOffset = earthOffset;
        lineRenderer = orbitToFollow.GetComponent<LineRenderer>();
        numberOfpositions = lineRenderer.positionCount;
        transform.localPosition = orbitToFollow.transform.TransformPoint(lineRenderer.GetPosition(numberOfpositions - earthOffset));

        // save obrbit local positions for reference, so we do not have to calculate global position on coroutine
        localOrbitPositions = new Vector3[lineRenderer.positionCount];
        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
          localOrbitPositions[i] = orbitToFollow.transform.TransformPoint(lineRenderer.GetPosition(i));
        }

        StartCoroutine(ConstantValues.FollowOrbitCoroutine);
      }
    }

        private IEnumerator MoveOnOrbit()
        {
            // move on orbit 
            while (Mathf.Abs(orbitSpeed) > 0)
            {
                if (transform.position == localOrbitPositions[numberOfpositions - earthOffset])
                {
                    earthOffset += 4;
                }
                else
                {
                    transform.position = Vector3.MoveTowards(transform.position, localOrbitPositions[numberOfpositions - earthOffset], Time.deltaTime * orbitSpeed);
                }

                if (earthOffset >= numberOfpositions)
                {
                    earthOffset = 1;
                }
                yield return null;
            }
        }
    }
}