using Unity.Mathematics;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // animate at random times the movement of enemies
    // react to to triggers
    [SerializeField]
    private GameObject enemySprite;
    //prefabs 
    [SerializeField] GameObject[] gameObjects;
    [SerializeField] Transform[] transforms; 
    
    private void SpawnEnemies(Vector2 Coord1, Vector2 Coord2){
        //this function should only run once in a scene 
        //spawn enemies in a square area
        //get the area either using the tilemap or using the vector coords
        //use random to determine positios of enemy spawn
        //spawn enemy at those locations in the scene
        // rect3 _ _ rect2
        // |             |
        // |             |
        // rect0 _ _ rect1
        Vector3 rect0 = new Vector3(Coord1.x,0f,Coord2.y); 
        Vector3 rect1 = new Vector3(Coord2.x,0f,Coord2.y); 
        Vector3 rect2 = new Vector3(Coord2.x,0f,Coord1.y); 
        Vector3 rect3 = new Vector3(Coord1.x,0f,Coord1.y); 
        Debug.DrawRay(rect0,rect1,Color.red);
        Debug.DrawRay(rect1,rect2,Color.red);
        Debug.DrawRay(rect2,rect3,Color.red);
        Debug.DrawRay(rect3,rect0,Color.red);

    }
    
  

}
