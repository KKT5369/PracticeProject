using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UICreateRoom : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputRoomName;
    [SerializeField] private TMP_InputField inputRoomPs;
    [SerializeField] private TMP_Dropdown dropdownPlayerCount;
    
    [SerializeField] private Button btnCreate;
    [SerializeField] private Button btnCancel;

    private void Start()
    {
        SetAddListener();
    }

    void SetAddListener()
    {
        btnCreate.onClick.AddListener((() =>
        {
            print($"{inputRoomName.text}");
            print($"{inputRoomPs.text}");
            print($"{dropdownPlayerCount.captionText.text}");
        }));
    }
    
}
