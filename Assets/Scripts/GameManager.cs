using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public DeckManager deckManager;
    public List<StackZone> tableauColumns;
    public StackZone drawPile;
    public StackZone wastePile;
    private List<Card> fullDeck;
    void Start() {
        fullDeck = deckManager.GetShuffledDeck();
        DealInitialCards();
    }
    void DealInitialCards() {
        int deckIndex = 0;
        for (int col = 0; col < tableauColumns.Count; col++) {
            for (int row = 0; row <= col; row++) {
                Card card = fullDeck[deckIndex];
                tableauColumns[col].AddCard(card);
                if (row == col) card.Flip(true);
                deckIndex++;
            }
        }
        for (int i = deckIndex; i < fullDeck.Count; i++) {
            drawPile.AddCard(fullDeck[i]);
        }
    }
}