using System.Collections.Generic;
using UnityEngine;

public class StackZone : MonoBehaviour {
    public List<Card> cards = new List<Card>();
    public bool isFoundation = false;
    public bool isTableau = false;
    public void AddCard(Card card) {
        cards.Add(card);
        card.transform.SetParent(transform, false);
        UpdateCardPositions();
    }
    public Card GetTopCard() {
        if (cards.Count == 0) return null;
        return cards[cards.Count - 1];
    }
    public bool CanPlaceCard(Card card) {
        if (cards.Count == 0) {
            if (isTableau) return card.rank == Card.Rank.King;
            else if (isFoundation) return card.rank == Card.Rank.Ace;
        } else {
            Card top = GetTopCard();
            if (isFoundation)
                return card.suit == top.suit && (int)card.rank == (int)top.rank + 1;
            else if (isTableau)
                return card.IsRed() != top.IsRed() && (int)card.rank == (int)top.rank - 1;
        }
        return false;
    }
    public void RemoveCard(Card card) {
        cards.Remove(card);
        UpdateCardPositions();
    }
    void UpdateCardPositions() {
        float offsetY = 30f;
        for (int i = 0; i < cards.Count; i++) {
            cards[i].transform.localPosition = new Vector3(0, -offsetY * i, 0);
        }
    }
}