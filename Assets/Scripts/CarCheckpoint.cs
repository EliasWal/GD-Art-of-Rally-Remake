using UnityEngine;

public class CarCheckpoint : MonoBehaviour
{
    private CheckpointManager checkpointManager;

    private void Start()
    {
        checkpointManager = FindObjectOfType<CheckpointManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Checkpoint"))
        {
            if (other.transform == checkpointManager.GetCurrentCheckpoint())
            {
                checkpointManager.PlayerPassedCheckpoint();
                Debug.Log("Passed checkpoint!");
            }
        }
    }
}
