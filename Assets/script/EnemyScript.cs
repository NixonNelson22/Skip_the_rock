using Unity.Mathematics;
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
    
    //prefabs 
    [SerializeField] GameObject[] gameObjects;
    
    private void SpawnEnemies(Vector2 Coord1, Vector2 Coord2){
        //this function should only run once in a scene 
        //spawn enemies in a square area
        //get the area either using the tilemap or using the vector coords
        //use random to determine positios of enemy spawn
        //spawn enemy at those locations in the scene
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
