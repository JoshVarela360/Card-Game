using UnityEngine;
using System.Collections;

public class Buttons : MonoBehaviour 
{

    //Events
    public delegate void ButtonPressed();
    public static event ButtonPressed TriggerButtonSFX;
    [SerializeField] private SceneController _sceneController; 
    public AudioSource buttonClickSound;

    public GameObject _upgradePanel;
    public GameObject _endGamePanel;
    

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
     

    public void LevelTwoButton()
    {
        StartCoroutine(LevelBossButtonRoutine());

        //_sceneController.LoadLevelBossScene();

        //_sceneController.LoadLevelTwoScene();
    }

    private IEnumerator LevelBossButtonRoutine()
    {
        buttonClickSound.Play();

        yield return new WaitForSeconds(buttonClickSound.clip.length);
       
        _sceneController.LoadLevelBossScene();
    }

    public void ContinueButton()
    {
        buttonClickSound.Play();
        
        _upgradePanel.SetActive(false);
    }

    public void XButton()
    {
        _endGamePanel.SetActive(false);
    }
}
