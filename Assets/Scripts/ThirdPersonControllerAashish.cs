using UnityEngine;

namespace ReadyPlayerMe.QuickStart
{
    [RequireComponent(typeof(ThirdPersonMovementAashish), typeof(PlayerInput))]
    public class ThirdPersonControllerAashish : MonoBehaviour
    {
        private const float FALL_TIMEOUT = 0.15f;

        private static readonly int MoveSpeedHash = Animator.StringToHash("MoveSpeed");
        private static readonly int JumpHash = Animator.StringToHash("JumpTrigger");
        private static readonly int FreeFallHash = Animator.StringToHash("FreeFall");
        private static readonly int IsGroundedHash = Animator.StringToHash("IsGrounded");

        private Transform playerCamera;
        private Animator animator;
        private Vector2 inputVector;
        private Vector3 moveVector;
        private GameObject avatar;
        private ThirdPersonMovementAashish thirdPersonMovement;
        private PlayerInput playerInput;

        private float fallTimeoutDelta;

        [SerializeField][Tooltip("Useful to toggle input detection in editor")]
        private bool inputEnabled = true;
        private bool isInitialized;

        private void Init()
        {
            thirdPersonMovement = GetComponent<ThirdPersonMovementAashish>();
            playerInput = GetComponent<PlayerInput>();
            playerInput.OnJumpPress += OnJump;
            isInitialized = true;
        }

        public void Setup(GameObject target, RuntimeAnimatorController runtimeAnimatorController)
        {
            if (!isInitialized)
            {
                Init();
            }

            avatar = target;
            thirdPersonMovement.Setup(avatar);
            animator = avatar.GetComponent<Animator>();
            animator.runtimeAnimatorController = runtimeAnimatorController;
            animator.applyRootMotion = false;

        }

private void Update()
{
    if (avatar == null)
    {
        return;
    }

    if (Input.GetKeyDown(KeyCode.Alpha1))
    {
        animator.Play("Telekinesis");
    }
    if (Input.GetKeyDown(KeyCode.Alpha2))
    {
        animator.Play("FlyingShoulder");
    }
    if (Input.GetKeyDown(KeyCode.Alpha3))
    {
        animator.Play("FlyingKnee");
    }
    if (Input.GetKeyDown(KeyCode.Alpha4))
    {
        animator.Play("Grab");
    }
    if (Input.GetKeyDown(KeyCode.Alpha5))
    {
        animator.Play("InAir");
    }

    // Use PlayerInput component for input handling
    playerInput.CheckInput();
    var xAxisInput = playerInput.AxisHorizontal;
    var yAxisInput = playerInput.AxisVertical;
    thirdPersonMovement.Move(xAxisInput, yAxisInput);
    thirdPersonMovement.SetIsRunning(playerInput.IsHoldingLeftShift);

    UpdateAnimator();
}




        private void UpdateAnimator()
{
    var isGrounded = thirdPersonMovement.IsGrounded();
    animator.SetFloat(MoveSpeedHash, thirdPersonMovement.CurrentMoveSpeed);
    animator.SetBool(IsGroundedHash, isGrounded);

    if (isGrounded)
    {
        fallTimeoutDelta = FALL_TIMEOUT;
        animator.SetBool(FreeFallHash, false);
    }
    else
    {
        if (fallTimeoutDelta >= 0.0f)
        {
            fallTimeoutDelta -= Time.deltaTime;
        }
        else
        {
            animator.SetBool(FreeFallHash, false);
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                animator.Play("FlyingShoulder");
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                animator.Play("FlyingKnee");
            }
        }
    }
}


       private void OnJump()
{
    if (thirdPersonMovement.TryJump())
    {
        animator.SetTrigger(JumpHash);

        if (!thirdPersonMovement.IsGrounded())
        {
            if (Input.GetKey(KeyCode.Alpha2))
            {
                animator.Play("FlyingShoulder");
            }
            else if (Input.GetKey(KeyCode.Alpha3))
            {
                animator.Play("FlyingKnee");
            }
        }
    }
}

    }
}
