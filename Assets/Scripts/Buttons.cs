using UnityEngine;

public class Buttons : MonoBehaviour 
{
    [SerializeField] private SceneController _sceneController; 

    public GameObject _upgradePanel;
    
    public void StartButton() 
    { 
        _sceneController.LoadCutScene1(); 
    } 
    
    public void LevelOneButton() 
    {
         _sceneController.LoadLevelOneScene(); 
    } 

    public void LevelTwoButton()
    {
        _sceneController.LoadLevelTwoScene();
    }

    public void ContinueButton()
    {
        _upgradePanel.SetActive(false);
    }
}
