using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
public class Monster: MonoBehaviour
{
    //References
[SerializeField]   PlayerDeck _player;
    [SerializeField] Slider _healthBar;
    [SerializeField] int _health;    
    [SerializeField] int _maxHealth = 100;    
    [SerializeField] bool _MonsterisAttacked;
    [SerializeField] bool _isMonsterTurn;
    [SerializeField] float _attackTimer = 6;

        public InputActionReference _attackAction;

    void Start()
    {
        _health = _maxHealth;
        _healthBar.maxValue = _maxHealth;
        _healthBar.value = _health;
    }

    // Update is called once per frame
    void Update()
    {
        MonsterAttack();
    }

//Attacking and Damage
public void MonsterAttack()
    {
        if(_isMonsterTurn)
        {
            _attackTimer -= Time.deltaTime;
            if(_attackTimer <= 0)
            {
                 _player.PlayerTakeDamage(10);
            Debug.Log("Monster Attacks!!");
            _isMonsterTurn = false;
            _attackTimer = 6;
            }
            
           
        }
    }
    

    public void MonsterTakeDamage(int damage)
    {
        _health -= damage;
        _healthBar.value = _health;
        _isMonsterTurn = true;

        if(_health <=0)
        {
            Debug.Log("You win!!");
        }
    }
}
