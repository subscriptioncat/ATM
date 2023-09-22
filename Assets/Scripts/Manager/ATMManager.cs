using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATMManager : MonoBehaviour
{
    private static ATMManager instance;
    public static ATMManager Instance
    {
        get
        {
            if(instance == null)
            {
                GameObject go = new GameObject();
                instance = go.AddComponent< ATMManager>();
            }
            return instance;
        }
    }

    private void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
