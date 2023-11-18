using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerControl : MonoBehaviour
{
    //OTHER CLASSES
    [SerializeField] private PlayerShoot _playerShoot;
    [SerializeField]int shootInterval;
    //
    private Vector2 swipeDelta;
    private float _xAngle, _yAngle;
    private Quaternion rotationEuler;
    // X ANGLE CAN BE 0 to 20
    // Y ANGLE CAN BE -80 to 80
    
    Vector2 initPos,endPos,movingPos;

    // using action map//
    private TouchControls touchControl;
    private void Awake(){
        touchControl = new TouchControls();
    }
    private void OnEnable(){
        // using action map//
        touchControl.PlayerControl.Enable();

    
    }
    private void OnDisable(){
        // using action map//
        touchControl.PlayerControl.Disable();
    

    }
    private void Start(){
        touchControl.PlayerControl.TouchPos.started += ctx => TapStarted(ctx);
        touchControl.PlayerControl.TouchPos.performed += ctx => TapPerformed(ctx);
        
    }
    // using action map//
    private void TapStarted(InputAction.CallbackContext context){
        
        initPos = context.ReadValue<Vector2>();
        // Debug.Log(initPos);
    }
   
    private void TapPerformed(InputAction.CallbackContext context){
        
        movingPos= context.ReadValue<Vector2>();
        // swipeDelta = movingPos-initPos;
        // Debug.Log("finger pos"+movingPos);
       
        
    }

    void FixedUpdate(){
        
        // Debug.Log(swipeDelta);

        if(movingPos.x>0){
            if(_yAngle<80){
                _yAngle++;   
            }
        }
        if(movingPos.x<0){
            if(_yAngle>-80){
                _yAngle--;   
            }
        }
        if(movingPos.y>0){
            if(_xAngle<20){
                _xAngle++;   
            }
        }
        if(movingPos.y<0){
            if(_xAngle>0){
                _xAngle--;   
            }
        }
        Vector3 rotate = new Vector3(_xAngle,_yAngle,0f)*10 ;
        // rotationEuler.eulerAngles = rotate;
        Debug.Log(rotate);
        rotationEuler = Quaternion.Euler(rotate);
        transform.rotation = rotationEuler;
    
    }
    IEnumerator wait(int i){
        yield return new WaitForSeconds(i);
    }
    public void shoot(){
        wait(shootInterval);
        _playerShoot.Shoot(13f,shootInterval);
    }
    
}
