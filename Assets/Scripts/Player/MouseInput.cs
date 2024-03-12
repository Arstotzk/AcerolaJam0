using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour
{
    public float mouseSensX = 1000f;
    public float mouseSensY = 1000f;

    public Transform playerBody;
    public bool isReverted = false;
    public bool isNarrow = false;
    public Quaternion narrowRotation;

    float rotationX = 0f;

    public bool isBlockMove = false;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (isBlockMove)
            return;
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

        if (isNarrow)
        {
            playerBody.rotation = narrowRotation;
            return;
        }
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
