using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalControl : MonoBehaviour {

    public static GlobalControl Instance;

    public List<GameObject> deck_list = new List<GameObject>();

    void Awake()
    {
        if(Instance == null) //if there is a list, the object is not destroyed
        {
            DontDestroyOnLoad(gameObject);
            Instance = this; 
        }
        else if(Instance != this)
        {
            Destroy(gameObject);
        }
    }
}
