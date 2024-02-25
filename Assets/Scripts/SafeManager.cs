using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SafeManager : MonoBehaviour
{
    private Animator anim;

    private bool HasFoundSafe = false;
    private bool isCodePanelActive = false;

    [SerializeField] private TextMeshProUGUI CodeText;

    public string codeTextValue = "";

//set the code in the inspector 
    public string safeCode;
    public GameObject CodePanel;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        CodeText.text = codeTextValue;
//if the correct code has been entered the safe door animation is triggered and the code panel is deactivated 
        if(codeTextValue == safeCode)
        {
            anim.SetTrigger("OpenDoor");
            CodePanel.SetActive(false);
        }
//if the player enters the wrong code and its more than 5 numbers the code text visual is cleared so player can try again
        if(codeTextValue.Length >=5)
        {
            codeTextValue = "";
        }

        //when the player is near the safe (HasFoundSafe == true) and E is pressed the code panel will be activated or deactivated based on it activation status 
        if(Input.GetKeyDown(KeyCode.E) && HasFoundSafe == true)
        {
            isCodePanelActive = !isCodePanelActive;
            CodePanel.SetActive(isCodePanelActive);
        }
        //as we use the same code for collecting the zam zam bottle,once the playe enters the correct code if the press E the code panel will not activate again (continues to be deactivated)
        else if(codeTextValue == safeCode)
        {
            CodePanel.SetActive(false);
        }

    }

//when the object (player) with the player tag enters the collider of the safe then HasFoundSafe is true
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            HasFoundSafe = true; 
        }

        Debug.Log("SafeHasBeenFound");
    }

//when player leaves the collider of safe the HAsFoundSafe is false and the code panel is deactivated 
    private void OnTriggerExit(Collider other)
    {
        HasFoundSafe = false;
        CodePanel.SetActive(false);
    }

//shows the code text visually when the player enters it 
    public void AddDigit(string digit)
    {
        codeTextValue += digit; 
    }
}
