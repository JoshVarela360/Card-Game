using UnityEngine;

public class Buttons : MonoBehaviour
{
   [SerializeField] private SceneController _sceneController;

    public void StartButton()
    {
        _sceneController.LoadMapScene();
    }

    public void LevelOneButton()
    {
        _sceneController.LoadGameScene();
    }
}
