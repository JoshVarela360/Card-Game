using UnityEngine;

public class UpgradeSystem : MonoBehaviour
{
    
    [SerializeField] GameObject _upgradePopUp;
    //Upgrade buttons
    [SerializeField] GameObject _cowUpButt;
    [SerializeField] GameObject  _andUpButt;
    [SerializeField] GameObject  _empUpButt;

    
    //ScriptableObjects
    [SerializeField] public CardInformation _androidInfo;
    [SerializeField] public CardInformation _cowboyInfo;
    [SerializeField] public CardInformation _empressInfo;


    //variables - SWITCH TO A SCRIPTABLE OBJECT
    [SerializeField] public int _upgradeCrystals;


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
        if(_upgradeCrystals >= 1)
        {
            _cowboyInfo.damage += 10;
        _cowboyInfo.health += 10;
        --_upgradeCrystals;
        Debug.Log("work");
        _cowUpButt.SetActive(false);
        }
       
       
  
    } 
    public void UpgradeEmpressStats()
    {
        if(_upgradeCrystals >= 1)
        {
        _empressInfo.damage += 10;
        _empressInfo.health += 10;
        --_upgradeCrystals;
        _empUpButt.SetActive(false);
        Debug.Log("work");
        }
  
    } 
    public void UpgradeAndroidStats()
    {
        if(_upgradeCrystals >= 1)
        {
         _androidInfo.damage += 10;
        _androidInfo.health += 10;
        --_upgradeCrystals;
        _andUpButt.SetActive(false);
        Debug.Log("work");
        }
       
    
  
    }
     public void IncreaseCrystals()
    {
        _upgradeCrystals++;
    }
}
