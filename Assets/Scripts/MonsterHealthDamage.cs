using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
public class MonsterHealthDamage : MonoBehaviour
{
    
    [SerializeField] Slider _healthBar;
    [SerializeField] int _health;    
    [SerializeField] int _maxHealth = 100;    
    [SerializeField] bool _MonsterisAttacked;
    [SerializeField] bool _isMonsterTurn;

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
