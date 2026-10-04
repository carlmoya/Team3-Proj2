using UnityEngine;

// Project L.I.F.E

public class PlayerLook : MonoBehaviour
{
    // Fields

    public float sensitivity = 5f;

    private float xRotation;
    private float yRotation;

    // Methods

    private void Start()
    {
        // Disble mouse cursor
        SetCursor(false);
    }

    private void Update()
    {
        // Move the player camera
        Look();
    }

    private void Look()
    {
        // Get horizontal mouse look input
        xRotation += Input.GetAxis("Mouse X") * sensitivity;

        // Get vertical mouse look input
        yRotation -= Input.GetAxis("Mouse Y") * sensitivity;

        // Stop the player from looking upside-down
        yRotation = Mathf.Clamp(yRotation, -90f, 90f);

        // Apply horizontal & vertical look input
        transform.localRotation = Quaternion.Euler(yRotation, xRotation, 0f);
    }

    public void SetCursor(bool enable)
    {
        Cursor.visible = enable;

        Cursor.lockState = enable ? CursorLockMode.Confined : CursorLockMode.Locked;
    }

    // Return Methods

    public Quaternion FlatCameraRotation()
    {
        return Quaternion.Euler(0f, transform.eulerAngles.y, 0f);
    }
}
