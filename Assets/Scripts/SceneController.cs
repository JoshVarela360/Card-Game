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
        //SceneManager.LoadScene("Combat level");
        SceneManager.LoadScene("Level2");
    }

}
