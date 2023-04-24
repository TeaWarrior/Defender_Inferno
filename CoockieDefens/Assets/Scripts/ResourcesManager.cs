using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ResourcesManager : MonoBehaviour
{
    public int Wood { private set; get; }
    public event EventHandler OnChangeResources;

    public static ResourcesManager instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    public void AddWood(int wood)
    {
        Wood += wood;
        OnChangeResources?.Invoke(this, EventArgs.Empty);
    }
    public void RemoveWood(int wood)
    {
        if (Wood >= wood)
        {
            Wood -= wood;
            OnChangeResources?.Invoke(this, EventArgs.Empty);
        }
        Debug.Log("No Wood");
     
    }
    void Update()
    {
        
    }
}
