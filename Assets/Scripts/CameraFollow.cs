using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform carTarget;
    public Vector3 offsetPosition;
    public Vector3 offsetRotation;

    [Range(0.1f, 10f)]
    public float followSpeed = 5f;

    private Vector3 targetPosition;
    private Quaternion targetRotation;

    void LateUpdate()
    {
        FollowTarget();
    }

    void FollowTarget()
    {
        // Calculate the target position and rotation
        targetPosition = carTarget.TransformPoint(offsetPosition);
        targetRotation = Quaternion.LookRotation(carTarget.forward + offsetRotation, carTarget.up);

        // Interpolate the camera's position and rotation towards the target
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, followSpeed * Time.deltaTime);
    }
}
