using System.Runtime.InteropServices;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    private float _ThrowForce ;

    [SerializeField]
    private GameObject _projectile; // rock prefab

    [SerializeField]
    private Transform _projectileSpawnPoint; // spawnpoint from where the projectile is shoot

    [SerializeField]
    private projection _projection;

    private Animator _playerAnimator;
    private bool SwitchState = false;

    void Start(){
        _playerAnimator= GetComponent<Animator>();
    }

    public void Shoot(float throwForce)
    {
        SwitchState = true;
        GameObject rock = Instantiate(_projectile,_projectileSpawnPoint.position,_projectileSpawnPoint.rotation);
        rock.GetComponent<Rigidbody>().AddForce( _projectileSpawnPoint.forward*throwForce,ForceMode.Impulse);
    }
    private void SwitchAnimationState(){
        if(SwitchState){
            _playerAnimator.Play("playerThrow");
        }else{
            _playerAnimator.Play("playerIdle");
        }
        SwitchState = !SwitchState;
    }
}
