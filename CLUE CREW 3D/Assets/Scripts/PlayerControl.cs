using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public CharacterController controller;
    public background background;
    public Camera playerCam;
    public Vector3 playerVelocity;
    public float playerSpeed = 6f, mouseSensitivity = 200f;
    float xRotation = 0f;
    public bool guessing = false;
    Vector3 move = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -75f, 55f);

        if(!guessing)
        {
            playerCam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            transform.Rotate(Vector3.up * mouseX);
        }


        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * Time.deltaTime * playerSpeed);
    }

    void OnCollisionStay(Collision col)
    {
        GameObject other = col.collider.gameObject;
        if(other.tag == "Room")
        {
            background.InRoom(other.name);
        }
    }
}
