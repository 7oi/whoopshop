/*
    Here within lies some code for a n sided dice which can be reused between games
*/

function ThrowDice(numSides)
{
    return Math.ceil(Math.random() * numSides);
}