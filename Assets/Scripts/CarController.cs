using UnityEngine;

public class CarController : MonoBehaviour
{
    private float horizontalInput, verticalInput;
    private bool isBreaking, isHandBrake;

    [SerializeField] private float motorForce = 1000f;
    [SerializeField] private float breakForce = 3000f;
    [SerializeField] private float handBrakeForce = 8000f;
    [SerializeField] private float maxSteerAngle = 20f;

    [SerializeField] private float steeringSensitivity = 0.1f;  
    [SerializeField] private float maxAngularVelocity = 5f;

    [SerializeField] private WheelCollider frontLeftWheelCollider, frontRightWheelCollider;
    [SerializeField] private WheelCollider rearLeftWheelCollider, rearRightWheelCollider;

    [SerializeField] private Transform frontLeftWheelTransform, frontRightWheelTransform;
    [SerializeField] private Transform rearLeftWheelTransform, rearRightWheelTransform;

    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }

    private void GetInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        isBreaking = Input.GetKey(KeyCode.Space);
        isHandBrake = Input.GetKey(KeyCode.LeftShift);
    }

    private void HandleMotor()
    {
        float motorTorque = verticalInput * motorForce;
        float brakeTorque = isBreaking ? breakForce : 0f;

        if (isHandBrake)
        {
            rearLeftWheelCollider.brakeTorque = handBrakeForce;
            rearRightWheelCollider.brakeTorque = handBrakeForce;
        }
        else
        {
            rearLeftWheelCollider.brakeTorque = brakeTorque;
            rearRightWheelCollider.brakeTorque = brakeTorque;
        }

        frontLeftWheelCollider.brakeTorque = brakeTorque;
        frontRightWheelCollider.brakeTorque = brakeTorque;

        frontLeftWheelCollider.motorTorque = motorTorque;
        frontRightWheelCollider.motorTorque = motorTorque;
    }

    private void HandleSteering()
    {
        // Calcularea unghiului de virare în funcție de inputul utilizatorului
        float targetSteerAngle = maxSteerAngle * horizontalInput;

        // Interpolarea către unghiul de virare dorit pentru a evita schimbările bruște
        float smoothSteerAngle = Mathf.Lerp(frontLeftWheelCollider.steerAngle, targetSteerAngle, steeringSensitivity);

        // Aplicarea unghiului de virare către roți
        frontLeftWheelCollider.steerAngle = smoothSteerAngle;
        frontRightWheelCollider.steerAngle = smoothSteerAngle;
    }

    private void UpdateWheels()
    {
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheelTransform);
        UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform);
        UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTransform);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }
}
