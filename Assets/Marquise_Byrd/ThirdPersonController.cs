using UnityEngine;
using StarterAssets;
using System.Collections;

namespace ReadyPlayerMe.QuickStart
{
    [RequireComponent(typeof(ThirdPersonMovement))]
    public class ThirdPersonController : MonoBehaviour
    {
        private StarterAssetsInputs _input;

        private const float FALL_TIMEOUT = 0.15f;
        private bool attack = false;
        public Material material;
        public Shader shader;
        public Color lrc1 = Color.blue;
        public Color lrc2 = Color.white;
        public float w1 = 2;
        public float w2 = 2;
        public int lr_length = 10;
        public float beam_height = 1.3f;
        public int beam_distace = 3;
        public float beam_start_dist = 0.5f;
        public Vector3 start;
        public GameObject beam_target;
        public GameObject beam_start;
        private static readonly int MoveSpeedHash = Animator.StringToHash("MoveSpeed");
        private static readonly int JumpHash = Animator.StringToHash("JumpTrigger");
        private static readonly int FreeFallHash = Animator.StringToHash("FreeFall");
        private static readonly int IsGroundedHash = Animator.StringToHash("IsGrounded");
        private static readonly int IsIceAttackHash = Animator.StringToHash("ice_attack");

        private Transform playerCamera;
        private Animator animator;
        private Vector2 inputVector;
        private Vector3 moveVector;
        private GameObject avatar;
        private ThirdPersonMovement thirdPersonMovement;
        private PlayerInput playerInput;
        
        private float fallTimeoutDelta;
        
        [SerializeField][Tooltip("Useful to toggle input detection in editor")]
        private bool inputEnabled = true;
        private bool isInitialized;

        private void Init()
        {
            thirdPersonMovement = GetComponent<ThirdPersonMovement>();
            playerInput = GetComponent<PlayerInput>();
            playerInput.OnJumpPress += OnJump;
            isInitialized = true;
            _input = GetComponent<StarterAssetsInputs>();

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
            beam_target = new GameObject();
            beam_target.transform.position = new Vector3(avatar.transform.position.x, avatar.transform.position.y + beam_height, avatar.transform.position.z+beam_distace);
            beam_target.transform.parent = avatar.transform;
            beam_start = new GameObject();
            beam_start.transform.position = new Vector3(avatar.transform.position.x, avatar.transform.position.y + beam_height, avatar.transform.position.z + beam_start_dist);
            beam_start.transform.parent = avatar.transform;


        }

        private void Update()
        {
            if (avatar == null)
            {
                return;
            }
            if (inputEnabled)
            {
                playerInput.CheckInput();
                //var xAxisInput = playerInput.AxisHorizontal;
                //var yAxisInput = playerInput.AxisVertical;
                var xAxisInput = _input.move.x;
                var yAxisInput = _input.move.y;
                thirdPersonMovement.Move(xAxisInput, yAxisInput);
                thirdPersonMovement.SetIsRunning(playerInput.IsHoldingLeftShift);
            }
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
                    animator.SetBool(FreeFallHash, true);
                }
            }

            if (Input.GetKeyDown("k"))
            {
                animator.Play("ice_attack"); //SetBool(IsIceAttackHash, true);
                attack = true;
            }
            else
            {
              animator.SetBool(IsIceAttackHash, false);
              attack = false;
            }
            DrawLine();
        }

        private void OnJump()
        {
            if (thirdPersonMovement.TryJump())
            {
                animator.SetTrigger(JumpHash);
            }
        }

        void DrawLine()
        {
            if(attack == true)
            {
                Debug.Log("LASER");
                StartCoroutine(IceTime());
                StartCoroutine(IceAttack());


            }

        }

        IEnumerator IceTime()
        {
            yield return new WaitForSeconds(5f);
            animator.SetBool("ice_attack", false);
        }

        IEnumerator IceAttack()
        {
            yield return new WaitForSeconds(2.5f);
            avatar.AddComponent<LineRenderer>();
            LineRenderer lr = avatar.GetComponent<LineRenderer>();
            lr.material = material;
            lr.startColor = lrc1;
            lr.endColor = lrc2;
            lr.startWidth = w1;
            lr.endWidth = w2;
            lr.SetPosition(0, beam_start.transform.position);
            lr.SetPosition(1, beam_target.transform.position);
            lr.material = material;

            //lr.positionCount = beam_distace;
            GameObject.Destroy(lr, 1f);
        }
    }
}
