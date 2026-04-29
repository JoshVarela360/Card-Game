using UnityEngine;

public class Buttons : MonoBehaviour 
{

    //Events
    public delegate void ButtonPressed();
    public static event ButtonPressed TriggerButtonSFX;
    [SerializeField] private SceneController _sceneController; 

    public GameObject _upgradePanel;
    
    public void StartButton() 
    {
        //Must Create some delay so the button will play audio before transitioning too quickly-> TriggerButtonSFX?.Invoke();
            _sceneController.LoadCutScene1(); 
    } 
    
    public void LevelOneButton() 
    {
         _sceneController.LoadLevelOneScene(); 
    } 

    public void LevelTwoButton()
    {
        _sceneController.LoadLevelBossScene();

        //_sceneController.LoadLevelTwoScene();
    }

    public void ContinueButton()
    {
        _upgradePanel.SetActive(false);
    }
}
