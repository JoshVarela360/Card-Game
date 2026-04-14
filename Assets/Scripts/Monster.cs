using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;
public class Monster : MonoBehaviour
{
    //References
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

            if (_attackTimer <= 1)
            {
                _player.PlayerTakeDamage(10);
                _MonsterStatustext.text = "Attacking!!!";
                Debug.Log("Monster Attacks!!");
                _isMonsterTurn = false;
                _attackTimer = 2;
                _MonsterStatustext.text = "";
            }

        }
    }


    public void MonsterTakeDamage(int damage)
    {
        _health -= damage;
        _healthBar.value = _health;
        _Healthtext.text = "Enemy Health: " + _health;
        _isMonsterTurn = true;

        if (_health <= 0)
        {
            Debug.Log("You win!!");
        }
    }
}
