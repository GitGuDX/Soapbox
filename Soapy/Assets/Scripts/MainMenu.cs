
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
   
    public void GoToScene(string sceneName){
        SceneManager.LoadScene("Game");
    }

    public void quitGame(){
        Application.Quit();
        Debug.Log("Game Quit!");
    }
}