using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    [SerializeField] Transform playerCamera = null;
    [SerializeField] float mouseSensitivity = 4f;
    [SerializeField] float walkSpeed = 6f;
    [SerializeField] float sprintSpeed = 9f;
    [SerializeField] float jumpHeight = 3f;
    [SerializeField] float gravity = -10f;
    [SerializeField, Range(0.0f, 0.5f)] float moveSmooth = 0.3f;
    [SerializeField, Range(0.0f, 0.5f)] float mouseSmooth = 0.03f;
    [SerializeField] bool lockCursor = true;

    float cameraPitch = 0.0f;

    CharacterController characterController = null;

    Vector3 velocity;
    Vector3 currentDirection = Vector3.zero;
    Vector3 currentDirectionVelocity = Vector3.zero;
    Vector3 currentMouseDelta = Vector3.zero;
    Vector3 currentMouseDeltaVelocity = Vector3.zero;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    void Update()
    {
        FirstPersonView();
        Movement();
    }

    void FirstPersonView()
    {
        Vector3 targetMouseDelta = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0);

        currentMouseDelta = Vector3.SmoothDamp(currentMouseDelta, targetMouseDelta, ref currentMouseDeltaVelocity, mouseSmooth);

        cameraPitch -= currentMouseDelta.y * mouseSensitivity;
        cameraPitch = Mathf.Clamp(cameraPitch, -90f, 90f);
        playerCamera.localEulerAngles = Vector3.right * cameraPitch;

        transform.Rotate(Vector3.up * currentMouseDelta.x * mouseSensitivity);
    }

    void Movement()
    {
        Vector3 targetDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        targetDirection.Normalize();

        currentDirection = Vector3.SmoothDamp(currentDirection, targetDirection, ref currentDirectionVelocity, moveSmooth);

        if (characterController.isGrounded)
        {
            velocity.y = 0.0f;
        }

        velocity = (transform.forward * currentDirection.z + transform.right * currentDirection.x) * walkSpeed + Vector3.up * velocity.y;
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            velocity = (transform.forward * currentDirection.z + transform.right * currentDirection.x) * sprintSpeed + Vector3.up * velocity.y;
        }

        if(Input.GetKeyDown(KeyCode.Space) && characterController.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);
    }
}
