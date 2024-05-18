using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;

    void Awake()
    {
        if (instance == null)
        {
            // If instance doesn't exist, set it to this instance
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // If instance already exists and it's not this instance, destroy this instance
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Your music setup code (e.g., loading music clip, playing music) can go here
    }
}
