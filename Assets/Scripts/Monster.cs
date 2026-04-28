using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;
public class Monster : MonoBehaviour
{
    //events
    public delegate void MonsterDefeated();
    public static event MonsterDefeated AddCrystal;
    public delegate void MonsterAttacked();
    public static event MonsterAttacked TriggerMonsterAttackSFX;
    //References
    [SerializeField] GameObject _mapButton;
    [SerializeField] PlayerDeck _player;
    [SerializeField] Slider _healthBar;
    [SerializeField] TextMeshProUGUI _Healthtext;

    [SerializeField] int _health;
    [SerializeField] int _maxHealth = 100;
    [SerializeField] bool _MonsterisAttacked;
    [SerializeField] bool _isMonsterTurn;
    [SerializeField] TextMeshProUGUI _MonsterStatustext;
    [SerializeField] float _attackTimer = 2;

    public InputActionReference _attackAction;

    void Start()
    {
        _MonsterStatustext.text = "Select a Card to Attack!";
        _health = _maxHealth;
        _healthBar.maxValue = _maxHealth;
        _healthBar.value = _health;
        _Healthtext.text = "Enemy Health: " + _health;
        _MonsterStatustext.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        MonsterAttack();
    }

    //Attacking and Damage
    public void MonsterAttack()
    {
        if (_isMonsterTurn)
        {
            _attackTimer -= Time.deltaTime;
            _MonsterStatustext.text = "Monster Deciding...";

            if (_attackTimer <= 0.5)
            {
                TriggerMonsterAttackSFX?.Invoke();
                _player.PlayerTakeDamage(10);
                _MonsterStatustext.text = "Attacking!!!";
                Debug.Log("Monster Attacks!!");
                _isMonsterTurn = false;
                _attackTimer = 1;
                _MonsterStatustext.text = "";
                if (_player._totalHealth <= 0)
                {
                    _MonsterStatustext.text = "You Lose!!!";
                    _mapButton.SetActive(true);
                    _isMonsterTurn = false;
                }
            }

        }
    }


    public void MonsterTakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            _health = 0;
            _healthBar.value = _health;
            _Healthtext.text = "Enemy Health: " + _health;
            _MonsterStatustext.text = "You Win!!!";
            AddCrystal?.Invoke();
            _mapButton.SetActive(true);
            return;
        }
        _healthBar.value = _health;
        _Healthtext.text = "Enemy Health: " + _health;
        _isMonsterTurn = true;


    }
}
