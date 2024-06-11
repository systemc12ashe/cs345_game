using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PersistentVars : MonoBehaviour
{
    private static PersistentVars audio;
    private void Awake()
    {
        if (audio == null)
        {
            audio = this;
        }
        else
        {
            Destroy(this.GameObject());
        }
        DontDestroyOnLoad(this.GameObject());
    }
}
