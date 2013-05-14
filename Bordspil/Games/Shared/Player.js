/* Here within lies the code that defines a player and his actions */

// Lets define a player
function Player(id, points) {
    this.id = id;
    this.bet = 10;
    this.points = points - this.bet;
    this.cards = new Array;
    this.hitMe = true;
}

// Lets make a function to handle player bets
Player.prototype.MakeBet = function (b) {
    var betTooHigh = true;

    if (this.points >= b) {
        this.bet += b;
        this.points -= b;
    }
    else {
        this.bet = this.points;
        this.points = 0;
    }
}