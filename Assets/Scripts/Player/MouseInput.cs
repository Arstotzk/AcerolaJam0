using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour
{
    public float mouseSensX = 1000f;
    public float mouseSensY = 1000f;

    public Transform playerBody;
    public bool isReverted = false;

    float rotationX = 0f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        var revert = 1f;
        if (isReverted)
            revert = -1f;
        float mouseX = Input.GetAxis("Mouse X") * mouseSensX * Time.deltaTime * revert;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensY * Time.deltaTime * revert;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);
        var rotationZ = 0f;
        if (isReverted)
            rotationZ = 180f;
        transform.localRotation = Quaternion.Euler(rotationX, 0f, rotationZ);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
