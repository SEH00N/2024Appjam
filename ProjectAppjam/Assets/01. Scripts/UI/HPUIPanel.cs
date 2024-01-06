using UnityEngine;
using UnityEngine.UI;

public class HPUIPanel : MonoBehaviour
{
    [SerializeField] Image image;
	
    public void SetHP(float current, float total)
    {
        image.fillAmount = current/total;
    }
}
