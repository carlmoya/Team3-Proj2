using UnityEngine;

public class GravityBeam : MonoBehaviour
{
    // Fields

    public Color beamColor;
    public Transform beamOrigin;

    private PlayerGrab playerGrab;
    private LineRenderer lineRenderer;

    // Methods

    private void Start()
    {
        // Get reference to beam origin
        beamOrigin = GetComponentInChildren<Transform>();

        // Get reference to player grab
        playerGrab = FindFirstObjectByType<PlayerGrab>();

        // Get reference to line renderer
        lineRenderer = GetComponent<LineRenderer>();

        // Set the line renderer's material
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));

        // Set the line renderer's start width
        lineRenderer.startWidth = 0.1f;

        // Set the line renderer's end width
        lineRenderer.endWidth = 0.1f;
    }

    private void Update()
    {
        ShootBeam();
        SetColor();
    }

    private void ShootBeam()
    {
        // Set the line renderer's start position to the beam origin
        lineRenderer.SetPosition(0, beamOrigin.position);

        // Set the line renderer's end position to the grabbed object
        lineRenderer.SetPosition(1, playerGrab.LookDirection().GetPoint(25f));
    }

    private void SetColor()
    {
        // If the player is grabbing something
        if (playerGrab.GrabbedObject() != null)
        {
            // Set the line renderer's start color to the beam color
            lineRenderer.startColor = beamColor;

            // Set the line renderer's end color to the beam color
            lineRenderer.endColor = beamColor;
        }
        else // If the player is not grabbing something
        {
            // Set the line renderer's start color to invisible
            lineRenderer.startColor = new Color(0, 0, 0, 0);

            // Set the line renderer's end color to invisible
            lineRenderer.endColor = new Color(0, 0, 0, 0);
        }
    }
}
