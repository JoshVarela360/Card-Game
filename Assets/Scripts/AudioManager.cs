using UnityEngine;

public class AudioManager : MonoBehaviour
{


    [SerializeField] AudioSource _monsterattackSFX;
    [SerializeField] AudioSource _playerattackSFX;
    [SerializeField] AudioSource _buttonPressed;




void Start()
    {
       
        Monster.TriggerMonsterAttackSFX += MonsterAttackAudio;
        PlayerDeck.TriggerPlayerAttackSFX += PlayerAttackAudio;
        Buttons.TriggerButtonSFX += ButtonClickSFX;

        _playerattackSFX = GameObject.FindGameObjectWithTag("PlayerAttackSFX").GetComponent<AudioSource>();
      
            _monsterattackSFX = GameObject.FindGameObjectWithTag("MonsterAttackSFX").GetComponent<AudioSource>();
        
            _buttonPressed = GameObject.FindGameObjectWithTag("ButtonPressedSFX").GetComponent<AudioSource>(); 
  
    }
    // Update is called once per frame
    void Update()
    {
      
          
    }
    
    public void MonsterAttackAudio()
    {
        _monsterattackSFX.Play();
    }
    public void PlayerAttackAudio()
    {
        _playerattackSFX.Play();
    }
    public void ButtonClickSFX()
    {
        _buttonPressed.Play();
    }
}
