using UnityEngine;

public class CurvedParticleMotion : MonoBehaviour
{
    public float speed = 1f;

    private Vector3 targetPosition = Vector3.zero;
    private float distanceToTarget;
    private Vector3 startPosition;
    private float startTime;
    private bool hasTarget = false; // Add a boolean flag to check if the target has been set

    public void SetTarget(Vector3 target)
    {
        targetPosition = target;
        distanceToTarget = Vector3.Distance(transform.position, target);
        startPosition = transform.position;
        startTime = Time.time;
        hasTarget = true; // Set the flag to true when the target is set
    }

    private void Update()
    {
        if (hasTarget) // Check if the target has been set using the boolean flag
        {
            float distanceCovered = (Time.time - startTime) * speed;
            float t = distanceCovered / distanceToTarget;
            t = Mathf.Clamp01(t);

            transform.position = Vector3.Lerp(startPosition, targetPosition, t);
        }
    }
}
