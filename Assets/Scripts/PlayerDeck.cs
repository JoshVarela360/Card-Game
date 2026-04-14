using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class PlayerDeck : MonoBehaviour
{


    //Sript References
    [SerializeField] Monster _monster;
    //Scriptables
    [SerializeField] private CardInformation _androidInfo;
    [SerializeField] private CardInformation _cowboyInfo;
    [SerializeField] private CardInformation _empressInfo;


    //UI

    [SerializeField] TextMeshProUGUI _popUptext;
    [SerializeField] GameObject _attackMenu;
    [SerializeField] TextMeshProUGUI _totalHealthtext;


    //Normal Variables

    [SerializeField] string _name;
    [SerializeField] int _playerHealth;
    [SerializeField] string _playerName;
    [SerializeField] int _playerDamage;

    [SerializeField] bool _isPlayerTurn = true;
    [SerializeField] int _totalHealth;

    //List of alive cards
    public List<string> PlayerCards = new List<string> { "android", "cowboy", "empress" };


    void Start()
    {
        _attackMenu.SetActive(false);
        _androidInfo.health = 20;
        _cowboyInfo.health = 20;
        _empressInfo.health = 30;
        _totalHealth = _androidInfo.health + _cowboyInfo.health + _empressInfo.health;
        _totalHealthtext.text = "Player Health: " + _totalHealth;
    }
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
        switch (_name)
        {
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

        switch (_name)
        {
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

        switch (_name)
        {
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

        if (_playerHealth > 0)
        {
            GetStats();
        }


    }
    void GetStats()
    {
        if (_name == "Android" || _name == "Cowboy" || _name == "Empress")
        {
            _attackMenu.SetActive(true);
            _popUptext.text = "Name:" + _playerName;
            _popUptext.text += "\nHealth:" + _playerHealth;
            _popUptext.text += "\nDamage:" + _playerDamage;

        }
    }

    //Attack and Take Damage
    public void Attack()
    {
        if (_isPlayerTurn)
        {
            _monster.MonsterTakeDamage(_playerDamage);
            _isPlayerTurn = false;
        }
    }

    public void PlayerTakeDamage(int damage)
    {
        //randomly select from alive player card list 
        int randomIndex = Random.Range(0, PlayerCards.Count);
        string randomCard = PlayerCards[randomIndex];
        Debug.Log(randomCard);

        if (randomCard == "android")
        {
            _androidInfo.health -= damage;
            _playerHealth = _androidInfo.health;

        }
        if (randomCard == "cowboy")
        {
            _cowboyInfo.health -= damage;
            _playerHealth = _cowboyInfo.health;

        }
        if (randomCard == "empress")
        {
            _empressInfo.health -= damage;
            _playerHealth = _empressInfo.health;
        }


        _isPlayerTurn = true;

        if (_playerHealth <= 0)
        {
            Debug.Log("Disable the character: " + randomCard);
            PlayerCards.Remove(randomCard);
        }

        Debug.Log(_playerHealth);
        _totalHealth -= damage;
        _totalHealthtext.text = "Player Health: " + _totalHealth;

    }






}





