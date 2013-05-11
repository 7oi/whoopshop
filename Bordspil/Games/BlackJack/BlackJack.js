/* Here within dwells the code for the game Black Jack.*/

// Add properties to player:
// hasBlackJack tags the user if he has black jack, basically
Player.prototype.hasBlackJack = false;
Player.prototype.totallyBust = false;

// RealValue calculates the real calue of the card. Accepts a card as an argument
function RealValue(c)
{
    var val;
    switch (c.value)
    {
        // If it's an Ace we get 11. We'll handle busting elsewhere.
        case 1:
            val = 11;
            break;
        // Royalty is all 10's
        case 11:
        case 12:
        case 0:
            val = 10;
            break;
        // Others just have their respected values
        default:
            val = c.value;
            break;
    }
    return val;
}

// CalculateTotal returns the total of the players hand and accepts a player as an argument
function CalculateTotal(p)
{
    var totes = 0;
    var l = p.cards.length;
    // Loop over all the cards and add up the real values
    for (var i = 0; i < l; i++) 
    {
        totes += RealValue(c[i]);
    }
    // Check if player is bust and take action to fix it if there are aces
    if(totes > 21)
    {
        // Loop and check if there are aces
        for (var i = 0; i < l; i++) {
            if (p.cards[i].value == 1)
            {
                // If there's an ace lower the total by 10
                totes -= 10;
                // If the total is below 21 break from the loop
                if (totes <= 21)
                {
                    break;
                } 
            }
        }
    }
    // Now we check again...
    if (totes > 21)
    {
        // If it didn't work, set player as bust
        p.totallyBust = true;
    }
    return totes;
}

// IsBlackJack checks for Black Jack for a single player and accepts a players cards as an argument
function IsBlackJack(p) 
{
    // Check for Black Jack, according to the rules
    if((p.cards.length == 2 && CalculateTotal(p) == 21) || (p.cards.length == 5 && CalculateTotal(p) <= 21))
        return true;
    else
        return false;
}

// BlackJackCheck checks all players for Black Jack. It accepts an array of players
function BlackJackCheck (p)
{
    // Loop through the players, including the dealer who will be at p[0]
    for (var i = 0; i < p.length; i++)
    {
        if (p[i] != null)
        {
            // Tag them so they have Black Jack
            p[i].hasBlackJack = IsBlackJack(p[i]);
        }
        
    }
    // Now we check if the dealer has black jack
    if (p[0].hasBlackJack) {
        // Then we'll have to loop through our players again
        for (var i = 1; i < p.length; i++) {
            if (p[i] != null)
            {
                // We check if we have a tie
                if (p[i].hasBlackJack) {
                    // And return player his bet
                    p[i].points += p[i].bet;
                }
                // Then set the bet amount to 0. 
                // Note: if it wasn't a tie this means the player loses his betted points
                p[i].bet = 0;
            }
        }
    }
}

// TO DO's in here
// PlaceYourBets goes through players and asks them to make their bets.
function PlaceYourBets(p) {
    // Loop through all players and let them place bets
    for (var i = 1; i < p.length ; i++) {
        if (p[i] != null)
        {
            // TO DO!!! Player interaction
            //p[i].MakeBet(b)
        }
    }
}

// TO DO's in here
// CheckIfHitMe checks if a player wants another hit
function CheckIfHitMe(p)
{
    // Dealer plays by soft 17
    if (CalculateTotal(p[0]) > 17)
    {
        p[0].hitMe = false;
    }
    var check = false;
    // Now we check all players if they want another hit
    for (var i = 1; i < p.length; i++) {
        if (p[i] != null)
        {
            if (!p[i].totallyBust)
            {
                // TO DO: Player interaction
                check = check || p[i].hitMe;
            } 
        }  
    }
    return check;
}

// TO DO's in here
// CheckForWinners does what it says, really
function CheckForWinners(p) {
    var dealerToBeat = CalculateTotal(p[0]);
    for (var i = 1; i < p.length; i++) {
        if (p[i] != null)
        {
            // Make the bet go where it's supposed to go
            if (!p[i].totallyBust && CalculateTotal(p[i]) > dealerToBeat) 
            {
                p[i].points += (2 * p[i].bet);
            }
            // Reset the variables
            p[i].bet = 0;
            p[i].hitMe = true;
            // TO DO: Update user points in database
        }        
    }
}

// TO DO's in here
// CheckIfAgain checks if any player wants to play again and returns true or false
function PlayAgain(p) {
    var check = false;
    // Check if players want to play again
    for (var i = 1; i < p.length; i++) {
        if (p[i] != null) {
            // TO DO! Player interaction
            // Now check the results
            check = check || p[i].again;
            // If they don't want to continue, they quit the game
            if (!p[i].again)
            {
                // TO DO: Player exits successfully and points are added to his account
            }
        }
    }
    return check;
}

// Now, for the main game
function Play(p)
{
    
    // Lets create a new deck
    var d = new Deck();
    // Lets create a dealer too. He'll be number zero
    p[0] = new Player(0, 0, 0);
    var again = true;
    while (again) {
        // Shuffle the deck
        d.Shuffle();                
        // Let players place their bets
        PlaceYourBets(p);
        // Give all players two cards
        d.DealCards(p);
        d.DealCards(p);
        // Now we check for BlackJack
        BlackJackCheck(p);

        // Now we start the second round and go on until all players are done
        for (var i = 0, checkhit = CheckIfHitMe(p) ; checkhit && (i < 3) ; d.DealCards(p), checkhit = CheckIfHitMe(p), i++);
        // Time for another BlackJack check, in case the game went on up to 5 cards
        BlackJackCheck(p);
        // When all that is over, check the winnings
        CheckForWinners(p);
        // Finally check if players want to go another round.
        again = PlayAgain(p);
    }
}