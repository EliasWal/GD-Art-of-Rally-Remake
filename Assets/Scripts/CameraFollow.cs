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

    void FixedUpdate()
    {
        FollowTarget();
    }

    void FollowTarget()
    {
        // Calculate the target position and rotation
        Vector3 predictedTargetPosition = carTarget.position + carTarget.forward * carTarget.GetComponent<Rigidbody>().velocity.magnitude * Time.deltaTime;
        targetPosition = predictedTargetPosition + carTarget.TransformDirection(offsetPosition);
        targetRotation = Quaternion.LookRotation(carTarget.forward + offsetRotation, carTarget.up);

        // Interpolate the camera's position and rotation towards the target
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, followSpeed * Time.deltaTime);
    }
}
