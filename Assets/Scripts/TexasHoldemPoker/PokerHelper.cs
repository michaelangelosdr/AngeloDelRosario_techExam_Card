using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokerHelper : MonoBehaviour
{
    public static int ConvertToVal(string val)
    {
        int Value = 0;        
        if (val == "Ace") return 14;
        else if (val == "Jack") { return 11; }
        else if (val == "Queen") { return 12; }
        else if (val == "King") { return 13; }
        else
        {
            Value = int.Parse(val);

        }
        return Value;
    }

    public static PokerHands CheckHand(ref List<Card> Hand,List<Card> cards)
    {
        PokerHands handresult = PokerHands.NONE; 
        
        SortCards(ref cards);
        Hand.Clear();
        

        if (CheckFlush(ref Hand,cards))
        {
            if(CheckRoyal(Hand))
            {
                return PokerHands.ROYAL_FLUSH;
            }

            if(CheckStraight(Hand))
            {

                return PokerHands.STRAIGHT_FLUSH;
            }

            //isFlush = true;
            return PokerHands.FLUSH;
        }
        if(CheckFourOfAKind(ref Hand, cards))
        {
            return PokerHands.FOUR_OF_A_KIND;
        }
      
        if(CheckFullHouse(ref Hand,cards))
        {
            return PokerHands.FULL_HOUSE;
        }
        if(CheckStraight(ref Hand, cards))
        {
            return PokerHands.STRAIGHT;
        }
       
        if(CheckThreeOfAKind(ref Hand, cards))
        {
            return PokerHands.THREE_PAIR;
        }
       
        handresult = CheckTwoPair(ref Hand, cards);
    
        if (handresult == PokerHands.HIGH_CARD)
        {
            Hand.Clear();
            for(int g = cards.Count-1;g>1;g--)
            {
                Hand.Add(cards[g]);
            }
        }
        
        return handresult;
    }

    public static void SortCards(ref List<Card> cards)
    {
        for(int i =0; i< cards.Count-1;i++)
        {
            for(int j=0;j<cards.Count-i-1;j++)
            {
                if(ConvertToVal(cards[j].GetCardValue())>ConvertToVal(cards[j+1].GetCardValue()))
                {
                    Card temp = cards[j];
                    cards[j] = cards[j + 1];
                    cards[j + 1] = temp;
                }
            }
        }

    }
    private static bool CheckFlush(ref List<Card> Hand ,List<Card> cards)
    {
        Hand.Clear();
        bool IsFlush = false;
        string[] CardFaces = { "Clubs", "Spades", "Diamonds", "Hearts" };
        List<List<int>> m_Facecounter = new List<List<int>>();
        for(int s=0; s<CardFaces.Length;s++)
        {
            List<int> l_int = new List<int>();
            m_Facecounter.Add(l_int);
        }

  

       for(int x =0; x<cards.Count;x++)
        {
            for(int i=0; i<CardFaces.Length;i++)
            {
                if(cards[x].GetCardFace()==CardFaces[i])
                {
                    m_Facecounter[i].Add(x);
                }
            }
        }
       foreach(List<int> l in m_Facecounter)
        {
            if(l.Count>=5)
            {
                
                int diff = l.Count - 5;                
                for(int x=0;x<diff;x++)
                {
                    l.Remove(x);
                }

                for(int i=0;i<l.Count;i++)
                {
                    Hand.Add(cards[l[i]]);
                }
                IsFlush = true;
                break;
            }
        } 
        return IsFlush;
    }
    public static string CheckDrawWinner(PlayerHand p1, PlayerHand p2)
    {

        for(int x=0; x<p1.getHandCards().Count;x++)
        {
            if( ConvertToVal(p1.getHandCards()[x].GetCardValue()) == ConvertToVal(p2.getHandCards()[x].GetCardValue()))
            {
                continue;
            }
            else if(ConvertToVal(p1.getHandCards()[x].GetCardValue()) > ConvertToVal(p2.getHandCards()[x].GetCardValue()))
            {
                return p1.GetPlayerName() ;
            }
            else if (ConvertToVal(p1.getHandCards()[x].GetCardValue()) < ConvertToVal(p2.getHandCards()[x].GetCardValue()))

            {
                return p2.GetPlayerName();
            }

        }

        return "Draw";
    }
    private static bool CheckStraight(List<Card> cards)
    {
   
        bool isStraight = true;
        int ctr = 0;
        int Count = cards.Count - 5;
        for(int x=0; x<cards.Count-1;x++)
        {
            if (ConvertToVal(cards[x].GetCardValue()) + 1
               != ConvertToVal(cards[x + 1].GetCardValue()))
            {
                
                if (x >= Count && ctr <4)
                {
                    return false;
                }
                if(ctr>=4)
                {
                    return true;
                }
               
            }
            else
            {
                ctr++;
            }
            
        }
        return isStraight ;
    }
    private static bool CheckStraight(ref List<Card> Hand,List<Card> cards)
    {
    
        bool isStraight = true;
        int ctr = 0;
        Hand.Clear();
        Hand.Add(cards[0]);
        for (int x = 0; x < cards.Count - 1; x++)
        {
             
            if (ConvertToVal(cards[x].GetCardValue()) + 1
               != ConvertToVal(cards[x + 1].GetCardValue()))
            {

                if (x >= 2 && ctr < 4)
                {
                    return false;
                }
                if (ctr >= 4)
                {
                    if (Hand.Count > 5)
                    {
                        int diff = Hand.Count - 5;
                        for (int xx = 0; xx < diff; xx++)
                        {
                       
                            Hand.Remove(Hand[0]);
                        }
                    }
                    return true;
                }

                Hand.Clear();
                Hand.Add(cards[x+1]);
                ctr = 0;
            }
            else
            {
                Hand.Add(cards[x+1]);
                ctr++;
            }

        }

        if(Hand.Count>5)
        {
            int diff = Hand.Count - 5;
            for(int x=0;x<diff;x++)
            {
               
                Hand.Remove(Hand[0]);
            }
        }
        return isStraight;
    }
    private static bool CheckRoyal(List<Card> cards)
    {
        bool isRoyal = true;
        string[] CardNames = { "10", "Jack", "Queen", "King","Ace" };

        int startindex = cards.Count - 5;
        
        for(int x=0; x<CardNames.Length;x++)
        {
            if(cards[x+startindex].GetCardValue() != CardNames[x])
            {
                return false;
            }
            
        }

        return isRoyal;
    }
    private static bool CheckFullHouse(ref List<Card> Hand, List<Card> cards)
    {
        Hand.Clear();
        List<Card> Temp_Handcards = new List<Card>(); 
        int CurrentHighestVal=0;
        if (CheckNOfAKind(ref Hand, 3, cards))
        {

            List<Card> Temp_Cards = new List<Card>();
            foreach (Card c in cards)
            {
                Temp_Cards.Add(c);
            }
            CurrentHighestVal = ConvertToVal(Hand[0].GetCardValue());
            Temp_Cards.RemoveAll(Card => ConvertToVal(Card.GetCardValue()) == CurrentHighestVal);

            
            for(int x=0; x<Hand.Count;x++)
            {
                Temp_Handcards.Add(Hand[x]);
            }

            if (CheckNOfAKind(ref Hand, 2, Temp_Cards))
            {
               
                for (int x = 0; x < Hand.Count; x++)
                {
                    Temp_Handcards.Add(Hand[x]);
                }
                Hand.Clear();
                Hand = Temp_Handcards;
                return true;
            }

        }



        return false;
    }
    private static bool CheckFourOfAKind(ref List<Card> Hand, List<Card> cards)
    {
        Hand.Clear();
        if (CheckNOfAKind(ref Hand, 4, cards))
        {
            int CurrentHighestVal = 0;
            List<Card> Temp_Cards = new List<Card>();
            foreach (Card c in cards)
            {
                Temp_Cards.Add(c);
            }
            CurrentHighestVal = ConvertToVal(Hand[0].GetCardValue());
            Temp_Cards.RemoveAll(Card => ConvertToVal(Card.GetCardValue()) == CurrentHighestVal);
            Hand.Add(Temp_Cards[Temp_Cards.Count - 1]);
            return true;
        }

        return false;
    }
    private static bool CheckThreeOfAKind(ref List<Card> Hand, List<Card> cards)
    {
        Hand.Clear();
        if (CheckNOfAKind(ref Hand, 3, cards))
        {
            int CurrentHighestVal = 0;
            List<Card> Temp_Cards = new List<Card>();
            foreach (Card c in cards)
            {
                Temp_Cards.Add(c);
            }
            CurrentHighestVal = ConvertToVal(Hand[0].GetCardValue());
            Temp_Cards.RemoveAll(Card => ConvertToVal(Card.GetCardValue()) == CurrentHighestVal);
            Hand.Add(Temp_Cards[Temp_Cards.Count - 1]);
            Hand.Add(Temp_Cards[Temp_Cards.Count - 2]);
            return true;
        }

        return false;
    }
    private static PokerHands CheckTwoPair(ref List<Card> Hand, List<Card> cards)
    {
        Hand.Clear();
        List<Card> Temp_Handcards = new List<Card>();
        List<Card> Temp_Cards = new List<Card>();
        int ctr = 0;
        int CurrentHighestVal = 0;
        foreach (Card c in cards)
        {
            Temp_Cards.Add(c);
        }
        for (int xx=0; xx<2;xx++)
        {
            if (CheckNOfAKind(ref Hand, 2, Temp_Cards))
            {                
                CurrentHighestVal = ConvertToVal(Hand[0].GetCardValue());
                Temp_Cards.RemoveAll(Card => ConvertToVal(Card.GetCardValue()) == CurrentHighestVal);
                for (int x = 0; x < Hand.Count; x++)
                {
                    Temp_Handcards.Add(Hand[x]);
                }
                ctr++;
                          
            }
            else
                break;

        }
        if (ctr == 1)
        {
            Hand.Clear();
            Hand = Temp_Handcards;
            for(int x=1; x<3+1;x++)
            {
                Hand.Add(Temp_Cards[Temp_Cards.Count - x]);
            } 
            return PokerHands.PAIR;
        }
        if (ctr == 2)
        {
            Hand.Clear();
            Hand = Temp_Handcards;
            Hand.Add(Temp_Cards[Temp_Cards.Count - 1]);
            return PokerHands.TWO_PAIR;
        }
    


        return PokerHands.HIGH_CARD;
    }
    private static bool CheckNOfAKind(ref List<Card> hand, int n, List<Card> cards)
    {
        bool IsNOfAKind = false;
        int ctr = 0;
        int CurrentCheckIndex = 0;
        int CurrentCardList = 1;
        List<List<Card>> MultipleCards_List = new List<List<Card>>();
        
       
        for (int x = 1; x < cards.Count; x++)
        {
           //Debug.Log(ConvertToVal(cards[CurrentCheckIndex].GetCardValue()) + "==" + ConvertToVal(cards[x].GetCardValue()));
            if (ConvertToVal(cards[CurrentCheckIndex].GetCardValue()) !=
                ConvertToVal(cards[x].GetCardValue()))
            {
                if (ctr >= n - 1)
                {
                    MultipleCards_List[CurrentCardList-1].Add(cards[CurrentCheckIndex]);
                    IsNOfAKind = true;
                    CurrentCheckIndex = x;
                    CurrentCardList++;
                    ctr = 0;
                }
                else
                {                   
                    CurrentCheckIndex = x;
                    ctr = 0;
                }
            }
            else
            {
                if(MultipleCards_List.Count < CurrentCardList)
                {
                    List<Card> newList = new List<Card>();
                    newList.Add(cards[x]);
                    MultipleCards_List.Add(newList);
                    if (x == cards.Count - 1)
                    {
                        MultipleCards_List[CurrentCardList - 1].Add(cards[CurrentCheckIndex]);
                    }
                }
                else
                {
                    MultipleCards_List[CurrentCardList-1].Add(cards[x]);
                    if (x == cards.Count - 1)
                    {
                        MultipleCards_List[CurrentCardList - 1].Add(cards[CurrentCheckIndex]);
                    }
                }
               
              

               
                ctr++;
            }
        }

        if (ctr == n - 1)
        {
            IsNOfAKind = true;
        }
        if (IsNOfAKind)
        {
            if (MultipleCards_List.Count > 1)
            {
                for (int x = MultipleCards_List.Count - 1; x > -1; x--)
                {
                    if (MultipleCards_List[x].Count >= n)
                    {
                        //Debug.Log("HEHE");
                        hand = MultipleCards_List[x];
                        break;
                    }
                }
            }
            else
            {

                hand = MultipleCards_List[0];
            }



            if (hand.Count > n)
            {
                int diff = hand.Count - n;
                for (int x = 0; x < diff; x++)
                {
                    hand.Remove(hand[0]);
                }
            }
        }
       


        return IsNOfAKind;


    }

    
    //TestMethods
    public static void LogCardNames(List<Card> cards)
    {
        foreach(Card c in cards)
        {
            Debug.Log(c.GetCardName());
        }
    }
    public static void ClearConsole()
    {
        var logEntries = System.Type.GetType("UnityEditor.LogEntries, UnityEditor.dll");

        var clearMethod = logEntries.GetMethod("Clear", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public);

        clearMethod.Invoke(null, null);
    }
}
