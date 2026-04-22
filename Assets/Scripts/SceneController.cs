using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour
{
    public GameObject lvlOneGlow;
    public GameObject lvlTwoGlow;

    private static string _previousSceneName = "";
    
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    public void LoadCutScene1()
    {

        SceneManager.LoadScene("Cutscene1");

    }

    public void LoadMapScene()
    {
        _previousSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("MapScene");

    }

    public void LoadLevelOneScene()
    {
        _previousSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("LevelOne");
    }

    public void LoadLevelTwoScene()
    {
        _previousSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("LevelTwo");
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode) 
    {
            // resets both to be null
            if (lvlOneGlow != null) lvlOneGlow.SetActive(false);
            if (lvlTwoGlow != null) lvlTwoGlow.SetActive(false);

            // shows levelOneGlow only if coming from StartScene
            if (_previousSceneName == "StartScene")
            {
                if (lvlOneGlow != null) lvlOneGlow.SetActive(true);
            }
            
            // shows levelTwoGlow only if coming from LevelOne
            else if (_previousSceneName == "LevelOne")
            {
                if (lvlTwoGlow != null) lvlTwoGlow.SetActive(true);
            }
    }
}
