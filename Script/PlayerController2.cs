using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController2 : MonoBehaviour
{
    [SerializeField]
    private KeyCode jumpKeyCode = KeyCode.Space;
    [SerializeField]
    private float walkSpeed = 5; //원래 걸음 속도
    [SerializeField]
    private float runSpeed = 8; //뜀걸음 속도
    [SerializeField]
    private float applySpeed = 5; // 현재 속도

    //상태 변수
    private bool isRun = false;
    private bool isGround = true;
    private float OrignWalkSpeed = 5;
    private float OrignRunSpeed = 8;

    [Range(0,1)]
    public float DontMove = 1;

    public float jumpForce = 10f;
    [SerializeField]
    private float lookSensitivity;

    //카메라
    [SerializeField]
    private float cameraRotationLimit;
    private float currentCameraRotationX = 0;
    
    //컴포너
    [SerializeField]
    private Camera myCamera;
    private Rigidbody MyRigidbody;
    private CharacterController characterController;
    private CapsuleCollider capsuleCollider;

    Vector3 playerHittheWall;
    Vector3 playerStartPosition;

    private void Start()
    {
        myCamera = FindObjectOfType<Camera>();
        MyRigidbody = gameObject.GetComponent<Rigidbody>();
        characterController = GetComponent<CharacterController>();
        capsuleCollider = GetComponent<CapsuleCollider>();

        OrignRunSpeed = runSpeed;
        OrignWalkSpeed = walkSpeed;
        applySpeed = walkSpeed;

        playerStartPosition = transform.position;
    }

    private void FixedUpdate()
    {
        Move();
        CameraRotation();
        CharacterRotation();
        TryRun();
        JumpTo();
        IsGround();
    }

    private void Move()
    {
        float _moveDirX = Input.GetAxisRaw("Horizontal");
        float _moveDirZ = Input.GetAxisRaw("Vertical");
        float _moveY = MyRigidbody.velocity.y;

        Vector3 _moveHorizontal = transform.right * _moveDirX;
        Vector3 _moveVertical = transform.forward * _moveDirZ;

        Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized;

        MyRigidbody.velocity = _velocity * applySpeed;
        MyRigidbody.velocity = new Vector3(MyRigidbody.velocity.x, _moveY, MyRigidbody.velocity.z);
    }

    private void CharacterRotation()
    {
        float _yRotation = Input.GetAxisRaw("Mouse X");
        Vector3 _characterRotationY = new Vector3(0f, _yRotation, 0f) * lookSensitivity;
        MyRigidbody.rotation *= Quaternion.Euler(_characterRotationY);

    }
    private void CameraRotation()
    {
        float _xRotaion = Input.GetAxisRaw("Mouse Y");
        float _cameraRotationX = _xRotaion * lookSensitivity;
        currentCameraRotationX -= _cameraRotationX;
        currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit);

        myCamera.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0f, 0f);
    }

    private void TryRun()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Running();
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            RunningCancle();
        }
    }

    private void Running()
    {
        isRun = true;
        applySpeed = runSpeed;
    }


    private void RunningCancle()
    {
        isRun = false;
        applySpeed = walkSpeed;
    }

    public void JumpTo()
    {
        if(Input.GetKeyDown(KeyCode.Space)&& isGround)
        {
            Jump();
        }
    }

    private void Jump()
    {
        MyRigidbody.velocity = new Vector3(MyRigidbody.velocity.x, jumpForce, MyRigidbody.velocity.z) ;
    }

    private void IsGround()
    {
        //isGround = Physics.Raycast(transform.position, Vector3.down, characterController.bounds.extents.y + 0.1f);
        isGround = Physics.Raycast(transform.position, Vector3.down, capsuleCollider.bounds.extents.y + 0.1f);
    }


    public void Initialized()
    {
        gameObject.transform.position = playerStartPosition;
    }
}

