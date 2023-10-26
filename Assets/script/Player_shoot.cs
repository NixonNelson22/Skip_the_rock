using UnityEngine;

public class rock_script : MonoBehaviour
{
    [SerializeField]private float _throwForce = 20;
    [SerializeField] private GameObject _projectile; // rock prefab
    [SerializeField] private Transform _projectileSpawnPoint; // spawnpoint from where the projectile is shoot 
    [SerializeField] private Projection _projection;
 

    // Start is called before the first frame update
    
    public void Start()
    {
        
    }
    
    // Update is called once per frame
    public void Update()
    {   
        // myObj.AddForce(UnityEngine.Vector2.right*throwForce,ForceMode2D.Impulse);
        _projection.SimulateTrajectory(_projectile,_projectileSpawnPoint.position,_projectileSpawnPoint.forward*_throwForce);

        if(Input.GetKeyDown(KeyCode.Space))        
        shoot();
    }
    public void shoot(){
        var rock = Instantiate(_projectile, _projectileSpawnPoint.position, _projectileSpawnPoint.rotation);
        rock.GetComponent<Rigidbody>().AddForce(_projectileSpawnPoint.forward* _throwForce, ForceMode.Impulse);
    }

    
   
}
