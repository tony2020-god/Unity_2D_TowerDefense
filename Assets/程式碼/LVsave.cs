﻿using UnityEngine;
using UnityEngine.SceneManagement;//引用場景管理API

public class LVsave : MonoBehaviour
{
    public static int lastLV = 1;
    public static LVsave instance;

    public void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        print("lv為 :" + lastLV);
    }
   
}
