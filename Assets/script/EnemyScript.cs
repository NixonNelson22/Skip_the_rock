using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // animate at random times the movement of enemies
    // react to to triggers
    [SerializeField]
    private GameObject enemySprite;
    private string SwitchState = "idle";
    private bool HitState = false;
    private Animator _enemyAnimator;

    // private void Update(){
    //     if(){

    //     }
    // }

    
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
