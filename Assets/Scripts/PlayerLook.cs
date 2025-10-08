using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    // TODO Add comments

    // Fields

    public float sensitivity = 5f;

    private float xRotation;
    private float yRotation;

    // Methods

    private void Start()
    {
        Cursor.visible = false; // Hide mouse cursor
        Cursor.lockState = CursorLockMode.Locked; // Lock mouse cursor to the center of the screen
    }

    private void Update()
    {
        Look();
    }

    private void Look()
    {
        // Get horizontal look input
        xRotation += Input.GetAxis("Mouse X") * sensitivity;

        // Get vertical look input
        yRotation -= Input.GetAxis("Mouse Y") * sensitivity;
        yRotation = Mathf.Clamp(yRotation, -90f, 90f); // Stop the player from looking upside-down

        // Apply horizontal & vertical look input
        transform.localRotation = Quaternion.Euler(yRotation, xRotation, 0f);
    }

    public void SetLookDirection(Quaternion worldRotation)
    {
        Vector3 euler = worldRotation.eulerAngles;

        xRotation = euler.y;
        yRotation = Mathf.Clamp(NormalizeAngle(-euler.x), -90f, 90f);

        transform.localRotation = Quaternion.Euler(yRotation, xRotation, 0f);
    }

    private float NormalizeAngle(float angle)
    {
        angle %= 360f;
        if (angle > 180f) angle -= 360f;
        return angle;
    }
}
