using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
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
    
    // Update is called once per frame
    void Update()
    {
        //Player Movement
        if (isPressed != true)
        {
        
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");

            transform.position += new Vector3(horizontal, 0, vertical) * speed * Time.deltaTime;
            Vector3 movementDirection = new Vector3(horizontal, 0, vertical);
            movementDirection.Normalize();

            if (movementDirection != Vector3.zero)
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
                
                Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 500 * Time.deltaTime);
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


                TeleportAnimation.Invoke();
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
            //RollAnimation.Invoke();
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
