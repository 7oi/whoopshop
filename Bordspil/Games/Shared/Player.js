/* Here within lies the code that defines a player and his actions */

// Lets define a player
function Player(id, points, seat) {
    this.id = id;
    this.bet = '';
    this.points = points - this.bet;
    this.cards = new Array;
    this.hitMe = true;
    this.seat = seat;
}

// Lets make a function to handle player bets
Player.prototype.MakeBet = function (b) {
    
    if (this.points >= b) {
        this.bet += b;
        this.points -= b;
    }
    else {
        this.bet = this.points;
        this.points = 0;
    }
}