using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private PlayerManager playerManager;
    private TextManager textManager;

    public AudioClip textMessageTone;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playerManager = FindObjectOfType<PlayerManager>();
        textManager = FindObjectOfType<TextManager>();

        if (playerManager !=null && textManager !=null)
        {
            int currentPhotoIndex = playerManager.currentPhotoIndex;

            if(currentPhotoIndex == 1)
            {
                audioSource.PlayOneShot(textMessageTone);
            }
        }
        
    }
    // Update is called once per frame
    
}
