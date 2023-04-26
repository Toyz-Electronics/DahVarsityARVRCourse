using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterController : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    public float speed;
    public float smoothTime;
    [SerializeField]
    private LineRenderer lr;
    [SerializeField]
    private Transform RealeasePos;
    [Header("Display Controls")]
    [SerializeField]
    [Range(10, 100)]
    private int LinePoints = 25;
    [SerializeField]
    [Range(0.01f,1f)]
    private float TimeBetweenPoints = .1f;
    private Vector3 velocity = Vector3.zero;
    PortalEffect portalEffect;
    public bool isTeleport;
    [SerializeField]
    GameObject player;
    public GameObject initializer;

    [Header("Portal Objects")]
    public GameObject portal1;
    public GameObject portal2;
   // public GameObject initializer;


    Ray ray;
    public LayerMask layer;
    public float maxDistance=90;
    // Start is called before the first frame update
    void Start()
    {
        portalEffect = GetComponent<PortalEffect>();
        portal1.SetActive(false);
        portal2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void TeleporterPosition(){
        ray = new Ray(initializer.transform.position, player.transform.forward);
        portal1.transform.localRotation = player.transform.localRotation;
        portal2.transform.localRotation = player.transform.localRotation;
        Vector3 playerDirection = player.transform.position;
        playerDirection.Normalize();
     
        Debug.Log(playerDirection);
 
        portal1.transform.position = ray.GetPoint(2);
        portal2.transform.position = ray.GetPoint(maxDistance);
        portal1.SetActive(true);
        portal2.SetActive(true);
        portalEffect.grow = true;
       
        
        if (Physics.Raycast(ray, out RaycastHit hit, maxDistance, layer)){

            
            //Instantiate(portal1, player.transform.position + playerDirection * 3, transform.rotation);
            //Instantiate(portal2, hit.collider.transform.position, transform.rotation);
        }
       StartCoroutine(Transition());

    }
    public void PortalCollision()
    {

    }
    IEnumerator Transition(){
        //Aniamtion
        transform.position =portal2.transform.position;
        yield return new WaitForSeconds(4f);
      
        portal1.SetActive(false);
        portal2.SetActive(false);
        portalEffect.portal1.transform.localScale = new Vector3(0, 0, 0);
        //Destroy(portal1);
        //Destroy(portal2);
    }

    //Create function that allows player to teleport instantly to the players direction pressing E, 
    //Create where you hold E and teleport to the place the player wants to teleport in

    //When teleporting,c reate another character at the other end
    private void OnTriggerStay(Collider other)
    {
        //Find top of surface
        //Or find a stay on faces method
        if (other.gameObject.tag == "Collide")
        {
            transform.position += new Vector3(0, .05f, 0);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        transform.position = new Vector3(transform.position.x, 0.2f, transform.position.z);
    }
    private void OnCollisionExit(Collision collision)
    {
       
    }

  
    void Visualize(Vector3 vo, Vector3 finalPos)
    {
        lr.positionCount = Mathf.CeilToInt(LinePoints / TimeBetweenPoints) + 1;
        for (int i = 0; i < LinePoints; i++)
        {
            Vector3 pos = CalculatePosInTime(vo, (i / (float)LinePoints) *TimeBetweenPoints);
            lr.SetPosition(i, pos);
        }

       lr.SetPosition(LinePoints, finalPos);
    }
    
    Vector3 CalculateVelocty(Vector3 target, Vector3 origin, float time)
    {
        Vector3 distance = target - origin;
        Vector3 distanceXz = distance;
        distanceXz.y = 0f;
 
        float sY = distance.y;
        float sXz = distanceXz.magnitude;
 
        float Vxz = sXz / time;
        float Vy = (sY / time) + (0.5f * Mathf.Abs(Physics.gravity.y) * time);
 
        Vector3 result = distanceXz.normalized;
        result *= Vxz;
        result.y = Vy;
 
        return result;
    }
    Vector3 CalculatePosInTime(Vector3 vo, float time)
    {
        Vector3 Vxz = vo;
        Vxz.y = 0f;

        Vector3 result = RealeasePos.position + vo * time;
        float sY = (-0.5f * Mathf.Abs(Physics.gravity.y) * (time * time)) + (vo.y * time) + RealeasePos.position.y;

        result.y = sY;

        return result;
    }
}
