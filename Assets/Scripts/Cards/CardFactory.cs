using System.Collections.Generic;
using UnityEngine;
public class CardFactory {
    Dictionary<string, ICard> cardDatabase;
    static CardFactory instance;     
    private CardFactory()
    {
        cardDatabase = new Dictionary<string, ICard>();
        GenerateCards();
    }
    
    public static CardFactory Instance {
        get {
            if(instance == null)
                instance = new CardFactory();
            return instance;
        }
    }
    public ICard getCard(string cardName) {
        ICard card = cardDatabase[cardName];
        return card;
    }
    
    void GenerateCards() {
        //Sword Cards
        ICard swordAttack = new ICard("SwordAttack");
        swordAttack.addAction(()=>{ return new DamageAction(5); });
        cardDatabase.Add(swordAttack.Name, swordAttack);
    }
}