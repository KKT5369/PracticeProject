using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UICreateRoom : UIbase<UICreateRoom>
{
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
           
        }));
        btnCancel.onClick.AddListener(CloseUI);
    }
    
    
    
}
