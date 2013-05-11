﻿/* Here within lies the code that defines a player and his actions */

// Lets define a player
function Player(id, points, bet) {
    this.id = id;
    this.points = points - bet;
    this.bet = bet;
    this.cards = new Array;
}

// Lets make a function to handle player bets
Player.prototype.MakeBet = function (b) {
    if (this.points >= b) {
        this.bet += b;
        this.points -= b;
    }
    else {
        throw "Þú átt ekki inni fyrir veðmálinu";
    }
}