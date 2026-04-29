using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class PlayerDeck : MonoBehaviour
{

    //events
    public delegate void PlayerAttacks();
    public static event PlayerAttacks TriggerPlayerAttackSFX;

    //Sript References
    [SerializeField] Monster _monster;
    //Scriptables
    [SerializeField] public CardInformation _androidInfo;
    [SerializeField] public CardInformation _cowboyInfo;
    [SerializeField] public CardInformation _empressInfo;

    //Card starting Stats of each card in this level
    [SerializeField] public CardInformation _androidStartStats;
    [SerializeField] public CardInformation _cowboyStartStats;
    [SerializeField] public CardInformation _empressStartStats;

    //Cards
    [SerializeField] GameObject _deck;
    public List<GameObject> PlayerCardObjects = new List<GameObject> { };


    //Card Positions
    [SerializeField] private float _moveupdistance;
    [SerializeField] private float _deckdownlocation;
    private float _deckuplocation;

    //Card Quips
    [SerializeField] DialogueUI _dialogueUI;

    //UI

    [SerializeField] GameObject _attackMenu;
    [SerializeField] TextMeshProUGUI _totalHealthtext;
    [SerializeField] Slider _healthBar;
    [SerializeField] TextMeshProUGUI _cowHP;
    [SerializeField] TextMeshProUGUI _cowATK;
    [SerializeField] TextMeshProUGUI _empHP;
    [SerializeField] TextMeshProUGUI _empATK;
    [SerializeField] TextMeshProUGUI _andHP;
    [SerializeField] TextMeshProUGUI _andATK;




    //Normal Variables

    [SerializeField] public string _name;
    [SerializeField] int _playerHealth;
    [SerializeField] string _playerName;
    [SerializeField] int _playerDamage;

    [SerializeField] bool _isPlayerTurn = true;
    [SerializeField] public int _totalHealth;

    public static bool isGameOver = false;

    //List of alive cards
    public List<string> PlayerCards = new List<string> { "android", "cowboy", "empress" };

    void Awake()
    {
        ResetCardStats();

        isGameOver = false;
    }


    void Start()
    {
        _attackMenu.SetActive(false);
        //StartingCharacterStats();
        _totalHealth = _androidInfo.health + _cowboyInfo.health + _empressInfo.health;
        _totalHealthtext.text = "Team Health: " + _totalHealth;
        _healthBar.maxValue = _totalHealth;
        _healthBar.value = _totalHealth;
        _deckuplocation = _deck.GetComponent<RectTransform>().anchoredPosition.y + _moveupdistance;
        _deckdownlocation = _deckuplocation - _moveupdistance;
        UpdateGameStats();

        Debug.Log("Android: " + _androidInfo.health);
        Debug.Log("Cowboy: " + _cowboyInfo.health);
        Debug.Log("Empress: " + _empressInfo.health);
    }
    
    void Update()
    {
        SelectedCardStats();

        UpdateGameStats();
    }

    //Reset the card stats to the card datas draged in the inspector of this level
    void ResetCardStats()
    {

        _androidInfo.health = _androidStartStats.health;
        _cowboyInfo.health = _cowboyStartStats.health;
        _empressInfo.health = _empressStartStats.health;
        _androidInfo.damage = _androidStartStats.damage;
        _cowboyInfo.damage = _cowboyStartStats.damage;
        _empressInfo.damage = _empressStartStats.damage;



    }
    /*void StartingCharacterStats()
    {
        if (_androidInfo && _cowboyInfo && _empressInfo == null)
        {
            _androidInfo.health = 10;
            _cowboyInfo.health = 20;
            _empressInfo.health = 30;
            _androidInfo.damage = 30;
            _cowboyInfo.damage = 20;
            _empressInfo.damage = 10;
        }

    }
    */


    //Selection of Cards
    public void CowboySelected()
    {
        if (!PlayerCards.Contains("cowboy")) return;
        _name = "Cowboy";
        _dialogueUI.ShowDialogue(_cowboyInfo.quip);

    }
    public void EmpressSelected()
    {
        if (!PlayerCards.Contains("empress")) return;
        _name = "Empress";
        _dialogueUI.ShowDialogue(_empressInfo.quip);

    }
    public void AndroidSelected()
    {
        if (!PlayerCards.Contains("android")) return;
        _name = "Android";
        _dialogueUI.ShowDialogue(_androidInfo.quip);

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

        if (_playerHealth > 0) //disable dead cards from attacking
        {
            UpdateGameStats();

            //Attack Pop up button
            AttackPopup();

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

        //Total Health UI
        _healthBar.value = _totalHealth;


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
            TriggerPlayerAttackSFX?.Invoke();
            _monster.MonsterTakeDamage(_playerDamage);
            _isPlayerTurn = false;
            MoveCardDown();
            //unslect player card
            _name = null;
            _attackMenu.SetActive(false);
            MoveDeckDown();
        }
    }

    bool IsCardAlive(string cardName)
    {
        return PlayerCards.Contains(cardName.ToLower());
    }

    //Card Quip
    void ShowCardQuip()
    {   
        if (_name == null) return;

        if (!IsCardAlive(_name))
        return;

        switch (_name)
        {
            case "Cowboy":
                _dialogueUI.ShowDialogue(_cowboyInfo.quip);
                break;

            case "Empress":
                _dialogueUI.ShowDialogue(_empressInfo.quip);
                break;

            case "Android":
                _dialogueUI.ShowDialogue(_androidInfo.quip);
                break;
        }
    }


    public void PlayerTakeDamage(int damage)
    {

        _dialogueUI.HideDialogue();
        //randomly select from alive player card list 
        int randomIndex = Random.Range(0, PlayerCards.Count);
        string randomCard = PlayerCards[randomIndex];
        Debug.Log(randomCard);

        if (randomCard == "android")
        {
            if (_androidInfo.health > damage)
            {
                _androidInfo.health -= damage;
                _playerHealth = _androidInfo.health;

            }
            else
            {
                _androidInfo.health = 0;
                _playerHealth = _androidInfo.health;
            }

        }
        if (randomCard == "cowboy")
        {
            if (_cowboyInfo.health > damage)
            {
                _cowboyInfo.health -= damage;
                _playerHealth = _cowboyInfo.health;

            }
            else
            {
                _cowboyInfo.health = 0;
                _playerHealth = _cowboyInfo.health;
            }

        }
        if (randomCard == "empress")
        {
            if (_empressInfo.health >= damage)
            {
                _empressInfo.health -= damage;
                _playerHealth = _empressInfo.health;
            }
            else
            {
                _empressInfo.health = 0;
                _playerHealth = _empressInfo.health;
            }
        }

        //disable the card from future selection if dead
        if (_playerHealth <= 0)
        {
            Debug.Log("Disable the character: " + randomCard);
            PlayerCards.Remove(randomCard);

            PlayerLose();
        }
        //Update total health text
        /*_totalHealth -= damage;*/
        RecalculateTotalHealth();
        if (_totalHealth < 0)
        {
            _totalHealth = 0;
        }
        _totalHealthtext.text = "Team Health: " + _totalHealth;
        //Total Health UI
        _healthBar.value = _totalHealth;

        //Update player health text
        UpdateGameStats();

        //proceed to player turn
        _isPlayerTurn = true;
        MoveDeckUp();

    }

    void RecalculateTotalHealth()
    {
        _totalHealth =
            _androidInfo.health +
            _cowboyInfo.health +
            _empressInfo.health;

        _totalHealthtext.text = "Team Health: " + _totalHealth;
        _healthBar.value = _totalHealth;
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

    void PlayerLose()
    {
        isGameOver = true;

        Debug.Log(isGameOver);
    }



}





