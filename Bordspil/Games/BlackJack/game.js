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
        totes += RealValue(p.cards[i]);
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

// IsBlackJack checks for Black Jack for a single player and accepts a player as an argument
function IsBlackJack(p) {
    // Check for Black Jack, according to the rules
    if (p.cards.length == 2 && CalculateTotal(p) == 21)
        return true;
    else
        return false;
}

// BlackJackCheck checks all players for Black Jack. It accepts an array of players
function BlackJackCheck(p) {
    // Loop through the players, including the dealer who will be at p[0]
    for (var i = 0; i < p.length; i++) {
        if (p[i] != null) {
            // Tag them so they have Black Jack
            p[i].hasBlackJack = IsBlackJack(p[i]);
        }

    }
    // Now we check if the dealer has black jack
    if (p[0].hasBlackJack) {
        // Then we'll have to loop through our players again
        for (var i = 1; i < p.length; i++) {
            if (p[i] != null) {
                // We check if we have a tie
                if (p[i].hasBlackJack) {
                    // And return player his bet
                    p[i].points += p[i].bet;
                    // And set the message to the player
                    $(".player" + i).children(".message").text("Jafntefli!");
                }
                // Then set the bet amount to 0. 
                // Note: if it wasn't a tie this means the player loses his betted points
                p[i].bet = 0;
                // And set the message to the player
                $(".player" + i).children(".message").text("Þú tapar!");
                // ...and show the message
                $(".player" + i).children(".message").show();
            }
        }
    }
}

// The game is here
$(document).ready(function () {

    $.fn.extend({
        blackjack:
            function () {
                // Create an array for the players
                var allplayers = [];
                // Create the dealer
                allplayers[0] = new Player("Dealer", 0);
                // Initialize the rest of the array with nulled seats
                for (var i = 1; i < 5; i++) {
                    allplayers[i] = null;
                }

                // If player clicks on gameboard, messages to him/her disappear
                $(document).click(function () {
                    for (var p = 1; p < 5; p++) {
                        if ('@Context.User.Identity.Name' == allplayers[p].id) {
                            $(".player" + i).children(".message").fadeOut();
                        }
                    }
                });

                // Create deck and shuffle it
                var deck = new Deck;
                deck.Shuffle();

                // Target the game area and add a game table to it
                var gameObjectElement = '#' + $(this).attr('id');
                $(gameObjectElement).html('<div id="board"></div>');

                // Print out a display for each player in allplayers
                for (var p = 1; p < 5; p++) {
                    // Append to the gameboard
                    $("#board").append(
                        "<div class='player" + p + " playerinstance'>"
                        + "<span class='score'>0</span>"
                        + "<a href='javascript:void(0)' class='placebet'>Veðja</a> "
                        + "<a href='javascript:void(0)' class='hitme'>Fá spil</a> "
                        + "<a href='javascript:void(0)' class='stand'>Standa</a>"
                        + "<a href='javascript:void(0)' class='quit'>Hætta</a>"
                    );
                };

                // Generate functions for each player to choose seat
                for (var p = 1; p < 5; p++) {
                    $(".player" + p).children(".sit").click(function () {
                        allplayers[p] = new Player('@Context.User.Identity.Name', '@Model.User.points')
                        $(".player" + p).children(".sit").hide();
                    });
                }

                // Generate functions for each player to leave game
                for (var p = 1; p < 5; p++) {
                    $(".player" + p).children(".quit").click(function () {
                        allplayers[p] = null;
                        $(".player" + p).children(".sit").fadeIn();
                    });
                }

                // When bet is clicked start game session and deal two cards to all players and dealer
                for (var p = 1; p < 5; p++) {
                    var currP = ".player" + p;
                    $(currP).children(".placebet").click(function () {
                        // Hide bet button once clicked
                        $(currP).children(".placebet").hide();
                        for (var i = 0; i < 2; i++) {
                            allplayers[p].cards.push(deck.DealCard());
                            $(currP).children(".playerinstance-cardarea").append(allplayers[p].cards[i].toString()); 
                        }
                        // Update players score
                        $(currP).children(".score").text(CalculateTotal(allplayers[p]));
                    });
                }


                for (var p = 1; p < 5; p++) {
                    var currP = ".player" + p;
                    // give a card to the player every time the hit me button is pushed
                    $(currP).children(".hitme").click(function () {
                        // register the count of cards so we can print them later
                        var numcards = allplayers[p].cards.length;
                        allplayers[p].cards.push(deck.DealCard());
                        // print out the card dealt
                        $(currP).append(" " + allplayers[p].cards[numcards].toString());
                        // update the score
                        $(currP).children(".score").text(CalculateTotal(allplayers[p]));
                        if (allplayers[p].totallyBust) {
                            $(currP).children(".message").text("Þú ert sprunginn!");
                            $(currP).children(".hitme").hide();
                            $(currP).children(".stand").hide();
                        }
                    });

                    $(currP).children(".stand").click(function () {

                        $(currP).children(".hitme").hide();
                        $(currP).children(".stand").hide();

                        while (CalculateTotal(allplayers[0]) < 18) {
                            var numcards = allplayers.dealer.cards.length; // implement better DRY
                            allplayers.dealer.cards.push(deck.DealCard());
                            $(".dealer").append(" " + allplayers.dealer.cards[numcards].toString()).animate();
                            $(".dealer").children(".score").text(CalculateTotal(allplayers.dealer));
                        }


                        if (CalculateTotal(allplayers.dealer) > CalculateTotal(allplayers[player]) && !allplayers.dealer.totallyBust) {
                            console.log("Til hamingju, þú tapaðir!");
                        } else if (CalculateTotal(allplayers.dealer) == CalculateTotal(allplayers[player]) || (allplayers.dealer.totallyBust && allplayers[player].totallyBust) ) {
                            console.log("Jafntebli!");
                        } else {
                            console.log("Oh, þú vannst!");
                        }
                    });
                };
            }
    });
    $("#gamearea").blackjack();
});