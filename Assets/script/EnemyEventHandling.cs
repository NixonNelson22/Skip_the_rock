using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEventHandling : MonoBehaviour
{
    private string SwitchState = "idle";
    private bool HitState = false;
    private Animator _enemyAnimator;
    private void Start(){
        _enemyAnimator= GetComponent<Animator>();
    }

    private void enemyHit()
    {
        if(HitState){
            SwitchState="jump";
            SwitchState=
        }   
        HitState=false;
        
    }
    private void OnTrigerEnter(Collider coll){
        HitState = true;
    }
    

    private void SwitchAnimationState(){
        switch(SwitchState){
        case "underwater":
            _enemyAnimator.Play("frogUnderwater");
            break;
        case "jump":
            _enemyAnimator.Play("frogJump");
            break;
        default:
            _enemyAnimator.Play("frogIdle");
            break;
        }

    }
}
