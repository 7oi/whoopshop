/* Here within dwells the code for the game Black Jack.*/

// Lets start by making a function that calculates the real value of the cards
function realValue(c)
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

// IsBust checks if player is bust or not
function IsBust(totes) 
{
    if(totes > 21)
        return true;
    else
        return false;
}

// CalculateTotal calculates the total of the players hand
function CalculateTotal(c)
{
    var totes = 0;
    // Loop over all the cards and add up the real values
    for (var i = 0; i < c.length; i++) 
    {
        totes += realValue(c[i]);
    }
    // Check if player is bust and take action to fix it if there are aces
    if(IsBust(totes))
    {
        // Loop and check if there are aces
        for (var i = 0; i < c.length; i++) {
            if (c[i].value == 1)
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
    return totes;
}

// IsBlackJack calculates the instance where BlackJack comes up
function IsBlackJack(c) 
{
    if((c.length == 2 && CalculateTotal(c) == 21) || (c.length == 5 && CalculateTotal(c) <= 21))
        return true;
    else
        return false;
}