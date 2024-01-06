using System.Collections.Generic;
using UnityEngine;

public class LevelUpCardSpawner : MonoBehaviour
{
    [SerializeField] CardPanel cardPanel;
    [SerializeField] List<LevelUpCard> cards;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
            ShowCard();
    }

    public void ShowCard()
    {
        for(int i = 0; i < 3; ++i)
            cardPanel.AddCard(SpawnCard());

        cardPanel.Show();
    }

    public void RemoveCard(int index)
    {
        cards.RemoveAt(index);
    }

    private LevelUpCard SpawnCard()
    {
        int index = Random.Range(0, cards.Count);
        LevelUpCard card = Instantiate(cards[index]);
        card.index = index;
        card.OnSelectedEvent.AddListener((i) => {
            RemoveCard(card.index);
            cardPanel.Hide();
        });

        return card;
    }
}
