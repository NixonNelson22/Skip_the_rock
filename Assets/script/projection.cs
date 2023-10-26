using UnityEngine;
using UnityEngine.SceneManagement;

public class Projection : MonoBehaviour
{
    private Scene _simulationScene;
    private PhysicsScene _physicsScene;
    [SerializeField] private Transform _enemySprites;
    // Start is called before the first frame update
    void Start()
    {
        CreatePhysicsScene();
    }

    void CreatePhysicsScene(){
        _simulationScene = SceneManager.CreateScene("simulaton", new CreateSceneParameters(LocalPhysicsMode.Physics3D));
        _physicsScene = _simulationScene.GetPhysicsScene();

        foreach(Transform obj in _enemySprites){
            var ghostObj = Instantiate(obj.gameObject,obj.position,obj.rotation);
            ghostObj.GetComponent<Renderer>().enabled = false;
            SceneManager.MoveGameObjectToScene(ghostObj,_simulationScene);
        }

    }
    [SerializeField] private LineRenderer _line;
    [SerializeField] private int _maxphysicsFrameIterations;

    public void SimulateTrajectory(GameObject rock, Vector3 pos, Vector3 veloccity){

        var ghostObj = Instantiate(rock,pos,Quaternion.identity);
        ghostObj.GetComponent<Renderer>().enabled = false;
        SceneManager.MoveGameObjectToScene(ghostObj.gameObject,_simulationScene);

        _line.positionCount = _maxphysicsFrameIterations;

        for(int i=0; i < _maxphysicsFrameIterations;i++){
            _physicsScene.Simulate(Time.fixedDeltaTime);
            _line.SetPosition(i,ghostObj.transform.position);
        }
        Destroy(ghostObj.gameObject);
    }


  
}
