using UnityEngine;

public class LocatorScript : MonoBehaviour
{
    public static LocatorScript Instance {get; private set;}

    public SceneController SceneManager {get; private set;}

    public PlayerDeck DeckManager {get; private set;}
    
    public UpgradeSystem UpgradeManager {get; private set;}
    public CardInformation CardManager {get; private set;}
    
    public StatsUpdater StatsManager {get; private set;}
    public Monster MonsterManager {get; private set;}

    public AudioManager AudioManaged {get; private set;}

   private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;

        GameObject SceneManage = GameObject.FindWithTag("GameController");
        SceneManager = SceneManage.GetComponent<SceneController>();

        GameObject DeckManage = GameObject.FindWithTag("GameController");
        DeckManager = DeckManage.GetComponent<PlayerDeck>();

        GameObject UpgradeManage = GameObject.FindWithTag("GameController");
        UpgradeManager = UpgradeManage.GetComponent<UpgradeSystem>();

        // GameObject CardManage = GameObject.FindWithTag("GameController");
        // CardManager = CardManage.GetComponent<CardInformation>();

        GameObject StatsManage = GameObject.FindWithTag("GameController");
        StatsManager = StatsManage.GetComponent<StatsUpdater>();

        GameObject MonsterManage = GameObject.FindWithTag("GameController");
        MonsterManager = MonsterManage.GetComponent<Monster>();

        GameObject AudioManage = GameObject.FindWithTag("AudioManager");
        AudioManaged = AudioManage.GetComponent<AudioManager>();
    }
}
