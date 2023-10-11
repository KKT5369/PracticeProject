using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILobby : MonoBehaviour
{
    [SerializeField] private Button btnCreateRoom;
    [SerializeField] private Button btnJoinRoom;
    [SerializeField] private Button btnOption;
    [SerializeField] private Button btnExit;

    private void Start()
    {
        SetAddListener();
    }

    void SetAddListener()
    {
        var uiManager = UIManager.Instance;
        btnCreateRoom.onClick.AddListener((() => uiManager.OpenUI<UICreateRoom>()));
        btnJoinRoom.onClick.AddListener((() => uiManager.OpenUI<UICreateRoom>()));
    }
}
