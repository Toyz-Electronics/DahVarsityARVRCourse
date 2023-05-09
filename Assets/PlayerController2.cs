using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController2 : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    public float speed = 3.0f;
 
    TeleporterController TC;
    TeleportationIn TI;
    TeleportationOut TO;
    [SerializeField]
    GameObject teleporter;
    private bool isPressed=false;
    private bool isRunning;
    private bool isGrounded;
    Animator anim;

    private float turnSmoothVelocity;
    private const float TURN_SMOOTH_TIME = 0.05f;

    private float verticalVelocity;
    public GameObject topPlayer;
    public GameObject bottomPlayer;
    Rigidbody rb;
    [Header("Cameras")]
    public GameObject mainCamera;
    public GameObject aimCamera;
    public GameObject Initializer;

    BoxCollider[] boxCol;
    [Header("Events")]
    public UnityEvent WalkingAnimation;
    public UnityEvent TeleportAnimation;
    public UnityEvent IdleAnimation;
    public UnityEvent AimAnimation;
    public UnityEvent RunningAnimation;
    public UnityEvent DodgeAnimation;
    public UnityEvent RollAnimation;
    public UnityEvent RunJumpAnimation;
    public UnityEvent JumpAnimation;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        boxCol = GetComponents<BoxCollider>();
       
        TC = teleporter.GetComponent<TeleporterController>();
        TI= topPlayer.GetComponent<TeleportationIn>();
        TO = bottomPlayer.GetComponent<TeleportationOut>();
        anim = GetComponent<Animator>();
        //mainCamera.SetActive(true);
       // aimCamera.SetActive(false);
    }

    private void RotateAvatarTowardsMoveDirection(Vector3 moveDirection)
    {
        float targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg + transform.rotation.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, TURN_SMOOTH_TIME);
        transform.rotation = Quaternion.Euler(0, angle, 0);
    }


    // Update is called once per frame
    void Update()
    {
        //Player Movement
        if (isPressed != true)
        {
        
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");
            var moveDirection = Camera.main.transform.right * horizontal + Camera.main.transform.forward * vertical;
            transform.position += moveDirection.normalized * (speed * Time.deltaTime) + new Vector3(0.0f, verticalVelocity * Time.deltaTime, 0.0f);
            //new Vector3(horizontal, 0, vertical) * speed * Time.deltaTime;
            Vector3 movementDirection = new Vector3(horizontal, 0, vertical);
            movementDirection.Normalize();
            var moveMagnitude = moveDirection.magnitude;
            if (moveMagnitude > 0)
            {
                RotateAvatarTowardsMoveDirection(moveDirection);
            }

            if (moveDirection != Vector3.zero)
            {
                //Walking Animation
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    isRunning = true;
                    RunningAnimation.Invoke();
                }
                else
                {
                    isRunning = false;
                    WalkingAnimation.Invoke();
                }
                
                //Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
                //transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 500 * Time.deltaTime);
            }
            else
            {
                isRunning = false;
                IdleAnimation.Invoke();
            
            }


            if (Input.GetMouseButtonDown(1))
            {
                DodgeAnimation.Invoke();
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Space is pressed");
                if (isGrounded == true)
                {
                    if (isRunning)
                    {
                        RunJumpAnimation.Invoke();
                    }
                    else
                    {
                        JumpAnimation.Invoke();
                        rb.AddForce(0, 5f, 0, ForceMode.Impulse);
                        //rb.AddForce(Vector3.up * 1000f);
                    }
                    isGrounded = false;
                }
               
            }
        }
        else
        {
            transform.localRotation =aimCamera.transform.localRotation;  // aimCamera.transform.localRotation; //Quaternion.localEulerAngles(aimCamera.transform.localRotation.x, transform.localRotation.y, aimCamera.transform.localRotation.z);
        }


        //Teleporting
        if (Input.GetKeyDown(KeyCode.E))
        {
           
            if (isPressed == true)
            {


                StartCoroutine(ActivateTeleporter());
                
                isPressed = false;
                TC.aim = false;

            }
            else
            {
                AimAnimation.Invoke();
                TC.aim = true;
                isPressed = true;
               
               
            }
           

            //Camera change
            //Spawn teleporter
        }
        if (TeleportationIn.teleportedIn == true)
        {
            transform.position = TC.portal2.transform.position;
            TeleportationIn.teleportedIn = false;
            TeleportationOut.teleportedOut = false;
        }
        if(TeleportationOut.teleportedOut == false)
        {
           transform.position = new Vector3( transform.position.x, transform.position.y+.1f, transform.position.z);
            if (transform.position.y > .05f)
            {
                foreach (BoxCollider col in boxCol)
                {
                    col.enabled = true;
                }
            }
        }

    }



    IEnumerator ActivateTeleporter()
    {
        TeleportAnimation.Invoke();
        yield return new WaitForSeconds(1f);
        TC.TeleporterPosition();
        foreach (BoxCollider col in boxCol)
        {
            col.enabled = false;
        }
       
        

    }
   
    IEnumerator EndCombo(){

        yield return new WaitForSeconds(3f);       
        anim.SetBool("IsPunching", false);

    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Ground")
        {
            Debug.Log("Here");
            isGrounded = true;
        }
    }


}
