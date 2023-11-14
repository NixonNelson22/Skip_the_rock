
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void PlayGame(){
        SceneManager.LoadScene("level1");
    }
    public void Quit(){
        Application.Quit();
    }
    
}
