using UnityEngine;
using UnityEngine.SceneManagement; 
public class SceneController : MonoBehaviour 
{
    public void LoadMapScene() 
    { 
        SceneManager.LoadScene("MapScene"); 
        //Debug.Log("Map Scene"); 
    } 
    
    public void LoadGameScene() 
    {
        //Debug.Log("Game Scene"); 
        SceneManager.LoadScene("Kristin Ememy Testing"); 
    } 
}
