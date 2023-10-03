using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f; // Movement speed
    public float sensitivity = 2.0f; // Mouse sensitivity

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
       

        // Mouse look
        float rotateHorizontal = Input.GetAxis("Mouse X");
        float rotateVertical = -Input.GetAxis("Mouse Y");
        transform.Rotate(0, rotateHorizontal * sensitivity, 0);
        Camera.main.transform.Rotate(rotateVertical * sensitivity, 0, 0);
    }
}
