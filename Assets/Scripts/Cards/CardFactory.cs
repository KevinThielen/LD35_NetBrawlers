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
        //gray cards 
        {
            ICard card = new ICard("Dash Attack", 1, EForm.RED, EForm.GRAY);
            int damage = 3;
            
            card.addAction(()=>{ return new Shapeshift(EForm.GRAY); });
            card.addAction(()=>{ return new PlayAnimation("run"); });
            card.addAction(()=>{ return new Run(5, 2);           });
            card.addAction(()=>{ return new Wait(0.5f); });
            card.addAction(()=>{ return new Run(4, 2);           });
            card.addAction(()=>{ return new Wait(0.5f); });
            card.addAction(()=>{ return new Run(3, 2);           });
            card.addAction(()=>{ return new Wait(0.5f); });
            card.addAction(()=>{ return new Run(2, 2);           });
            card.addAction(()=>{ return new Wait(0.5f); });
            card.addAction(()=>{ return new Run(1, 2);           });
            card.addAction(()=>{ return new Wait(0.5f); });
            card.addAction(()=>{ return new PlayAudio("punch"); });

            card.addAction(()=>{ return new DamageAction(damage);});
            card.addAction(()=>{ return new Wait(0.5f); });
            card.Description = "- Deal "+damage+" damage\n - Replace 1 Random Card from Hand\n";
            
            cardDatabase.Add(card.Name, card);  
        }
        {
             ICard card = new ICard("BOOM", 5, EForm.YELLOW, EForm.GRAY);
            card.addAction(()=>{ return new Shapeshift(EForm.GRAY); });
            card.addAction(()=>{ return new PlayAnimation("run"); });
            card.addAction(()=>{ return new Run(5, 2);           });
            card.addAction(()=>{ return new Wait(0.5f); });
            card.addAction(()=>{ return new Run(4, 2);           });
            card.addAction(()=>{ return new Wait(0.5f); });
            card.addAction(()=>{ return new Run(3, 2);           });
            card.addAction(()=>{ return new Wait(0.5f); });
            card.addAction(()=>{ return new Run(2, 2);           });
            card.addAction(()=>{ return new Wait(0.5f); });
            card.addAction(()=>{ return new Run(1, 2);           });
            card.addAction(()=>{ return new Wait(0.5f); });
            card.addAction(()=>{ return new PlayAnimation("boom_0"); });
            card.addAction(()=>{ return new Wait(0.5f); });
            card.addAction(()=>{ return new PlayAnimation("boom_1"); });
            card.addAction(()=>{ return new Wait(0.5f); });
            card.addAction(()=>{ return new PlayAudio("blast"); });
            card.addAction(()=>{ return new PlayAnimation("boom_2"); });
            card.addAction(()=>{ return new Wait(0.5f); });
            card.addAction(()=>{ return new DamageAction(3);});
            card.addAction(()=>{ return new Wait(0.5f); });
            int damage = 12;
              card.Description = "- Deal "+damage+" damage\n - Replace 1 Random Card from Hand\n";
              
            cardDatabase.Add(card.Name, card);  
        }
         {
            ICard card = new ICard("Blast", 3, EForm.GREEN, EForm.GRAY);
            card.addAction(()=>{ return new Shapeshift(EForm.GRAY); });
            card.addAction(()=>{ return new PlayAnimation("run"); });
            card.addAction(()=>{ return new Run(5, 2);           });
            card.addAction(()=>{ return new Run(5, 10);           });
            card.addAction(()=>{ return new Wait(0.5f); });
            card.addAction(()=>{ return new Run(4, 2);           });
            card.addAction(()=>{ return new Wait(0.5f); });
            card.addAction(()=>{ return new Run(3, 2);           });
            card.addAction(()=>{ return new Wait(0.5f); });
                        card.addAction(()=>{ return new Run(2, 2);           });
            card.addAction(()=>{ return new Wait(0.5f); });
            card.addAction(()=>{ return new PlayAudio("punch"); });
            card.addAction(()=>{ return new PlayAnimation("blast"); });
            card.addAction(()=>{ return new DamageAction(3);});
            card.addAction(()=>{ return new Wait(0.5f); });
            card.Description = "- Deal "+5+" damage\n - Replace 1 Random Card from Hand\n";
            
            cardDatabase.Add(card.Name, card);    
        }
        //green Cards 
        {
            int damage = 5;
            ICard card = new ICard("Fireblast", 2, EForm.NONE, EForm.RED);
            card.addAction(()=>{ return new Shapeshift(EForm.GREEN); });
                        card.addAction(()=>{ return new Run(5, 10);           });
            card.addAction(()=>{ return new PlayAudio("punch"); });
            card.addAction(()=>{ return new PlayAnimation("fireblast"); });
            card.addAction(()=>{ return new DamageAction(3);});
            card.addAction(()=>{ return new Wait(0.5f); });
            card.addAction(()=>{ return new Shapeshift(EForm.RED); });
            card.Description = "- Deal "+damage+" damage\n - Must be played as first Card\n";
            cardDatabase.Add(card.Name, card);    
        }
        {   
            int damage = 3;
            ICard card = new ICard("Yellowblast", 1, EForm.NONE, EForm.YELLOW);
            card.addAction(()=>{ return new Shapeshift(EForm.GREEN); });
            card.addAction(()=>{ return new Run(5, 10);           });
            card.addAction(()=>{ return new PlayAudio("punch"); });
            card.addAction(()=>{ return new PlayAnimation("yellowblast"); });
            card.addAction(()=>{ return new DamageAction(3);});
            card.addAction(()=>{ return new Wait(0.5f); });
            card.addAction(()=>{ return new Shapeshift(EForm.YELLOW); });
            card.Description = "- Deal "+damage+" damage\n -  Must be played as first Card\n";
            cardDatabase.Add(card.Name, card);     
        }
        {   
            int damage = 5;
            ICard card = new ICard("Pierce Shot", 3, EForm.NONE, EForm.GREEN);
            card.addAction(()=>{ return new Shapeshift(EForm.GREEN); });
            card.addAction(()=>{ return new Run(5, 10);           });
            card.addAction(()=>{ return new PlayAudio("punch"); });
            card.addAction(()=>{ return new PlayAnimation("pierce_shot"); });
            card.addAction(()=>{ return new DamageAction(3);});
            card.addAction(()=>{ return new Wait(0.5f); });
            card.Description = "- Deal "+damage+" damage\n - ShapeShift into next Cards Requirement\n";
            cardDatabase.Add(card.Name, card);       
        }
        
        
        //Yellow Cards
        {
            int damage = 3;
            ICard card = new ICard("FlyingPunch", 1, EForm.RED, EForm.YELLOW);
            card.addAction(()=>{ return new Shapeshift(EForm.YELLOW); });
            card.addAction(()=>{ return new PlayAnimation("run"); });
            card.addAction(()=>{ return new Run(1, 10);           });
            card.addAction(()=>{ return new PlayAudio("punch"); });
            card.addAction(()=>{ return new PlayAnimation("punch"); });

            card.addAction(()=>{ return new DamageAction(3);      });
            card.addAction(()=>{ return new Wait(0.2f); });
            card.Description = "- Deal "+damage+" damage\n \n";
            cardDatabase.Add(card.Name, card);
        }
        {
            int damage = 5;
            ICard card = new ICard("Serious Edition: Serious Punch", 2, EForm.RED, EForm.YELLOW);
             card.addAction(()=>{ return new Shapeshift(EForm.YELLOW); });
            card.addAction(()=>{ return new PlayAnimation("run"); });
            card.addAction(()=>{ return new Run(1, 10);           });
            card.addAction(()=>{ return new PlayAudio("heavy"); });
            card.addAction(()=>{ return new PlayAnimation("serious_punch"); });

            card.addAction(()=>{ return new DamageAction(10);      });
            card.addAction(()=>{ return new Wait(0.5f); });
                        card.Description = "- Deal "+damage+" damage\n\n";
            cardDatabase.Add(card.Name, card);
        }
        {
            int damage = 7;
            ICard card = new ICard("Blast Punch", 3, EForm.GREEN, EForm.YELLOW);
            card.addAction(()=>{ return new Shapeshift(EForm.YELLOW); });
            card.addAction(()=>{ return new PlayAnimation("run");   });
            card.addAction(()=>{ return new Run(5, 10);             });
            card.addAction(()=>{ return new PlayAnimation("guard"); });
            card.addAction(()=>{ return new Wait(0.2f);             });
            card.addAction(()=>{ return new PlayAudio("blast"); });
            card.addAction(()=>{ return new PlayAnimation("blast"); });
                               
            card.addAction(()=>{ return new DamageAction(7);        });
            card.addAction(()=>{ return new Wait(0.7f);             });
                       card.Description = "- Deal "+damage+" damage\n - Draw a card\n";
            
            cardDatabase.Add(card.Name, card);
        }
        
        //red cards
        {
            int damage = 3;
            ICard card = new ICard("Slash", 1, EForm.YELLOW, EForm.RED);
                         card.addAction(()=>{ return new Shapeshift(EForm.RED); });
            card.addAction(()=>{ return new PlayAnimation("run");   });
            card.addAction(()=>{ return new Run(1, 10);             });
            card.addAction(()=>{ return new PlayAnimation("slash"); });
                        
            card.addAction(()=>{ return new DamageAction(3);        });
            card.addAction(()=>{ return new Wait(0.20f);            });  
        
            card.Description = "- Deal "+damage+" damage\n - Opp. Discards a card\n";
            cardDatabase.Add(card.Name, card);
        }
        {
            int damage = 10;
            ICard card = new ICard("Speardash", 5, EForm.RED, EForm.RED);
                         card.addAction(()=>{ return new Shapeshift(EForm.RED); });
            card.addAction(()=>{ return new PlayAnimation("run");   });
            card.addAction(()=>{ return new Run(5, 10);             });
            card.addAction(()=>{ return new PlayAnimation("spear_dash"); });
            card.addAction(()=>{ return new Run(1, 20);             });
            card.addAction(()=>{ return new DamageAction(10);        });
            card.addAction(()=>{ return new Wait(0.20f);             });     
            card.Description = "- Deal "+damage+" damage\n - Opp. Discards a card\n";     
            cardDatabase.Add(card.Name, card);
        }
        {
            int damage = 2;
            ICard card = new ICard("Tail Whip", 2, EForm.GRAY, EForm.RED);
            card.addAction(()=>{ return new Shapeshift(EForm.RED); });
            card.addAction(()=>{ return new PlayAnimation("run");   });
            card.addAction(()=>{ return new Run(1, 10);             });
            card.addAction(()=>{ return new PlayAnimation("idle");  });
            card.addAction(()=>{ return new DamageAction(2);        });
            card.addAction(()=>{ return new Wait(0.50f);            });
            card.Description = "- Deal "+damage+" damage\n - Opp. Discards a card\n";          
            cardDatabase.Add(card.Name, card);
        }
    }
}