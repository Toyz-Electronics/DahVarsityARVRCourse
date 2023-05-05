using UnityEngine;
using System.Collections;

public class TeleKinesis : MonoBehaviour
{
    public Camera mainCamera;
    public float maxDistance = 10f;
    public float forceStrength = 10f;
    public float holdingDistance = 1.5f;
    public float moveSpeed = 2f;
    public float slamForce = 500f;
    public KeyCode slamKey = KeyCode.Alpha5;
    public float liftingSpeed = 0.5f;
    public Transform attackTarget;
    public float attackSpeed = 2f;
    public KeyCode attackKey = KeyCode.Alpha2;
    public float distanceFactor = 0.5f;
    public float selectedObjectScale = 0.5f; // New variable for object scale
    private bool isScalingObject; // New variable to check if the object is being scaled
    private Rigidbody selectedObject;
    private bool isHoldingObject;
    private Coroutine liftingCoroutine;
    private Coroutine attackingCoroutine;
    private Vector3 originalScale; // New variable to store the object's original scale
    private bool isLiftingObject; // New variable to check if the object is being lifted
    private Vector3 initialObjectScale; // New variable to store the object's initial scale
    public float inputDelay = 0.5f;
    private float lastInputTime;
    private bool alpha1Pressed;
    private Coroutine inputDelayCoroutine;


    private void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }

   
    void Update()
{
    
    if (inputDelayCoroutine == null && Input.GetKeyDown(KeyCode.Alpha1))
    {
        inputDelayCoroutine = StartCoroutine(HandleAlpha1Input());
    }

    if (isHoldingObject)
    {
        Vector3 targetPosition = mainCamera.transform.position + mainCamera.transform.forward * holdingDistance;
            Debug.Log("holdingObject");
        float horizontal = Input.GetAxis("Horizontal") * distanceFactor;
        float vertical = Input.GetAxis("Vertical") * distanceFactor;

        Vector3 newPosition = targetPosition;
        newPosition.x += horizontal;
        newPosition.y += vertical;

        selectedObject.transform.position = Vector3.Lerp(selectedObject.transform.position, newPosition, Time.deltaTime * moveSpeed);

        if (Input.GetKeyDown(slamKey))
        {
            SlamObject();
        }

        if (Input.GetKeyDown(attackKey) && attackTarget != null)
        {
            if (attackingCoroutine != null)
            {
                StopCoroutine(attackingCoroutine);
            }
            attackingCoroutine = StartCoroutine(AttackObject(selectedObject, attackTarget));
        }
    }
}
private IEnumerator HandleAlpha1Input()
{
    if (!isHoldingObject)
    {
        RaycastHit hit;
        Transform characterHeadTransform = mainCamera.transform;
        Ray ray = new Ray(characterHeadTransform.position, characterHeadTransform.forward);
        int layerMask = ~LayerMask.GetMask("Ignore Raycast");

        if (Physics.Raycast(ray, out hit, maxDistance, layerMask))
        {
                Debug.Log("hit something");
                if (hit.collider.GetComponent<Rigidbody>() != null)
            {
                Debug.Log("Object selected");
                isHoldingObject = true;
                selectedObject = hit.collider.GetComponent<Rigidbody>();
                selectedObject.useGravity = false;
                originalScale = selectedObject.transform.localScale; // Store the original scale
                Debug.Log("Original scale: " + originalScale); // Add this line to log the original scale

                if (liftingCoroutine != null)
                {
                    StopCoroutine(liftingCoroutine);
                }
                liftingCoroutine = StartCoroutine(LiftObject(selectedObject));
            }
        }
    }
    else
    {
        Debug.Log("Object released");
        isHoldingObject = false;
        selectedObject.useGravity = true;
        RestoreObjectScale(); // Restore the scale after releasing
        selectedObject = null;
    }

    yield return new WaitForSeconds(inputDelay);
    inputDelayCoroutine = null;
}

private IEnumerator LiftObject(Rigidbody obj)
{
    float elapsedTime = 0f;
    Vector3 startPosition = obj.position;
    Vector3 targetPosition = mainCamera.transform.position + mainCamera.transform.forward * holdingDistance;
    initialObjectScale = obj.transform.localScale; // Store the initial scale when lifting starts
    obj.transform.localScale *= selectedObjectScale; // Scale the object before lifting

    while (elapsedTime < liftingSpeed)
    {
        float t = elapsedTime / liftingSpeed;
        t = t * t * t * (t * (6f * t - 15f) + 10f); // Smoother step function (smoothstep)
        obj.position = Vector3.Lerp(startPosition, targetPosition, t);
        elapsedTime += Time.deltaTime;
        yield return null;
    }

    obj.position = targetPosition;
}

private IEnumerator AttackObject(Rigidbody obj, Transform target)
{
    float elapsedTime = 0f;
    Vector3 startPosition = obj.position;

    while (elapsedTime < attackSpeed)
    {
        obj.position = Vector3.Lerp(startPosition, target.position, elapsedTime / attackSpeed);
        elapsedTime += Time.deltaTime;
        yield return null;
    }

    obj.position = target.position;
}

private void RestoreObjectScale()
{
    if (selectedObject != null)
    {
        selectedObject.transform.localScale = originalScale;
        Debug.Log("Object scale restored to: " + originalScale);
    }
}


private void SlamObject()
{
    Debug.Log("Object slammed");
    selectedObject.useGravity = true;
    selectedObject.AddForce(Vector3.down * slamForce, ForceMode.Impulse);
    isHoldingObject = false;
    selectedObject.transform.localScale = originalScale; // Restore the original scale
    selectedObject = null;
}
}
