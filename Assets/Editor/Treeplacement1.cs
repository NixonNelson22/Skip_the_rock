using UnityEngine;
using UnityEditor;
using UnityEditor.TerrainTools;
using UnityEngine.UIElements;
using Unity.Collections;
using Unity.VisualScripting;
using TreeEditor;


public class Treeplacement : EditorWindow 
{
    // Start is called before the first frame update
    /* get the hieght map of the terrain 
        If mouse is held over the terrain then :
            get the tree objects and place them on top of the terrain and certain distance away from water
            get the foliage object and place them on top of the terrain 
        if mouse and shift is held over the terrain 
            remove the objects 
    */
    
    GameObject spawnObject;
    static bool spawnEnable;    
    int spawnRadius;
    float x,y,z;
    bool paintbtn ;



    [MenuItem("Tools/basic object spawner")]
    public static void ShowWindow(){
        GetWindow(typeof(Treeplacement));
    }


    // [UnityEditor.Callbacks.DidReloadScripts]
    // public static void getSceneView(){
    //     SceneView.duringSceneGui += DuringSceneGui;
    // }


    private  void OnGUI(){
        GUILayout.Label("object spawner",EditorStyles.boldLabel);
     

        spawnRadius = EditorGUILayout.IntField("Spawn radius", spawnRadius);
        spawnObject = EditorGUILayout.ObjectField("prefab to spawn", spawnObject, typeof(GameObject), false) as GameObject;
        
        
        // bool spawn = GUILayout.Button("Spawn object");
        // Debug.Log(spawn);
        paintbtn = GUILayout.Toggle(paintbtn,"paint");
        // Vector3 direction = new Vector3(0,f,0);
        Ray ray;
        RaycastHit hit;
        ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
        if (Physics.Raycast(ray, out hit)){
            x = hit.point.x;
            y = 0;
            z = hit.point.z;
        }
        
        
        if(paintbtn){
            // Debug.Log(EditorWindow.mouseOverWindow.ToString() + UnityEditor.SceneView.mouseOverWindow.ToString());
            // Debug.Log(e.mousePosition + "ray "+ ray.origin);
            // Debug.Log(e.isMouse );
            // Debug.Log(e.keyCode );
            SpawnObject();
        }
        

        

    }
    
    // public static void DuringSceneGui(SceneView sceneView){
    //         Event e = Event.current;
    //         if(e.type == EventType.MouseDown && e.button == 0)
    //         {
    //             spawnEnable = true;
    //         }
    //         spawnEnable = false;

    // }
    
    private void SpawnObject(){
        if(spawnObject==null){
            Debug.LogError("Error:please asign an object to be spawned.");
            return;
        }
        
        Vector3 spawnPos = new Vector3(x,y,z);
        spawnPos.x += Random.Range(-spawnRadius,spawnRadius);
        spawnPos.y += Random.Range(-spawnRadius,spawnRadius);
        
        GameObject newObject = Instantiate(spawnObject,spawnPos,Quaternion.identity);
        
    }

}
