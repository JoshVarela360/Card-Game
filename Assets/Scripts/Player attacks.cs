using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Playerattacks : MonoBehaviour
{
    
//Scriptables
[SerializeField] private CardInformation _androidInfo;
[SerializeField] private CardInformation _cowboyInfo;
[SerializeField] private CardInformation _empressInfo;


//UI

[SerializeField] TextMeshProUGUI _popUptext;
[SerializeField] GameObject _attackMenu;


//Normal Variables

[SerializeField] string _name;
[SerializeField] int _playerHealth;
[SerializeField] string _playerName;
[SerializeField] int _playerDamage;

   
    void Update()
    {
        SelectedCardStats();
        
    
    }

    //Selection of Cards
    public void CowboySelected()
    {
        _name = "Cowboy";
    }
     public void EmpressSelected()
    {
        _name = "Empress";
    } 
    public void AndroidSelected()
    {
        _name = "Android";
    }

    
        //Show stats of selected cards
    void SelectedCardStats()
    {
         switch(_name){
        case "Android":
            _playerHealth = _androidInfo.health;
            break;
        case "Cowboy":
            _playerHealth = _cowboyInfo.health;
            break;
        case "Empress":
            _playerHealth = _empressInfo.health;
            break;
         }

          switch(_name){
        case "Android":
            _playerDamage = _androidInfo.damage;
            break;
        case "Cowboy":
            _playerDamage = _cowboyInfo.damage;
            break;
        case "Empress":
            _playerDamage = _empressInfo.damage;
            break;
         }
         
         switch(_name){
        case "Android":
            _playerName = _androidInfo.name;
            break;
        case "Cowboy":
            _playerName = _cowboyInfo.name;
            break;
        case "Empress":
            _playerName = _empressInfo.name;
            break;
         }

            GetStats();
    }
    void GetStats(){
        if ( _name == "Android" || _name == "Cowboy" || _name == "Empress" )
        {
            _attackMenu.SetActive(true);
            _popUptext.text = "Name:"+ _playerName;
            _popUptext.text += "\nHealth:"+ _playerHealth;
            _popUptext.text += "\nDamage:"+ _playerDamage;

        }
          
        }
    
    
}

   
    


