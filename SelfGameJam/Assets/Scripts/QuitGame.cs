﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public void CloseGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
