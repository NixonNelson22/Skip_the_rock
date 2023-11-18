using UnityEngine;

public class RockScript: MonoBehaviour
{
    [SerializeField]
    private float _WaterDensity = 1000f;

    [SerializeField]
    private float _SinkingDistance = 10f;

    [SerializeField] 
    private float _SurfaceTension = 190f;

       
    // private Transform _waterPlane; // water plane
    [SerializeField]
    private float _waterPlane = 3.16f;
    private Rigidbody rigid;
    public float _collisionCount = 0; // no of collisions
    private float boyantForce;
    float depth;
    ContactPoint[] _Contacts;

    private void Awake(){
        // _waterPlane= GameObject.Find("Water").transform;
        
    }
    private void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody>();
        
    }
    

    // Update is called once per frame
    private void FixedUpdate()
    {
        Bouyant();
        DestroyIfSunk();
        Velocity();
       
    }

    // private void OnCollisionEnter(Collision col)
    // {
    //     // increase the collision count when a collision occurs
    //     //play a sound
    //     col.GetContacts(_Contacts);
    //     foreach (ContactPoint contact in _Contacts)
    //     {
    //         if (contact.otherCollider.name == "Water")
    //         {
    //             SoundManager trigger = new SoundManager();
    //             // trigger.(); // add the variable

    //         }
    //         if(contact.otherCollider.name == "Terrain"){
    //             DestroyIfSunk(true);
    //         }
            
    //     }
    //     _collisionCount = col.contactCount;
    //     Debug.Log("collisions / skips" + col.contactCount);
    // }
    private void OnTrigerEnter(Collider collider){
            Debug.Log(collider);
    }
    private void OnCollisionExit(){
        // instantiate a gameobject with splash animation
    }

    private void Bouyant()
    {
        
        if (transform.position.y < _waterPlane)
        {
            depth = _waterPlane - transform.position.y;
            boyantForce = _WaterDensity* Mathf.Abs(depth)*Time.deltaTime;
        }
    }

    private void DestroyIfSunk()
    {
        // velocity is less
        // the angle of attack is too low or high
        if(_waterPlane-transform.position.y >=_SinkingDistance)
        {
            Destroy(gameObject, 3);
        }
    }

    public void Velocity()
    {
        rigid.AddForce(new Vector3(0,boyantForce -_SurfaceTension*Time.deltaTime,0), ForceMode.Force);
    }
}
