using UnityEditor.Callbacks;
using UnityEngine;

public class collisionscript : MonoBehaviour
{
    
    [SerializeField] private Rigidbody _rb; // rock itself
    [SerializeField]private float displacementAmount = 3f; 
    [SerializeField] private float depthBeforeSubmerged = 1f;
    [SerializeField] private Transform waterPlane; // water plane 

    private float _collisionCount = 0; // no of collisions 

    
    public void Awake(){
        //destroy the rock 
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    }
    void OnCollisionEnter(Collision col){
        // increase the collision count when a collision occurs
        
        SoundTrigger soundTrigger = new SoundTrigger(); 
        soundTrigger.continousSound();
        _collisionCount ++; 
    }

    void bouyant(){

        if(transform.position.y < 3.2f ){
            float displacementMultiplier = Mathf.Clamp01(-transform.position.y/depthBeforeSubmerged)* displacementAmount;
            _rb.AddForce( new Vector3(0f,Mathf.Abs(Physics.gravity.y)*displacementMultiplier,0f) ,ForceMode.Acceleration);
        }
    }

    void destroyIfSunk(){
        if(_rb.transform.position.y > transform.position.y){
            Destroy(gameObject,20);
        }
    }
}
