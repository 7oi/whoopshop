/* Here within dwell the code for the game Risk */
var canvas, ctx;
var countrys = [];
var selectedCountry;
var continent = new Array("N-America", "Europe", "S - America", "Africa", "Australia, Asia");
/* Countris in each countent */
var europe, northAmerica, southAmeriva, africa, asia, autralia;

/* North America */
var alaska = new Array("Alaska", northAmerica, null, 0);
var alberta = new Array("Alberta", northAmerica, null, 0);
var centralAmerica = new Array("Central America", northAmerica, null, 0);
var easternUSa = new Array("Estrern Unated State", northAmerica, null, 0);
var greenland = new Array("Greenland", northAmerica, null, 0);
var northwestTeritory = new Array("Northwest Teritory", northAmerica, null, 0);
var qutario = new Array("Qutario", northAmerica, null, 0);
var quebec = new Array("Quebec", northAmerica, null, 0);
var vesternUSA = new Array("Western Unuited State", northAmerica, null, 0);

/* Europe */
var greatBritain = new Array("Great Britain");
var icaland = new Array("Iceland");
var northenEurope = new Array("Northern Europe");
var scandinaiva = new Array("Scandinavia");
var southernEourope = new Array("Southern Europe");
var ukraine = new Array("Ukraine");
var westernEurope = new Array("Western Europe");

/* South America */
var argentina = new Array("Argentina");
var brazil = new Array("Brazil");
var peru = new Array("Peru");
var venezuela = new Array("Venezuela");

/* Africa */
var congo = new Array("Congo");
var eastAfrica = new Array("East Africa");
var egipt = new Array("Egypt");
var madagascar = new Array("Madagascar");
var northAfrica = new Array("North Africa");
var southAfrica = new Array("South Africa");

/* Asia */
var afghanistan = new Array("Afghanistan");
var china = new Array("China");
var india = new Array("India");
var irkutsk = new Array("Irkutsk");
var japan = new Array("Japan");
var kamchatka = new Array("Kamchatka");
var middleEast = new Array("Middle East");
var mongolia = new Array("Mongolia");
var siam = new Array("Siam");
var siberia = new Array("Siberia");
var ural = new Array("Ural");
var yakutsk = new Array("Yakutsk");

/* Australia (2) */
var easternAustralia = new Array("Eastern Australia");
var indonesia = new Array("Indonesia");
var newGuinea = new Array("New Guinea");
var westernAustralia = new Array("Western Australia");

/* Contennet */
var europe = new Array("Iceland", "Scadinavia", "Great-Britan", "Wersten Europe", "Northe Europe", "South Europe", "Ukarania");
var northAmerica = new Array("Alaska", "Alberta", "Central America", "Estern USA", "Greanland", "Northwest Territory", "Ontario", "Quebec", "Western USA");
var southAmeriva = new Array("Venusela", "Brasil", "Peru", "Argentina");
var africa = new Array("North Africa", "Egypt", "Congo", "East Africa", "South Africa", "Matagascar");
var asia = new Array("Midle East", "Ural", "Siberia", "Yakutsa", "Kamchata", "Irkutsa", "Mongolia", "China", "India", "Siam", "Japan");
var autralia = new Array("Indonesia", "New Guinea", "Western Australia", "Eastern Australia");


$(function () {

    
   
});





/* Helper function for Risk */

/* Starting function */
/* return number of starting troopseace player starts with */
function AlloocateTroops(numPlayer)
{
    switch (numPlayer)
    {
        case 2:
            {
                return 40;
            }
        case 3:
            {
                return 35;
            }
        case 4:
            {
                return 30;
            }
        case 5:
            {
                return 25;
            }
        case 6:
            {
                return 20;
            }
            return 0;
    }
}

/* retunr number of troops to deploy */
function ArmyErned(numCountrys) {
    if (numCountrys < 9) {
        return 3;
    }
    return Math.floor(numCountrys / 3);
}



