/* Here within lies the code that defines a player and his actions */

// Lets define a player
function Player(id, points, seat) {
    this.id = id;
    this.bet = '';
    this.points = points - this.bet;
    this.seat = seat;
    this.cards = new Array;
    
    this.hitMe = true;
   
}

//function Player(i, p, s, c, b, h)
//{
//    this.id = i;
//    this.points = p;
//    this.seat = s;
//    this.cards = c;
//    this.bet = b;
//    this.hitMe = h;
//}

// Lets make a function to handle player bets
Player.prototype.MakeBet = function (b) {
    
    if (b < 0)
    {
        b = 0;
    }
    if (this.points >= b) {
        this.bet += b;
        this.points -= b;
    }
    else {
        this.bet = this.points;
        this.points = 0;
    }
}