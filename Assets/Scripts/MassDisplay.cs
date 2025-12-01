using UnityEngine;
using TMPro;

public class MassDisplay : MonoBehaviour
{
    [Header("Mass settings")]
    [SerializeField] private float baseMassKg = 1f;   // mass shown at original size

    [Header("References")]
    [SerializeField] private TextMeshPro massLabel;   // your text above the object

    private Vector3 startScale;

    private void Awake()
    {
        startScale = transform.localScale;

        if (massLabel == null)
            massLabel = GetComponentInChildren<TextMeshPro>();

        UpdateMassDisplay();
    }

    private void Update()
    {
        UpdateMassDisplay();
    }

    private void UpdateMassDisplay()
    {
        // Scale factor relative to the original size
        float scaleFactor = transform.localScale.x / startScale.x;

        // Fake mass = base mass × scale factor
        float displayedMass = baseMassKg * scaleFactor;

        // Update text (1 decimal)
        if (massLabel != null)
            massLabel.text = displayedMass.ToString("0.0") + " kg";
    }
}
