using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    public float speed = 3.0f;
    float vert ;
    int comboCount=0;
    Vector3 rotation;
    TeleporterController TC;
    [SerializeField]
    GameObject teleporter;
    private bool isPressed=false;
    float lastClick=0;
    Animator anim;

    [Header("Cameras")]
    public GameObject mainCamera;
    public GameObject aimCamera;
    public GameObject Initializer;
    CameraInitalizer CI;
    bool fall;
    [Header("Events")]
    public UnityEvent WalkingAnimation;
    public UnityEvent TeleportAnimation;
    public UnityEvent IdleAnimation;
    public UnityEvent AimAnimation;
    public UnityEvent RunningAnimation;
    public UnityEvent DodgeAnimation;
    public UnityEvent RollAnimation;
    // Start is called before the first frame update
    void Start()
    {
        CI = Initializer.GetComponent<CameraInitalizer>();
        TC = teleporter.GetComponent<TeleporterController>();
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
                    RunningAnimation.Invoke();
                }
                else
                {
                    WalkingAnimation.Invoke();
                }
                
                Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 500 * Time.deltaTime);
            }
            else
            {
               
                IdleAnimation.Invoke();
            
            }


            if (Input.GetMouseButtonDown(1))
            {
                DodgeAnimation.Invoke();
            }

            /*if (anim.GetCurrentAnimatorStateInfo(0).IsName("Talking") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
            {
                comboCount = 0;
                anim.SetInteger("comboCount", comboCount);
            }
            */
        }
        else
        {
           
            transform.localRotation = aimCamera.transform.localRotation;//Quaternion.Euler(0, -turn.y*20f, 0);

        }
      
        //Teleporting
        if (Input.GetKeyDown(KeyCode.E))
        {
           
            if (isPressed == true)
            {

               // mainCamera.SetActive(true);
                //aimCamera.SetActive(false);
                TeleportAnimation.Invoke();
                StartCoroutine(ActivateTeleporter());
                isPressed = false;

                //anim.SetBool("IsJumping", false);


            }
            else
            {
                AimAnimation.Invoke();
                //mainCamera.SetActive(false);
                //aimCamera.SetActive(true);
                //anim.SetBool("IsTeleport", true);
                isPressed = true;
               
               
            }
          
            //Camera change
            //Spawn teleporter
        }
       

    }



    IEnumerator ActivateTeleporter()
    {
        
        yield return new WaitForSeconds(4f);
        TC.TeleporterPosition();

    }
        IEnumerator EndCombo(){
        yield return new WaitForSeconds(3f);       anim.SetBool("IsPunching", false);
        //comboCount = 0;
        //anim.SetInteger("comboCount", comboCount);
        /*comboCount = (comboCount > 3) ? 0 : comboCount+1;
        anim.SetInteger("comboCount", comboCount);*/


    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Here");

        if (other.gameObject.tag == "teleporter")
        {
           
            transform.position = TC.portal2.transform.position;
            RollAnimation.Invoke();
           
            

        }

    }
    private void FixedUpdate()
    {

        
    }
}
