using System;
using System.Collections;
using System.Collections.Generic;
using Data;
using Fusion;
using Fusion.Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UICreateRoom : UIbase<UICreateRoom>
{
    [SerializeField] private TMP_Dropdown dropdownPlayerCount;
    
    [SerializeField] private Button btnCreate;
    [SerializeField] private Button btnCancel;

    private new void Start()
    {
        base.Start();
        SetAddListener();
    }

    void SetAddListener()
    {
        btnCreate.onClick.AddListener((() =>
        {
           
        }));
        btnCancel.onClick.AddListener(CloseUI);
    }
    
    
    
}
