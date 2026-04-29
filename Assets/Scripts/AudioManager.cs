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
