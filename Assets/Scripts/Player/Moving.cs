using UnityEngine;

public class Moving : MonoBehaviour
{
    private CharacterController controller;
    private float x;
    private float z;
    private Vector3 dir;
    [SerializeField] private Vector3 velocity;
    [SerializeField] private float gravity = -12f;
    private float speed=5;
    private float jumph=4;
    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && controller.isGrounded)
        {
            velocity.y = jumph;
            //velocity.y = Mathf.Sqrt(jumph * -2f * gravity);
        }
        else if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -6f;
        }
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        dir = transform.right * x + transform.forward * z;
        velocity.y += gravity * Time.deltaTime;
        controller.Move(dir*speed*Time.deltaTime);
        controller.Move(velocity * Time.deltaTime);
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.TryGetComponent<Rigidbody>(out Rigidbody component))
        {
            hit.rigidbody.AddForce(dir * 10 * Time.deltaTime,ForceMode.Impulse);
        }
    }
}
