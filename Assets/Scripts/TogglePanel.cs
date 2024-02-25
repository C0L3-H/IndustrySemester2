using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TogglePanel : MonoBehaviour
{
    public GameObject textPanel;

    void Awake()
    {
        textPanel.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            ChangePanel();
        }
    }

    void ChangePanel()
    {
        if(textPanel.activeSelf)
        {
            textPanel.SetActive(false);
        }
        else {
            textPanel.SetActive(true);
        }
    }
}
