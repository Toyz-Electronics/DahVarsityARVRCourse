using UnityEngine;
using System.Collections;

public class TeleKinesis : MonoBehaviour
{
    public Material laserMaterial;
    private LineRenderer laserLineRenderer;
    private bool isCastingBeam;

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
    public GameObject particleSystemPrefab;
    private GameObject headParticleSystem;
    private GameObject objectParticleSystem;
    public float sphereCastRadius = 0.5f;

    private void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
          // Initialize the laser line renderer
    laserLineRenderer = gameObject.AddComponent<LineRenderer>();
    laserLineRenderer.material = laserMaterial;
    laserLineRenderer.widthCurve = AnimationCurve.Constant(0, 1, 0.05f); // Set the line width to 0.05
    laserLineRenderer.positionCount = 2;
    laserLineRenderer.enabled = false; // Hide the laser line by default

    }

   
    void Update()
{
    
    if (inputDelayCoroutine == null && Input.GetKeyDown(KeyCode.Alpha1))
    {
        isCastingBeam = true;

        inputDelayCoroutine = StartCoroutine(HandleAlpha1Input());
    }

 if (Input.GetKeyUp(KeyCode.Alpha1))
    {
        isCastingBeam = false;
        laserLineRenderer.enabled = false;
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

         if (headParticleSystem != null)
        {
            headParticleSystem.transform.position = Vector3.Lerp(headParticleSystem.transform.position, selectedObject.transform.position, Time.deltaTime * moveSpeed);
        }
    }
       else if (isCastingBeam)
    {
        DrawLaserBeamWhenNotHoldingObject();
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

        if (Physics.SphereCast(ray, sphereCastRadius, out hit, maxDistance, layerMask))
        {
                Debug.Log("hit something");
                Rigidbody hitRigidbody = hit.collider.GetComponent<Rigidbody>();
            if (hitRigidbody == null)
            {
                yield break;
            }


            headParticleSystem = Instantiate(particleSystemPrefab, characterHeadTransform.position, Quaternion.identity, characterHeadTransform);
            CurvedParticleMotion particleMotion = headParticleSystem.GetComponent<CurvedParticleMotion>();
            if (particleMotion != null)
            {
                particleMotion.SetTarget(hit.transform.position);
            }

            yield return new WaitForSeconds(inputDelay); // Wait for the particle to reach the target

            // Instantiate the object's particle system
            objectParticleSystem = Instantiate(particleSystemPrefab, hit.transform.position, Quaternion.identity, hit.transform);

            Debug.Log("Object selected");
            isHoldingObject = true;
            selectedObject = hitRigidbody;
            selectedObject.useGravity = false;
            originalScale = selectedObject.transform.localScale;
            Debug.Log("Original scale: " + originalScale);

            if (liftingCoroutine != null)
            {
                StopCoroutine(liftingCoroutine);
            }
            liftingCoroutine = StartCoroutine(LiftObject(selectedObject));

            // Destroy the head particle system
            if (headParticleSystem != null)
            {
                Destroy(headParticleSystem);
            }

            // Hide the laser beam when the object is picked up
            laserLineRenderer.enabled = false;
        }
    }
    else
    {
        Debug.Log("Object released");
        isHoldingObject = false;
        selectedObject.useGravity = true;
        RestoreObjectScale();
        selectedObject = null;

        // Destroy the object's particle system
        if (objectParticleSystem != null)
        {
            Destroy(objectParticleSystem);
        }
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
        t = t * t * t * (t * (6f * t - 15f) + 10f); 
        obj.position = Vector3.Lerp(startPosition, targetPosition, t);
        UpdateLaserBeam(mainCamera.transform.position, obj.position); 
        elapsedTime += Time.deltaTime;
        yield return null;
    }

    obj.position = targetPosition;
    laserLineRenderer.enabled = false; 
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

private void DrawLaserBeamWhenNotHoldingObject()
{
    RaycastHit hit;
    Transform characterHeadTransform = mainCamera.transform;
    Ray ray = new Ray(characterHeadTransform.position, characterHeadTransform.forward);
    int layerMask = ~LayerMask.GetMask("Ignore Raycast");

    if (Physics.Raycast(ray, out hit, maxDistance, layerMask))
    {
        // Draw the laser beam
        laserLineRenderer.enabled = true;
        DrawLaserBeam(characterHeadTransform.position, hit.point);
    }
    else
    {
        // Draw the laser beam to the maximum distance
        laserLineRenderer.enabled = true;
        DrawLaserBeam(characterHeadTransform.position, characterHeadTransform.position + characterHeadTransform.forward * maxDistance);
    }
}
private void DrawLaserBeam(Vector3 startPoint, Vector3 endPoint)
{
    laserLineRenderer.SetPosition(0, startPoint);
    laserLineRenderer.SetPosition(1, endPoint);
}
private void UpdateLaserBeam(Vector3 startPoint, Vector3 endPoint)
{
    if (laserLineRenderer.enabled)
    {
        laserLineRenderer.SetPosition(0, startPoint);
        laserLineRenderer.SetPosition(1, endPoint);
    }
}



}

