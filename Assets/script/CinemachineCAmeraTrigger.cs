using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CinemachineCAmeraTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private InputAction action;
    private Animator animator;
    bool playerCamera=true;
    void Awake(){
        animator = GetComponent<Animator>();
    }
    void OnEnable(){
        action.Enable();
    }
    void OnDisable(){
        action.Disable();
    }

    void Start()
    {
        action.performed += _ => SwitchState();
    }

    // Update is called once per frame
    void SwitchState(){
        if(playerCamera){
            animator.Play("playerCamera");
        }
        else{
            animator.Play("rockCamera");
        }
        playerCamera =!playerCamera; 
    }
}
