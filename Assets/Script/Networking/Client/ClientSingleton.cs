using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ClientSingleton : MonoBehaviour
{
    private static ClientSingleton instance;
    public ClientGameManager GameManager { get; private set;}
    public static ClientSingleton Instance
    {
        get
        {
            if (instance != null) { return instance; } // If we already have an instance, return it
            instance = FindObjectOfType<ClientSingleton>(); // If we don't have an instance, try to find one
            if(instance == null) // If we still don't have an instance, log an error
            {
                Debug.LogError("No ClientSingleton in the scene!");
                return null;
            }
            return instance;
        }
    }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public async Task<bool> CreateClient()
    {
        GameManager = new ClientGameManager();
        return await GameManager.InitAsync();
    }

    private void OnDestroy() 
    {
        GameManager?.Dispose();
    }
}
