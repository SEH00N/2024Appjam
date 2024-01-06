using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class XPUIPanel : MonoBehaviour
{
    [SerializeField] TMP_Text xpText;
    [SerializeField] Slider slider;

	public void SetXP(float current, float total)
    {
        xpText.text = $"{current} / {total}";
        slider.value = current/total;
    }
}
