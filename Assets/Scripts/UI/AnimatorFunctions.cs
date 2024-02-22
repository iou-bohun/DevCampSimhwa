using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorFunctions : MonoBehaviour
{
	MenuButtonController menuButtonController;
	public bool disableOnce;

    private void Start()
    {
         menuButtonController = GetComponentInParent<MenuButtonController>();
    }

    void PlaySound(AudioClip whichSound){
		if(!disableOnce){
			menuButtonController.audioSource.PlayOneShot (whichSound);
		}else{
			disableOnce = false;
		}
	}
}	
