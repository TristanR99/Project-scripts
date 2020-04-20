using UnityEngine;

namespace Com.VRProject.Tristan
{
  public class MouseLook : MonoBehaviour
  {
    public float mouseSensitivity = 100f;
    private Transform cameraTransform;
    public Transform playerBody;

    float xRotation = 0f;

    void Start()
    {
      Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
      bool escape = Input.GetButtonUp("Cancel");
      if (escape)
      {
        if (Cursor.lockState == CursorLockMode.Locked)
        {
          Cursor.lockState = CursorLockMode.None;
        }
        else
        {
          Cursor.lockState = CursorLockMode.Locked;
        }
      }

      if (Cursor.lockState == CursorLockMode.Locked)
      {
        ProcessInputs();
      }
    }

    void ProcessInputs()
    {
      float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
      float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

      xRotation -= mouseY;
      xRotation = Mathf.Clamp(xRotation, -90f, 90f);
      transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
      playerBody.Rotate(Vector2.up * mouseX);
    }
  }
}
