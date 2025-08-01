using System;
using System.Collections.Generic;
using UnityEngine;

public partial class Factory : MonoBehaviour
{
    public static Factory _instance;
    public static Factory Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindAnyObjectByType<Factory>();
            }
            return _instance;
        }
    }

    void Start()
    {
        Initialized();
    }

    private void Initialized()
    {
       
    }

    public void Destroy(BaseCharacter entity)
    {
     
    }
}
