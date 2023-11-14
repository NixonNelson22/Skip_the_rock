using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using Etouch = UnityEngine.InputSystem.EnhancedTouch;
public class PlayerControl : MonoBehaviour
{
    //OTHER CLASSES
    [SerializeField] private PlayerShoot _playerShoot;
    //
    private Vector2 swipeDelta;
    private float _xAngle, _yAngle;
    private Quaternion rotationEuler;
    // X ANGLE CAN BE 0 - 20
    // Y ANGLE CAN BE -80 - 80
    
    Vector2 initPos,endPos,movingPos;

    // using action map//
    private TouchControls touchControl;
    private void Awake(){
        touchControl = new TouchControls();
    }
    private void OnEnable(){
        // using action map//
        touchControl.PlayerControl.Enable();

        // using enhanced touch api//
    //     EnhancedTouchSupport.Enable();
    //     Etouch.Touch.onFingerDown += Touch_onFingerDown;
    //     Etouch.Touch.onFingerUp += Touch_onFingerUp;
    //     Etouch.Touch.onFingerMove += Touch_onFingerMove;
    
    }
    private void OnDisable(){
        // using action map//
        touchControl.PlayerControl.Disable();
    
        // // using enhanced touch api//
        // EnhancedTouchSupport.Disable();
        // Etouch.Touch.onFingerDown -= Touch_onFingerDown;
        // Etouch.Touch.onFingerUp -= Touch_onFingerUp;
        // Etouch.Touch.onFingerMove -= Touch_onFingerMove;
    }
    private void Start(){
        touchControl.PlayerControl.TouchPos.started += ctx => TapStarted(ctx);
        touchControl.PlayerControl.TouchPos.performed += ctx => TapPerformed(ctx);
        touchControl.PlayerControl.TouchMove.performed += ctx => Movement(ctx);
    }
    // using action map//
    private void TapStarted(InputAction.CallbackContext context){
        initPos = context.ReadValue<Vector2>();
        // Debug.Log(initPos);
    }
    private void TapPerformed(InputAction.CallbackContext context){
        // _playerShoot.Shoot(13f);
        
        movingPos= context.ReadValue<Vector2>();
        // Debug.Log("finger pos"+movingPos);
       
        
    }
    private void Movement(InputAction.CallbackContext ctx){
              
        
    }

    void FixedUpdate(){
        swipeDelta = movingPos-initPos;
        Debug.Log(swipeDelta);
        Vector3 rotate = new Vector3(-swipeDelta.y,swipeDelta.x,0f)* Time.deltaTime * 10 ;
        // rotationEuler.eulerAngles = rotate;
        rotationEuler = Quaternion.Euler(rotate);
        transform.rotation = rotationEuler;
    }
    
    // using enhanced touch api//
    // private void Touch_onFingerDown(Finger touchedFinger){
    //     initTouchPos= touchedFinger.screenPosition;
    // }
    // private void Touch_onFingerUp(Finger touchedFinger){
    //     endTouchPos= touchedFinger.screenPosition;
    // }
    // private void Touch_onFingerMove(Finger touchedFinger){
    //     movingPos = touchedFinger.screenPosition;
    //     Debug.Log("finger moving "+movingPos);
    // }


    private void Update(){
        // if(swipeDelta.y<0){
        //     if(_xAngle<20)
        //     _xAngle++;
        // }
        // if(swipeDelta.y>0){
        //     if(_xAngle>0)
        //     _xAngle--;
        // }
        //  if(swipeDelta.x<0){
        //     if(_xAngle<80)
        //     _yAngle++;
        // }
        // if(swipeDelta.y>0){
        //     if(_xAngle>-80)
        //     _yAngle--;
        // }
        
        
       
       
    }

    
}
