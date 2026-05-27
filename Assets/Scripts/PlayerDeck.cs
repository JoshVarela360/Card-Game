using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using System.Collections;
using Unity.VisualScripting;

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


    [SerializeField] Shader _deadVFX;

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

    //Store the card that last attacked
    private string attackedCard;

    // Sprite Renderers
    public Image _androidImage;
    public Image _cowboyImage;
    public Image _empressImage;

    void Awake()
    {
    }


    void Start()
    {
        ResetCardStats();
    }

    void Update()
    {
        SelectedCardStats();

        UpdateGameStats();

    }

    //Reset the card stats to the card datas draged in the inspector of this level
    public void ResetCardStats()
    {
        //Set Card Info
        _androidInfo.health = _androidStartStats.health;
        _cowboyInfo.health = _cowboyStartStats.health;
        _empressInfo.health = _empressStartStats.health;
        _androidInfo.damage = _androidStartStats.damage;
        _cowboyInfo.damage = _cowboyStartStats.damage;
        _empressInfo.damage = _empressStartStats.damage;

        //Set Total Health
        _totalHealth = _androidInfo.health + _cowboyInfo.health + _empressInfo.health;

        //Reset Screen
        _attackMenu.SetActive(false);
        //Set Card display
        UpdateGameStats();
        //Set HealthBar display
        _totalHealthtext.text = "Team Health: " + _totalHealth;
        _healthBar.maxValue = _totalHealth;
        _healthBar.value = _totalHealth;
        //Set Deck Location
        _deckuplocation = _deck.GetComponent<RectTransform>().anchoredPosition.y + _moveupdistance;
        _deckdownlocation = _deckuplocation - _moveupdistance;
        isGameOver = false;

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

        if (_totalHealth <= 0)
        {
            PlayerLose();
        }

        // Blacks out image if card is dead
        if (_empressInfo.health <= 0)
        {
            _empressImage.color = Color.black;
        }

        if (_cowboyInfo.health <= 0)
        {
            _cowboyImage.color = Color.black;
        }

        if (_androidInfo.health <= 0)
        {
            _androidImage.color = Color.black;
        }
    }
    void AttackPopup()
    {
        if (_name == "Android" || _name == "Cowboy" || _name == "Empress")
        {
            _attackMenu.SetActive(true);
            //MoveCardUp();

        }
    }

    //Attack and Take Damage
    public void Attack()
    {
        if (_isPlayerTurn)
        {
            //store tha card that attacked as next target
            attackedCard = _name;

            TriggerPlayerAttackSFX?.Invoke();
            _monster.MonsterTakeDamage(_playerDamage);
            _isPlayerTurn = false;
            //MoveCardDown();
            //unslect player card
            _name = null;
            _attackMenu.SetActive(false);
            //MoveDeckDown();
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
        Debug.Log(attackedCard);

        if (attackedCard == "Android")
        {
            StartCoroutine(PlayerHitEffectCoroutine(_androidImage));

            if (_androidInfo.health > damage)
            {
                _androidInfo.health -= damage;
                _playerHealth = _androidInfo.health;
            }
            else
            {
                _androidInfo.health = 0;
                //LocatorScript.Instance.UpgradeManager._androidEffect.GetComponent<SpriteRenderer>().sharedMaterials[0].shader = _deadVFX;
                _playerHealth = _androidInfo.health;

                //Disable 
                Button android = PlayerCardObjects[0].GetComponent<Button>();
                android.enabled = false;
            }

        }
        if (attackedCard == "Cowboy")
        {
            StartCoroutine(PlayerHitEffectCoroutine(_cowboyImage));

            if (_cowboyInfo.health > damage)
            {
                _cowboyInfo.health -= damage;
                _playerHealth = _cowboyInfo.health;
            }
            else
            {
                _cowboyInfo.health = 0;
                //LocatorScript.Instance.UpgradeManager._cowboyEffect.GetComponent<SpriteRenderer>().sharedMaterials[0].shader = _deadVFX;
                _playerHealth = _cowboyInfo.health;
                Button cowboy = PlayerCardObjects[1].GetComponent<Button>();
                cowboy.enabled = false;
            }

        }
        if (attackedCard == "Empress")
        {
            StartCoroutine(PlayerHitEffectCoroutine(_empressImage));
            
            if (_empressInfo.health >= damage)
            {
                _empressInfo.health -= damage;
                _playerHealth = _empressInfo.health;
            }
            else
            {
                _empressInfo.health = 0;
                //LocatorScript.Instance.UpgradeManager._empressEffect.GetComponent<SpriteRenderer>().sharedMaterials[0].shader = _deadVFX;
                _playerHealth = _empressInfo.health;
                Button empress = PlayerCardObjects[2].GetComponent<Button>();
                empress.enabled = false;

                _empressImage.color = Color.black;
            }
        }

        //disable the card from future selection if dead
        if (_playerHealth <= 0)
        {

            //PlayerCardObjects.Find(card => card.name.Contains(attackedCard)).GetComponent<Image>().color = Color.grey;
            Debug.Log("Disable the character: " + attackedCard);
            PlayerCards.Remove(attackedCard.ToLower());
        }

        //Update total health text
        /*_totalHealth -= damage;*/
        RecalculateTotalHealth();

        if (_totalHealth < 0)
        {
            _totalHealth = 0;

            //PlayerLose();
        }
        _totalHealthtext.text = "Team Health: " + _totalHealth;
        //Total Health UI
        _healthBar.value = _totalHealth;

        //Update player health text
        UpdateGameStats();

        //proceed to player turn
        attackedCard = null;
        _isPlayerTurn = true;
        //MoveDeckUp();

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
                //card.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);

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
                //scard.transform.localScale = new Vector3(1f, 1f, 1f);

            }

        }
    }
    /*
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
    */

    void PlayerLose()
    {
        isGameOver = true;

        //Debug.Log(isGameOver);
    }

    IEnumerator PlayerHitEffectCoroutine(Image image)
    {
        Debug.Log("coroutine");

        image.color = Color.red;
        yield return new WaitForSeconds(0.15f);
        image.color = Color.white;
    }

}





