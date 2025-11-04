using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;


public class ClimbingController : MonoBehaviour
{
    private ThirdPersonController thirdPersonController;
    private CharacterController unityController;
    private StarterAssetsInputs input;
    private PlayerInput playerInput;

    [SerializeField] private float wallDetectionLength;
    [SerializeField] private float wallSphereCastRadius;
    [SerializeField] private Transform sphereCastOrigin;
    private RaycastHit wallHit;

    [SerializeField] private Camera mainCamera;
    [SerializeField] private LayerMask climbable;

    [SerializeField] private float timeBetweenJumps = 1f;
    public float wallJumpCoolDownTimer = 0f;
    public bool isClimbing = false;
    public bool isWallJumping = false;
    private bool isHoldingSpace = false;

    [SerializeField] private float climbJumpVerticalHeight = 5f;
    [SerializeField] private float climbJumpSpeed = 10f;
    private float originalSpeed = 0f;

    private void Awake()
    {
        thirdPersonController = GetComponent<ThirdPersonController>();
        unityController = GetComponent<CharacterController>();
        input = GetComponent<StarterAssetsInputs>();
        playerInput = GetComponent<PlayerInput>();
        originalSpeed = thirdPersonController.MoveSpeed;
    }

    private void StartClimbing(){
        thirdPersonController.noMove = true;
        thirdPersonController.noJumpAndGravity = true;
        isClimbing = true;
    }

    private void StopClimbing(){
        thirdPersonController.noMove = false;
        thirdPersonController.noJumpAndGravity = false;
        isClimbing = false;
    }



    // Update is called once per frame
    void Update()
    {
        
        wallJumpCoolDownTimer -= Time.deltaTime;
        isHoldingSpace = Input.GetKey(KeyCode.Space);

        if(isWallJumping && !isHoldingSpace){
            StopClimbing();
            isWallJumping = false;
        }

        if(!isHoldingSpace && CheckWall() && !isClimbing && wallJumpCoolDownTimer <= 0 && !thirdPersonController.Grounded){
            StartClimbing();
        }
        //get into climbing:
        
        if (isClimbing && isHoldingSpace)
        {
            isClimbing = false;
            isWallJumping = true;
            thirdPersonController._verticalVelocity = 0f;

            Invoke("WallJump", 0.05f);
        }

        if(thirdPersonController.Grounded){
            StopClimbing();
            thirdPersonController.MoveSpeed = originalSpeed;
            thirdPersonController.SprintSpeed = originalSpeed * 2.5f;
        }
    }

    private void WallJump(){
        wallJumpCoolDownTimer = timeBetweenJumps;
        thirdPersonController.noMove = false;
        thirdPersonController.noJumpAndGravity = false;
        thirdPersonController.MoveSpeed = climbJumpSpeed;
        thirdPersonController.SprintSpeed = climbJumpSpeed;

        float verticalJump = Mathf.Sqrt(climbJumpVerticalHeight * -2f * thirdPersonController.Gravity);
        thirdPersonController._verticalVelocity = verticalJump;
    }

    private bool CheckWall()
    {
        bool _wallDetected = Physics.SphereCast(sphereCastOrigin.position, wallSphereCastRadius, mainCamera.transform.forward, out wallHit, wallDetectionLength, climbable); 
        return _wallDetected;
    }
}
