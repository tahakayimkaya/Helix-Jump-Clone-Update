using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    private static Singleton _instance;
    public Transform ballInstance;

    public static Singleton Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<Singleton>();
                if (_instance == null)
                {
                    _instance = new GameObject().AddComponent<Singleton>();
                }
            }

            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null) Destroy(obj: this);
        DontDestroyOnLoad(target: this);
    }
}
