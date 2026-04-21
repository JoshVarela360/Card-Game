using UnityEngine;

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


    //variables - SWITCH TO A SCRIPTABLE OBJECT

    [SerializeField] public Crystal _crystal;



    void Start()
    {
        Monster.AddCrystal += IncreaseCrystals;

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
            _cowUpButt.SetActive(false);
        }



    }
    public void UpgradeEmpressStats()
    {
        if (_crystal._number >= 1)
        {
            _empressInfo.damage += 10;
            _empressInfo.health += 10;
            --_crystal._number;
            _empUpButt.SetActive(false);
            Debug.Log("work");
        }

    }
    public void UpgradeAndroidStats()
    {
        if (_crystal._number >= 1)
        {
            _androidInfo.damage += 10;
            _androidInfo.health += 10;
            --_crystal._number;
            _andUpButt.SetActive(false);
            Debug.Log("work");
        }



    }
    public void IncreaseCrystals()
    {
        _crystal._number++;
    }
}
