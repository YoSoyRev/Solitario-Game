using UnityEngine;
public class DrawPileManager : MonoBehaviour {
    public StackZone drawPile;
    public StackZone wastePile;
    public void DrawCard() {
        if (drawPile.cards.Count == 0) {
            for (int i = wastePile.cards.Count - 1; i >= 0; i--) {
                Card card = wastePile.cards[i];
                wastePile.RemoveCard(card);
                card.Flip(false);
                drawPile.AddCard(card);
            }
            return;
        }
        Card drawnCard = drawPile.GetTopCard();
        drawPile.RemoveCard(drawnCard);
        drawnCard.Flip(true);
        wastePile.AddCard(drawnCard);
    }
}