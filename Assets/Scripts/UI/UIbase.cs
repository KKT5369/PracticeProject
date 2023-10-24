using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIbase<T> : MonoBehaviour
{
    private UIManager UI;

    private void Start()
    {
        UI = UIManager.Instance;
    }

    protected void CloseUI()
    {
        UIManager.Instance.CloseUI<T>();
    }
}
