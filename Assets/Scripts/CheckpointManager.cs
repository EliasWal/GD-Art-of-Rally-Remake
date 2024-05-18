using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class CheckpointManager : MonoBehaviour
{
    public List<Transform> checkpoints; // List of checkpoint transforms
    private int currentCheckpointIndex = 0; // Index of the next checkpoint to pass through

    private void Start()
    {
        // Initialize the checkpoints list
        checkpoints = new List<Transform>();
        foreach (Transform child in transform)
        {
            checkpoints.Add(child);
        }
    }

    public Transform GetCurrentCheckpoint()
    {
        return checkpoints[currentCheckpointIndex];
    }

    public int lapCount = 0; // Track the number of laps completed
    public int totalLaps = 3; // Total number of laps for the race

    public void PlayerPassedCheckpoint()
    {
        currentCheckpointIndex++;
        if (currentCheckpointIndex >= checkpoints.Count)
        {
            currentCheckpointIndex = 0; // Loop back to the first checkpoint
            lapCount++;
            Debug.Log("Lap Completed: " + lapCount);

            if (lapCount >= totalLaps)
            {
                Debug.Log("Race Completed!");
                // Add code here to handle race completion
            }
        }
    }
}
