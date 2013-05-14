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

// The game is here
$(document).ready(function () {

    $.fn.extend({
        blackjack:
            function () {
                // create players and determine if they are dealers or not

                var player = new Player(1, 1000, 5);
                player.isDealer = false;
                var dealer = new Player(0, 0, 0);
                dealer.isDealer = true;
                var allplayers = { "dealer": dealer, "player": player };
                //var allplayers = [dealer,player];

                // create deck and shuffle it
                var deck = new Deck;
                deck.Shuffle();


                // target the game area and add a game table to it
                var gameObjectElement = '#' + $(this).attr('id');
                $(gameObjectElement).html('<div id="board"></div>');

                // for each player in allplayers
                // print out a display for them
                for (player in allplayers) {

                    $("#board").append(


                        "<div class='" + player + " playerinstance'>"
                        + "<span class='score'>0</span>"
                        + "<a href='javascript:void(0)' class='placebet'>Veðja</a> "
                        + "<a href='javascript:void(0)' class='hitme'>Fá spil</a> "
                        + "<a href='javascript:void(0)' class='stand'>Standa</a>"
                    );
                };

                //hide the dealer links
                $(".dealer").children(".placebet").hide();
                $(".dealer").children(".hitme").hide();
                $(".dealer").children(".stand").hide();

                // when bet is clicked start game session and deal two cards to all players and dealer
                $(".placebet").click(function () {
                    for (player in allplayers) {
                        var numcards = allplayers[player].cards.length;
                        // deal two cards to each
                        for (var i = 0; i < 2; i++) {
                            allplayers[player].cards[i] = deck.DealCard();
                            console.log(allplayers[player].cards[i].suit);
                            $("." + player).append(" " + allplayers[player].cards[i].toString());
                           
                            //allplayers[player].score += RealValue(allplayers[player].cards[i]);
                            // hide bet button once clicked
                            $("." + player).children(".placebet").hide();
                        }
                        $("." + player).children(".score").text(CalculateTotal(allplayers[player]));

                    }
                });

                for (player in allplayers) {
                    // give a card to the player every time the hit me button is pushed
                    $("." + player).children(".hitme").click(function () {
                        // register the count of cards so we can print them later
                        var numcards = allplayers[player].cards.length;
                        allplayers[player].cards.push(deck.DealCard());
                        console.log(allplayers[player].cards[numcards].suit);
                        // print out the card dealt
                        //console.log(RealValue(allplayers[player].cards[numcards]));
                        $("." + player).append(" " + allplayers[player].cards[numcards].toString());
                        // update the score
                        $("." + player).children(".score").text(CalculateTotal(allplayers[player]));
                        if (allplayers[player].totallyBust) {
                            $("." + player).append("Sprunginn! Þú tapar!"); // needs proper alert box
                            $("." + player).children(".hitme").hide();
                            $("." + player).children(".stand").hide();
                        }
                    });

                    $("." + player).children(".stand").click(function () {

                        $("." + player).children(".hitme").hide();
                        $("." + player).children(".stand").hide();

                        while (CalculateTotal(allplayers.dealer) < 18) {
                            var numcards = allplayers.dealer.cards.length; // implement better DRY
                            allplayers.dealer.cards.push(deck.DealCard());
                            $(".dealer").append(" " + allplayers.dealer.cards[numcards].toString()).animate();
                            $(".dealer").children(".score").text(CalculateTotal(allplayers.dealer));
                            if (allplayers.dealer.totallyBust) {

                            }
                        }



                        if (CalculateTotal(allplayers.dealer) > CalculateTotal(allplayers[player]) && CalculateTotal(allplayers.dealer) <= 21) {
                            console.log("Til hamingju, þú tapaðir!");
                        } else if (CalculateTotal(allplayers.dealer) == CalculateTotal(allplayers[player])) {
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