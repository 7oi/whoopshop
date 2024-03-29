﻿/* Here within dwells the code for the game Black Jack.*/

// Add properties to player:
// hasBlackJack tags the user if he has black jack, basically
Player.prototype.hasBlackJack = false;
Player.prototype.totallyBust = false;
Player.prototype.seat = null;

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
        case 13:
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
function IsBlackJack(p) 
{
    // Check for Black Jack, according to the rules
    if ((p.cards.length == 2 && CalculateTotal(p) == 21) || (p.cards.length == 5 && !p.totallyBust))
        return true;
    else
        return false;
}

// BlackJackCheck checks all players for Black Jack. It accepts an array of players
function BlackJackCheck(p) 
{
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

// CheckForWinners does what it says, really
function CheckForWinners(p) 
{
    $(".player0").children(".playingcard-backside").toggleClass("playingcard-backside");
    $(".player0").children(".score").text(CalculateTotal(allplayers.dealer));
    while (CalculateTotal(p[0]) < 18) {
        game.server.newCard(group, 0, 1);
        $(".player0").children(".score").text(CalculateTotal(allplayers.dealer));
    }
    var dealerToBeat = CalculateTotal(p[0]);
    for (var i = 1; i < p.length; i++) {
        var currP = ".player" + i;
        if (p[i] != null) {
            // Make the bet go where it's supposed to go
            if (!p[i].totallyBust && (CalculateTotal(p[i]) > dealerToBeat)) {
                p[i].points += (2 * p[i].bet);
                $(currP).children(".message").text("Úps, þú sprakkst!");
                
            }
            else if (!p[i].totallyBust && (CalculateTotal(p[i]) == dealerToBeat)) {
                p[i].points += p[i].bet;
            }
            // Reset the variables
            p[i].bet = 0;
            $(currP).children(".message").show();
            //p[i].hitMe = true;
            // TO DO: Update user points in database
        }
    }
}

// This optional function html-encodes messages for display in the page.
function htmlEncode(value) 
{
    var encodedValue = $('<div />').text(value).html();
    return encodedValue;
};

// The game is here
$(document).ready(function () {

    /*========================================== INITIALIZATION ==========================================*/

    // Start by establishing a connection to the gamehub 
    var game = $.connection.gameHub;
    // Create a group id for this game
    var group = '@(Model.gameID)' + '@(Model.gameName)';
    // Good to save the username
    var me = '@Context.User.Identity.Name';
    var myseat = null;
    var numcards;
    var myPclass;
    var allplayers = [];
    // Create the dealer
    allplayers[0] = new Player("Dealer", 0, 0);
    // Initialize the rest of the array with nulled seats
    for (var i = 1; i < 5; i++) {
        allplayers[i] = null;
    }
    // scroll to bottom of chat on load
    $('.ingame-chat-messages').scrollTop($('.ingame-chat-messages')[0].scrollHeight);
    // Get the user name and store it to prepend to messages.
    $('#displayname').val(me);
    // Set initial focus to message input box.  
    $('#message').focus();

    /* =============================== SignalR functions =============================== */

    // Create a function that the hub can call back to display messages
    game.client.sendMessage = function (name, message) 
    {
        // TODO? Save to database?
        // Add the message to the page. 
        $('.allmessages').append('<li><div class="username">' + htmlEncode(name)
            + '</div>: ' + htmlEncode(message) + '</li>');
        // scroll to bottom of chat on load
        $('.ingame-chat-messages').scrollTop($('.ingame-chat-messages')[0].scrollHeight);
    };
    // A client-side method for players to be able to sit.
    game.client.sitDown = function (seatnr) 
    {
        // Call player constructor for your player
        allplayers[seatnr] = new Player(me, 10000, seatnr);            // TODO: Inject players real points
        // Hide all buttons for sitting down
        $(".sit").hide();
        // Add your name to the username display
        $(".player" + seatnr).children(".username-value").text(me);
        // Add your points to the username display
        $(".player" + seatnr).children(".playerscore-value").text(me);
    };

    // A client-side method for players to be able to quit.
    game.client.quit = function (seatnr) 
    {
        // Null out the seat
        allplayers[seatnr] = null;
        // Empty the username value
        $(".player" + seatnr).children(".username-value").empty();
        // Empty the points value
        $(".player" + seatnr).children(".playerscore-value").empty();
        for (int p = 1; p < 5; p++) {
            // Check for nulled seats
            if (allplayers[p] == null) {
                // Display the seating button for empty seats
                $(".player" + p).children(".sit").fadeIn();
            }
        }                    
    };

    // A client-side method for players to be able to bet.
    game.client.bet = function (seatnr) 
    {
        var myPclass = ".player" + seatnr;
        // Update the players bet
        allplayers[seatnr].MakeBet($(myPclass).children(".betnumber").val());
        // Display the bet
        $(myPclass).children(".score").text(allplayers[seatnr].bet);
        $(myPclass).children(".playerscore-value").text(allplayers[seatnr].points);
    };
    
    // A client side method to get a card
    game.client.getCard = function (seatnr, card, upside)
    {
        var cardTemp = new Card(card.value, card.suit, upside);
        allplayers[seatnr].cards.push(cardTemp);
        $(".player" + seatnr).children(".playerinstance-cardarea").append(cardTemp);
    }

    // A client side method to update players score
    game.client.total = function (seatnr)
    {
        if (allplayers[seatnr].cards[0])
        $(".player" + seatnr).children(".score").text(CalculateTotal(allplayers[myseat]));
        if (allplayers[myseat].totallyBust) {
            $(myPclass).children(".message").text("Úps, þú sprakkst!");
            $(myPclass).children(".message").show();
            $(myPclass).children(".hitme").hide();
            $(myPclass).children(".stand").hide();
            allplayers[myseat].hitMe = false;
        }
    }

    // A client side method for a player to stand
    game.client.stand = function (seatnr)
    {
        $(".player" + seatnr).children(".message").text(me + " stendur");
        $(".player" + seatnr).children(".message").show();
    }

    $.fn.extend({
        blackjack:
            function () {
                // Target the game area and add a game table to it
                var gameObjectElement = '#' + $(this).attr('id');
                $(gameObjectElement).html('<div id="board"></div>');

                // Print out a display for each player in allplayers
                for (var p = 0; p < 5; p++) {
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
                

                // Send message if send button is pressed
                $('#sendmessage').click(function () 
                {
                    // Call the Send method on the hub. 
                    game.server.chatSend(group, $('#displayname').val(), $('#message').val());
                    // Clear text box and reset focus for next comment. 
                    $('#message').val('').focus();
                });

                // ...or if enter is pressed
                $('#message').keydown(function (e) 
                {
                    if (e.keyCode == 13) {
                        // Call the Send method on the hub. 
                        game.server.chatSend(group, $('#displayname').val(), $('#message').val());
                        // Clear text box and reset focus for next comment. 
                        $('#message').val('').focus();
                    }
                });

                // Generate functions for each player to choose seat
                $(".player1").children(".sit").click(function () 
                {
                    game.server.chooseSeat(group, 1);
                    $(".player1").children(".buttons").children().fadeIn();
                    myseat = 1;
                    myPclass = ".player" + myseat;
                });
                $(".player2").children(".sit").click(function () 
                {
                    game.server.chooseSeat(group, 2);
                    $(".player2").children(".buttons").children().fadeIn();
                    myseat = 2;
                    myPclass = ".player" + myseat;
                });
                $(".player3").children(".sit").click(function () 
                {
                    game.server.chooseSeat(group, 3);
                    $(".player3").children(".buttons").children().fadeIn();
                    myseat = 3;
                    myPclass = ".player" + myseat;
                });
                $(".player4").children(".sit").click(function () 
                {
                    game.server.chooseSeat(group, 4);
                    $(".player4").children(".buttons").children().fadeIn();
                    myseat = 4;
                    myPclass = ".player" + myseat;
                });

                // Functions for the player to quit the game
                $(".player1").children(".quit").click(function () 
                {
                    // SignalR magic function
                    game.server.leaveGame(group, 1);
                    // Fade out the buttons, of course
                    $(".player1").children(".buttons").children().fadeOut();
                    myseat = null;
                    myPclass = null;
                });
                $(".player2").children(".quit").click(function () 
                {
                    // SignalR magic function
                    game.server.leaveGame(group, 2);
                    // Fade out the buttons, of course
                    $(".player2").children(".buttons").children().fadeOut();
                    myseat = null;
                    myPclass = null;
                });
                $(".player3").children(".quit").click(function () 
                {
                    // SignalR magic function
                    game.server.leaveGame(group, 3);
                    // Fade out the buttons, of course
                    $(".player3").children(".buttons").children().fadeOut();
                    myseat = null;
                    myPclass = null;
                });
                $(".player4").children(".quit").click(function () 
                {
                    // SignalR magic function
                    game.server.leaveGame(group, 4);
                    // Fade out the buttons, of course
                    $(".player4").children(".buttons").children().fadeOut();
                    myseat = null;
                    myPclass = null;
                });

                // If player clicks on gameboard, messages to him/her disappear
                $(document).click(function () 
                { 
                    if (myseat != null) {
                        $(myPclass).children(".message").fadeOut();
                    }
                    for (var p = 1; p < 5; p++)
                    {
                        if (allplayers[p].hitMe)                                                //TODO
                    }
                });

                /*============================== GAME STARTS ==============================*/

                // Start connection
                $.connection.hub.start().done(function () {
                    // Join group of players
                    game.server.join(group);
       
                    // Shuffle the cards
                    game.server.shuffleTheDeck();

                    // Deal two cards to dealer
                    for (var i = 0; i < 2; i++) {
                        game.server.newCard(group, 0, i);                                          //TODO: Hide one card
                    }

                    // When bet is clicked start game session and deal two cards to the player              
                    $(myPclass).children(".placebet").click(function () {
                        game.server.makeTheBet(group, myseat);
                        // Hide bet button once clicked
                        $(myPclass).children(".placebet").hide();
                        
                        // Deal two cards
                        for (var i = 0; i < 2; i++) {
                            game.server.newCard(group, myseat, 1);
                        }
                        numcards = 1;
                        // Update players score
                        game.server.updateTotal(group, seatnr);
                    });

                    // give a card to the player every time the hit me button is pushed
                    $(myPclass).children(".hitme").click(function () {
                        // register the count of cards so we can print them later
                        game.server.newCard(group, myseat, 1);
                        numcards++;
                        // update the score
                        game.server.updateTotal(group, seatnr);
                    });

                    $(myPclass).children(".stand").click(function () {
                        game.server.playerStands(group, myseat);
                        $(".player" + seatnr).children(".hitme").hide();
                        $(".player" + seatnr).children(".stand").hide();
                    });

                    // Now it's time for the dealer to shine
                    

                    $(".playerinstance-cardarea").empty();
                });
            }
    });
    
    $("#gamearea").blackjack();
});