using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] float mouseSense = 100f;
    [SerializeField] Transform playerBody;
    [SerializeField] Transform playerArms;
    [SerializeField] Transform cam;

    float xAxisClamp = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSense * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSense * Time.deltaTime;

        xAxisClamp -= mouseY;
        xAxisClamp = Mathf.Clamp(xAxisClamp, -90f, 90f);

        cam.localRotation = Quaternion.Euler(xAxisClamp, 0f, 0f);

        playerBody.Rotate(Vector3.up * mouseX);

        playerArms.localRotation = cam.localRotation;
    }
}
