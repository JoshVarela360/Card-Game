using UnityEngine;
using TMPro;
public class UpgradeSystem : MonoBehaviour
{

    [SerializeField] GameObject _upgradePopUp;
    //Upgrade buttons
    [SerializeField] GameObject _cowUpButt;
    [SerializeField] GameObject _andUpButt;
    [SerializeField] GameObject _empUpButt;


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



    void Start()
    {
        Monster.AddCrystal += IncreaseCrystals;
        UpdateGameStats();

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
    }
    public void CloseUpgradeUI()
    {
        _upgradePopUp.SetActive(false);

    }

    public void UpgradeCowboyStats()
    {
        if (_crystal._number >= 1)
        {
            _cowboyInfo.damage += 10;
            _cowboyInfo.health += 10;
            --_crystal._number;
            Debug.Log("work");
            UpdateGameStats();
            if (_crystal._number == 0)
            {
                _cowUpButt.SetActive(false);
            }
        }



    }
    public void UpgradeEmpressStats()
    {
        if (_crystal._number >= 1)
        {
            _empressInfo.damage += 10;
            _empressInfo.health += 10;
            --_crystal._number;
            Debug.Log("work");
            UpdateGameStats();
            if (_crystal._number == 0)
            {
                _empUpButt.SetActive(false);
            }
        }

    }
    public void UpgradeAndroidStats()
    {
        if (_crystal._number >= 1)
        {
            _androidInfo.damage += 10;
            _androidInfo.health += 10;
            --_crystal._number;
            Debug.Log("work");
            UpdateGameStats();
            if (_crystal._number == 0)
            {
                _andUpButt.SetActive(false);
            }
        }



    }
    public void IncreaseCrystals(int amount)
    {
        _crystal._number += amount;
    }
}
