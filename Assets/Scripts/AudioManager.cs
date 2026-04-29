using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [SerializeField] private AudioSource[] audioSources;

    [SerializeField] AudioSource _monsterattackSFX;
    [SerializeField] AudioSource _playerattackSFX;
    [SerializeField] AudioSource _buttonPressed;




void Start()
    {
        if(audioSources != null)
        {
        audioSources = GetComponents<AudioSource>();
        _playerattackSFX = audioSources[0];
        _monsterattackSFX = audioSources[1];
        }
        else
        {
          audioSources = GetComponents<AudioSource>();
        _playerattackSFX = audioSources[0];
        _monsterattackSFX = audioSources[1];
        }
       

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
