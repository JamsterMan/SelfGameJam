﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    public static bool uiCreated = false;
    private void Awake()
    {
        if(uiCreated)
        {
            Destroy(gameObject);
        }
        uiCreated = true;
        DontDestroyOnLoad(gameObject);
    }

}

