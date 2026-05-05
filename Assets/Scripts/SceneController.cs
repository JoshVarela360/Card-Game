using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour
{
    //[SerializeField] PlayerDeck _playerDeck;
    [SerializeField] Buttons _buttons;
    public GameObject lvlOneGlow;
    public GameObject lvlTwoGlow;
    public GameObject lvlThreeGlow;
    public GameObject lvlBossGlow;
    public GameObject endGamePanel;

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

    public void LoadLevelThreeScene()
    {
        _previousSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("LevelThree");
    }

    public void LoadLevelBossScene()
    {
        _previousSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("LevelBoss");
    }

    public void LoadStartScene()
    {
        _previousSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("StartScene");
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode) 
    {
        // resets both to be null
        if (lvlOneGlow != null) lvlOneGlow.SetActive(false);
        if (lvlTwoGlow != null) lvlTwoGlow.SetActive(false);

        // shows levelOneGlow only if coming from StartScene
        if (_previousSceneName == "Cutscene1")
        {
            if (lvlOneGlow != null) lvlOneGlow.SetActive(true);
        }
        

        // shows levelTwoGlow only if coming from LevelOne
        else if (_previousSceneName == "LevelOne")
        {
            if (PlayerDeck.isGameOver == false)
            {
                if (lvlTwoGlow != null) lvlTwoGlow.SetActive(true);
            }
            else
            {
                if (lvlOneGlow != null) lvlOneGlow.SetActive(true);
            }
        }
 
        // shows levelThreeGlow only if coming from LevelTwo
        else if (_previousSceneName == "LevelTwo")
        {
            if (lvlThreeGlow != null) lvlThreeGlow.SetActive(true);
        }

        // shows levelBossGlow only if coming from LevelThree
        else if (_previousSceneName == "LevelThree")
        {
            if (lvlBossGlow != null) lvlBossGlow.SetActive(true);
        }
    
        else if (_previousSceneName == "LevelBoss")
        {
            if (endGamePanel != null) endGamePanel.SetActive(true);
        }
    }
}
