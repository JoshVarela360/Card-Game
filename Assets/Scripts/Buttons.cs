using UnityEngine;
using System.Collections;

public class Buttons : MonoBehaviour
{

    //Events
    public delegate void ButtonPressed();
    public static event ButtonPressed TriggerButtonSFX;
    [SerializeField] private SceneController _sceneController;

    public GameObject lvlOneButton;
    public GameObject lvlTwoButton;
    public GameObject lvlThreeButton;
    public GameObject lvlBossButton;

    public AudioSource buttonClickSound;

    public GameObject _upgradePanel;
    public GameObject _endGamePanel;

    // StartButton all
    public void StartButton()
    {
        StartCoroutine(StartButtonRoutine());
    }

    private IEnumerator StartButtonRoutine()
    {
        buttonClickSound.Play();

        yield return new WaitForSeconds(buttonClickSound.clip.length);

        _sceneController.LoadCutScene1();
    }

    // LevelOneButton all
    public void LevelOneButton()
    {
        StartCoroutine(LevelOneButtonRoutine());
    }

    private IEnumerator LevelOneButtonRoutine()
    {
        buttonClickSound.Play();

        yield return new WaitForSeconds(buttonClickSound.clip.length);

        _sceneController.LoadLevelOneScene();

    }

    // LevelTwoButton all
    public void LevelTwoButton()
    {
        StartCoroutine(LevelTwoButtonRoutine());
    }

    private IEnumerator LevelTwoButtonRoutine()
    {
        buttonClickSound.Play();

        yield return new WaitForSeconds(buttonClickSound.clip.length);

        _sceneController.LoadLevelTwoScene();
    }

    // LevelThreeButton all
    public void LevelThreeButton()
    {
        StartCoroutine(LevelThreeButtonRoutine());
    }

    private IEnumerator LevelThreeButtonRoutine()
    {
        buttonClickSound.Play();

        yield return new WaitForSeconds(buttonClickSound.clip.length);

        _sceneController.LoadLevelThreeScene();
    }

    // LevelBossButton all
    public void LevelBossButton()
    {
        StartCoroutine(LevelBossButtonRoutine());
    }

    private IEnumerator LevelBossButtonRoutine()
    {
        buttonClickSound.Play();

        yield return new WaitForSeconds(buttonClickSound.clip.length);

        _sceneController.LoadLevelBossScene();
    }

    // MapButton all
    public void MapButton()
    {
        StartCoroutine(MapButtonRoutine());

        PlayerDeck.isGameOver = true;
    }

    private IEnumerator MapButtonRoutine()
    {
        buttonClickSound.Play();

        yield return new WaitForSeconds(buttonClickSound.clip.length);

        _sceneController.LoadMapScene();
    }

    public void ContinueButton()
    {
        buttonClickSound.Play();
        _upgradePanel.SetActive(false);
        LocatorScript.Instance.UpgradeManager.CloseUpgradeUI();
    }

    public void XButton()
    {
        buttonClickSound.Play();
        _endGamePanel.SetActive(false);
    }

    // // test
    // public void SkipToMapButton()
    // {
    //     _sceneController.LoadMapScene();
    // }
}
