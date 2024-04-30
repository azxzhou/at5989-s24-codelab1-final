using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupremeGameManager : MonoBehaviour
{
    public static SupremeGameManager instance;

    public bool maze1 = false;

    public bool maze2 = false;

    public bool maze3 = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
