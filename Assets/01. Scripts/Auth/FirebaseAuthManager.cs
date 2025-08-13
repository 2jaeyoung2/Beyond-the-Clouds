using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Auth;
using Firebase.Database;

public class FirebaseAuthManager : MonoBehaviour
{
    public static FirebaseAuthManager Instance { get; private set; }

    public static FirebaseUser User { get; private set; }

    public static DatabaseReference DbRef { get; private set; }

    private FirebaseAuth auth;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);

            return;
        }
        else
        {
            Instance = this;

            DontDestroyOnLoad(gameObject);
        }

        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            DependencyStatus dependencyStatus = task.Result;

            if (dependencyStatus == DependencyStatus.Available)
            {
                auth = FirebaseAuth.DefaultInstance;

                DbRef = FirebaseDatabase.DefaultInstance.RootReference;
            }
            else
            {
                Debug.Log("Firebase ¿À·ù");
            }
        });
    }
}
