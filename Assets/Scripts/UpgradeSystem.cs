using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using Unity.VectorGraphics;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UpgradeSystem : MonoBehaviour
{

    [SerializeField] Shader _fireVFX;

    [SerializeField] GameObject _upgradePopUp;

    //Upgrade buttons
    [SerializeField] GameObject _cowUpButt;
    [SerializeField] GameObject _andUpButt;
    [SerializeField] GameObject _empUpButt;
    [SerializeField] Button _cowboySelectionButton;
    [SerializeField] Button _empressSelectionButton;
    [SerializeField] Button _androidSelectionButton;

    [SerializeField] public GameObject _cowboyEffect;
    [SerializeField] public GameObject _empressEffect;
    [SerializeField] public GameObject _androidEffect;


    //ScriptableObjects
    [SerializeField] public CardInformation _androidInfo;
    [SerializeField] public CardInformation _cowboyInfo;
    [SerializeField] public CardInformation _empressInfo;

    //CardGUI
    [SerializeField] TextMeshProUGUI _cowHP;
    [SerializeField] TextMeshProUGUI _cowATK;
    [SerializeField] TextMeshProUGUI _empHP;
    [SerializeField] TextMeshProUGUI _empATK;
    [SerializeField] TextMeshProUGUI _andHP;
    [SerializeField] TextMeshProUGUI _andATK;


    //variables - SWITCH TO A SCRIPTABLE OBJECT

    [SerializeField] public Crystal _crystal;

    private static string _currentSceneName = "";


    void Start()
    {
        Monster.AddCrystal += IncreaseCrystals;
        UpdateGameStats();
        OpenUpgradeUI();

        _currentSceneName = SceneManager.GetActiveScene().name;

        if (SceneManager.GetActiveScene().name == ("LevelOne"))
        {
            Debug.Log("Level One");
            //CloseUpgradeUI();
        }
    }




    public void UpdateGameStats()
    {

        //Emperor stats UI
        _empATK.text = _empressInfo.damage.ToString();

        _empHP.text = _empressInfo.health.ToString();

        //Cowboy stats UI
        _cowATK.text = _cowboyInfo.damage.ToString();

        _cowHP.text = _cowboyInfo.health.ToString();

        //Android stats UI
        _andATK.text = _androidInfo.damage.ToString();

        _andHP.text = _androidInfo.health.ToString();

    }
    // Update is called once per frame

    public void OpenUpgradeUI()
    {
        _upgradePopUp.SetActive(true);
        _empressSelectionButton.enabled = false;
        _androidSelectionButton.enabled = false;
        _cowboySelectionButton.enabled = false;
    }
    public void CloseUpgradeUI()
    {
        _upgradePopUp.SetActive(false);
        _empressSelectionButton.enabled = true;
        _androidSelectionButton.enabled = true;
        _cowboySelectionButton.enabled = true;

    }

    public void UpgradeCowboyStats()
    {
        if (_crystal._number >= 1)
        {
            _cowboyEffect.GetComponent<SpriteRenderer>().sharedMaterials[0].shader = _fireVFX;
            _cowboyEffect.SetActive(true);
            _cowboyInfo.damage += 10;
            _cowboyInfo.health += 10;
            --_crystal._number;

            UpdateGameStats();

        }



    }
    public void UpgradeEmpressStats()
    {
        if (_crystal._number >= 1)
        {
            _empressEffect.GetComponent<SpriteRenderer>().sharedMaterials[0].shader = _fireVFX;
            _empressEffect.SetActive(true);
            _empressInfo.damage += 20;
            _empressInfo.health += 10;
            --_crystal._number;

            UpdateGameStats();

        }

    }
    public void UpgradeAndroidStats()
    {
        if (_crystal._number >= 1)
        {
            _androidEffect.GetComponent<SpriteRenderer>().sharedMaterials[0].shader = _fireVFX;
            _androidEffect.SetActive(true);
            _androidInfo.damage += 10;
            _androidInfo.health += 10;
            --_crystal._number;

            UpdateGameStats();

        }



    }
    public void IncreaseCrystals(int amount)
    {
        _crystal._number += amount;
    }

    private void OnDestroy()
    {
        Monster.AddCrystal -= IncreaseCrystals;
    }
}
