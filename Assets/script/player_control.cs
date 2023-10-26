
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;
    [SerializeField] private Transform playerPos;
    
    void update(){
        if(Input.GetTouch(0).phase == TouchPhase.Began){
            startTouchPosition = Input.GetTouch(0).position;
        }
        if(Input.GetTouch(0).phase == TouchPhase.Ended){
            endTouchPosition= Input.GetTouch(0).position;
            if(endTouchPosition.x < startTouchPosition.x){
                playerPos.localEulerAngles = new Vector3(0,playerPos.rotation.y + 1,0) ;
            }
        }
    }
}
