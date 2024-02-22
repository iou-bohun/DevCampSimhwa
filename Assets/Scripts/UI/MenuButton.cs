using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
	MenuButtonController menuButtonController;
	Animator animator;
	AnimatorFunctions animatorFunctions;
	[SerializeField] int thisIndex;

    private void Start()
    {
        menuButtonController = GetComponentInParent<MenuButtonController>();	
		animator = GetComponent<Animator>();
		animatorFunctions = GetComponent<AnimatorFunctions>();
    }

    // Update is called once per frame
    void Update()
    {
		if(menuButtonController.index == thisIndex)
		{
			animator.SetBool ("selected", true);
			if(Input.GetAxis ("Submit") == 1){
				animator.SetBool ("pressed", true);
			}else if (animator.GetBool ("pressed")){
				animator.SetBool ("pressed", false);
				animatorFunctions.disableOnce = true;
			}
		}else{
			animator.SetBool ("selected", false);
		}
    }
}
