using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform player;
    private float x_dir = 0f;
    private float x_rot;
    private float y_rot;
    private float mouse_sens = 3;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        x_rot = Input.GetAxis("Mouse X") * mouse_sens;
        y_rot = Input.GetAxis("Mouse Y") * mouse_sens;
        x_dir = Mathf.Clamp(x_dir, -90, 90);
        x_dir -= y_rot;
        transform.localRotation = Quaternion.Euler(x_dir, 0f, 0f);
        player.Rotate(Vector3.up * x_rot);
    }
}
