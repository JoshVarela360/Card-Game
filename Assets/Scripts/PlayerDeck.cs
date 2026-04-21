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

    //Cards
    [SerializeField] GameObject _deck;
    public List<GameObject> PlayerCardObjects = new List<GameObject> { };

    //Card Positions
    [SerializeField] private float _moveupdistance;
    [SerializeField] private float _deckdownlocation;
    private float _deckuplocation;



    //UI

    [SerializeField] GameObject _attackMenu;
    [SerializeField] TextMeshProUGUI _totalHealthtext;
    [SerializeField] TextMeshProUGUI _cowHP;
    [SerializeField] TextMeshProUGUI _cowATK;
    [SerializeField] TextMeshProUGUI _empHP;
    [SerializeField] TextMeshProUGUI _empATK;
    [SerializeField] TextMeshProUGUI _andHP;
    [SerializeField] TextMeshProUGUI _andATK;




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
        _totalHealthtext.text = "Team Health: " + _totalHealth;
        _deckuplocation = _deck.GetComponent<RectTransform>().anchoredPosition.y + _moveupdistance;
        _deckdownlocation = _deckuplocation - _moveupdistance;
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
        

        switch (_name)
        {
            case "Android":

                break;
            case "Cowboy":

                break;
            case "Empress":

                break;
        }
        
//Empress stats UI
    _empATK.text = _empressInfo.damage.ToString();

    _empHP.text = _empressInfo.health.ToString();

    //Cowboy stats UI
    _cowATK.text = _cowboyInfo.damage.ToString();

    _cowHP.text = _cowboyInfo.health.ToString();

    //Android stats UI
    _andATK.text = _androidInfo.damage.ToString();

    _andHP.text = _androidInfo.health.ToString();

    //Attack Pop up button
     AttackPopup();
    }
    void AttackPopup()
    {
        if (_name == "Android" || _name == "Cowboy" || _name == "Empress")
        {
            _attackMenu.SetActive(true);
            MoveCardUp();
           
        }
    }

    //Attack and Take Damage
    public void Attack()
    {
        if (_isPlayerTurn)
        {
            
            _monster.MonsterTakeDamage(_playerDamage);
            _isPlayerTurn = false;
            MoveCardDown();
            //unslect player card
            _name = null;
            _attackMenu.SetActive(false);
            MoveDeckDown();
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
        MoveDeckUp();

        if (_playerHealth <= 0)
        {
            Debug.Log("Disable the character: " + randomCard);
            PlayerCards.Remove(randomCard);
        }

        Debug.Log(_playerHealth);
        _totalHealth -= damage;
        _totalHealthtext.text = "Team Health: " + _totalHealth;

    }

    void MoveCardUp()
    {
        foreach (GameObject card in PlayerCardObjects)
        {
            if (card.name.Contains(_name))
            {
                Vector2 tempPos = card.GetComponent<RectTransform>().anchoredPosition;
                tempPos.y = _deckuplocation + _moveupdistance;
                card.GetComponent<RectTransform>().anchoredPosition = tempPos;

            }
            else
            {
                Vector2 tempPos = card.GetComponent<RectTransform>().anchoredPosition;
                tempPos.y = _deckuplocation;
                card.GetComponent<RectTransform>().anchoredPosition = tempPos;
            }

        }
    }
    void MoveCardDown()
    {
        foreach (GameObject card in PlayerCardObjects)
        {
            if (card.name.Contains(_name))
            {
                Vector2 tempPos = card.GetComponent<RectTransform>().anchoredPosition;
                tempPos.y = _deckuplocation;
                card.GetComponent<RectTransform>().anchoredPosition = tempPos;

            }

        }
    }

    void MoveDeckUp()
    {
        Vector2 tempPos = _deck.GetComponent<RectTransform>().anchoredPosition;
        tempPos.y = _deckuplocation;
        _deck.GetComponent<RectTransform>().anchoredPosition = tempPos;

    }



    void MoveDeckDown()
    {
        Vector2 tempPos = _deck.GetComponent<RectTransform>().anchoredPosition;
        tempPos.y = _deckdownlocation;
        _deck.GetComponent<RectTransform>().anchoredPosition = tempPos;

    }





}





