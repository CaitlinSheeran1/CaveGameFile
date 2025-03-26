using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;  // Singleton instance
    public GameObject player;             // Reference to the player object

    void Awake()
    {
        // Ensure that only one instance of PlayerManager exists
        if (instance != null && instance != this)
        {
            Destroy(gameObject);  // Destroy duplicate instances
        }
        else
        {
            instance = this;  // Set instance to the current object
            DontDestroyOnLoad(gameObject);  // Optional: Persist between scenes
        }
    }
}