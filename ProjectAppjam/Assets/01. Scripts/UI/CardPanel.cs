using UnityEngine;

public class CardPanel : MonoBehaviour
{
    [SerializeField] Transform cardParent;

    public void AddCard(LevelUpCard card)
    {
        card.transform.SetParent(cardParent);
    }

    public void Show()
    {
        Time.timeScale = 0;

        gameObject.SetActive(true);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Hide()
    {
        Time.timeScale = 1;

        gameObject.SetActive(false);

        foreach(Transform child in cardParent)
            Destroy(child);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
