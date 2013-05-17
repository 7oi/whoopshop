/*
Here within dwells some reusable code between games that deals with cards and the 
shuffling and dealing of them.
*/

// Lets start by defining a card
function Card(val, suit, upside)
{
    this.value = val;
    this.suit = suit;
    this.upside = upside;
}

// It's good to have a function that prints out the value in text
Card.prototype.toString = function()
{
    var cardString = "<div class='playingcard";
    if (this.upside == 0)
    {
        cardString += " playingcard-backside";
    }
    switch (this.suit)
    {
        case 1:
            cardString += " red'><span>&hearts;</span>";
            break;
        case 2:
            cardString += "'><span> &spades;</span>";
            break;
        case 3:
            cardString += " red'><span> &diams;</span>";
            break;
        case 4:
            cardString += "'><span> &clubs;</span>";
            break;
    }
    switch (this.value)
    {
        case 1:
            cardString += "A";
            break;
        case 2:
            cardString += "2";
            break;
        case 3:
            cardString += "3";
            break;
        case 4:
            cardString += "4";
            break;
        case 5:
            cardString += "5";
            break;
        case 6:
            cardString += "6";
            break;
        case 7:
            cardString += "7";
            break;
        case 8:
            cardString += "8";
            break;
        case 9:
            cardString += "9";
            break;
        case 10:
            cardString += "10";
            break;
        case 11:
            cardString += "J";
            break;
        case 12:
            cardString += "Q";
            break;
        case 0:
            cardString += "K";
            break;
    }
    cardString += "</div>";
    return cardString;
}
 //Lets define the deck
function Deck()
{
    // Array of 52 cards and a counter for cards left in deck
    this.deck = new Array(52);
    this.cardsLeft = 52;

    // Fill the "deck"
    for (var i = 0; i < 52; i++)
    {
        // To make the cards easily identifiable we make an object with value and sort
        this.deck[i] = new Card((i % 13), Math.ceil(i / 13));

    }
}

// We found this nifty shuffle algorithm by the way of google, so we decided to use it.
// Credit goes to:
//+ Jonas Raoni Soares Silva
//@ http://jsfromhell.com/array/shuffle [v1.0]
Deck.prototype.Shuffle = function()
{ //v1.0
    // This magnificent loop shuffles the hell out of the deck
    for (var j, x, i = this.deck.length; i; 
        j = parseInt(Math.random() * i), x = this.deck[--i], this.deck[i] = this.deck[j], this.deck[j] = x);
    // Then we reset the number of cards left in the deck
    this.cardsLeft = 52;    
};

// DealCard is a function to get a card from the top of the deck
Deck.prototype.DealCard = function(upside)
{
    // Of course, if there are no cards left we throw an exception
    if (this.cardsLeft == 0)
    {
        throw "Spilin eru búin";
    }
    else {
        var c = this.deck[--this.cardsLeft];
        c.upside = upside;
    }
    // If all is normal we return the card from the top of the pile
    // and reduce the number of cards left while we're at it
    return c;
}

// Now, lets define a method that accepts an array of players and deals cards to all of them
Deck.prototype.DealCards = function (p)
{
    for (var i = 0; i < p.length ; i++) {
        // Since it's two loops we'll have to use % to get the right id
        // Some seats might be empty, so don't deal cards to them.
        if (p[i] != null) {
            if (p[i].hitMe)
            {
                p[i].cards.push(d.DealCard());
            }      
        }
    }
}

