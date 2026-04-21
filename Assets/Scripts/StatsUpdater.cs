using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class StatsUpdater : MonoBehaviour
{
    //ScriptableObjects
     [SerializeField] public CardInformation _androidInfo;
    [SerializeField] public CardInformation _cowboyInfo;
    [SerializeField] public CardInformation _empressInfo;

    //TextMeshPros
    [SerializeField] TextMeshProUGUI _cowHP;
    [SerializeField] TextMeshProUGUI _cowATK;
    [SerializeField] TextMeshProUGUI _empHP;
    [SerializeField] TextMeshProUGUI _empATK;
    [SerializeField] TextMeshProUGUI _andHP;
    [SerializeField] TextMeshProUGUI _andATK;

    // Update is called once per frame
    void Update()
    {
        UpdateStats();
    }
    public void UpdateStats()
    {
     _empATK.text = _empressInfo.damage.ToString();

    _empHP.text = _empressInfo.health.ToString();

    //Cowboy stats UI
    _cowATK.text = _cowboyInfo.damage.ToString();

    _cowHP.text = _cowboyInfo.health.ToString();

    //Android stats UI
    _andATK.text = _androidInfo.damage.ToString();

    _andHP.text = _androidInfo.health.ToString();

    }
}
