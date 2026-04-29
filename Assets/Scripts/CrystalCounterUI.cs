using UnityEngine;
using TMPro;

public class CrystalCounterUI : MonoBehaviour
{
    public TMP_Text crystalText;
    public Crystal crystalData;

    void Start()
    {
        UpdateCrystalText();
    }

    void Update()
    {
        UpdateCrystalText();
    }

    void UpdateCrystalText()
    {
        crystalText.text = "Crystals: " + crystalData._number;
    }
}