﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swaprole : MonoBehaviour
{
    public static Swaprole chooserole {get; private set;}
    public string Role = "Survival"; //Dont destroyonload & Instance
    // Start is called before the first frame update
    public void Awake()
    {
        if(chooserole == null)
        {
            chooserole = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        Destroy(gameObject);
    }
}
