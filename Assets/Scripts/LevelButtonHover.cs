using UnityEngine;
using UnityEngine.EventSystems; 

public class HoverTooltip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject textbox;

    // when mouse enters area, makes textbox visible
    public void OnPointerEnter(PointerEventData eventData)
    {
        textbox.SetActive(true);
    }

    // when mouse leave area, makes textbox invisible 
    public void OnPointerExit(PointerEventData eventData)
    {
        textbox.SetActive(false);
    }
}
