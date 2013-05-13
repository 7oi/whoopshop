/* Here within dwell the code for the game Risk */
var canvas, ctx;
var selectedCountry;
var continent = new Array("N-America", "Europe", "S - America", "Africa", "Australia, Asia");
/* Countris in each countent */

/* North America */
var alaska = new Array("Alaska", northAmerica, null, 0, northwestTeritory, alberta, kamchatka);
var alberta = new Array("Alberta", northAmerica, null, 0, alaska, northwestTeritory, ontario, westernUsa );
var centralAmerica = new Array("Central America", northAmerica, null, 0, westernUsa, easternUsa, venezuela);
var easternUsa = new Array("Estrern Unated State", northAmerica, null, 0, centralAmerica, westernUsa, ontario, quebec);
var greenland = new Array("Greenland", northAmerica, null, 0, northwestTeritory, ontario, quebec, icaland);
var northwestTeritory = new Array("Northwest Teritory", northAmerica, null, 0, alaska, alberta, ontario, quebec, greenland);
var ontario = new Array("Qutario", northAmerica, null, 0, easternUsa, westernUsa, alberta, northwestTeritory, greatBritain, quebec);
var quebec = new Array("Quebec", northAmerica, null, 0, easternUsa, ontario, greenland);
var westernUsa = new Array("Western Unuited State", northAmerica, null, 0, alberta, ontario, easternUsa, centralAmerica);

/* Europe */
var greatBritain = new Array("Great Britain", europe, null, 0, icaland, scandinaiva, northenEurope, westernEurope);
var icaland = new Array("Iceland", europe, null, 0, greenland, scandinaiva, greatBritain);
var northenEurope = new Array("Northern Europe", europe, null, 0, scandinaiva, ukraine, southernEourope, westernEurope, greatBritain);
var scandinaiva = new Array("Scandinavia", europe, null, 0, ukraine, northenEurope, greatBritain, icaland);
var southernEourope = new Array("Southern Europe", europe, null, 0, westernEurope, northenEurope, ukraine, middleEast, egipt, northAfrica);
var ukraine = new Array("Ukraine", europe, null, 0, southernEourope, northenEurope, scandinaiva, ural, afghanistan, middleEast);
var westernEurope = new Array("Western Europe", europe, null, 0, greatBritain, northenEurope, southernEourope, northAfrica);

/* South America */
var argentina = new Array("Argentina", southAmerica, null, 0, peru, brazil);
var brazil = new Array("Brazil", southAmerica, null, 0, argentina, peru, venezuela, northAfrica);
var peru = new Array("Peru", southAmerica, null, 0, venezuela, brazil, argentina);
var venezuela = new Array("Venezuela", southAmerica, null, 0, brazil, peru, centralAmerica);

/* Africa */
var congo = new Array("Congo", africa, null, 0, northAfrica, eastAfrica, southAfrica);
var eastAfrica = new Array("East Africa", africa, null, 0, madagascar, southAfrica, congo, northAfrica, egipt, middleEast);
var egipt = new Array("Egypt", africa, null, 0, eastAfrica,northAfrica,southernEourope,middleEast );
var madagascar = new Array("Madagascar", africa, null, 0, southAfrica, eastAfrica);
var northAfrica = new Array("North Africa", africa, null, 0, egipt, eastAfrica, congo, brazil, westernEurope, southernEourope);
var southAfrica = new Array("South Africa", africa, null, 0, congo, eastAfrica, madagascar);

/* Asia */
var afghanistan = new Array("Afghanistan", asia, null, 0, ural, china, india, middleEast, ukraine);
var china = new Array("China", asia, null, 0, siam, india, afghanistan, ural, siberia, mongolia);
var india = new Array("India", asia, null, 0, middleEast, afghanistan, china, siam);
var irkutsk = new Array("Irkutsk", asia, null, 0, mongolia, siberia, yakutsk, kamchatka);
var japan = new Array("Japan", asia, null, 0, mongolia, kamchatka);
var kamchatka = new Array("Kamchatka", asia, null, 0, japan, mongolia, irkutsk, yakutsk, alaska);
var middleEast = new Array("Middle East", asia, null, 0, afghanistan, india, eastAfrica, egipt, southernEourope, ukraine);
var mongolia = new Array("Mongolia", asia, null, 0, china, siberia, irkutsk, kamchatka, japan);
var siam = new Array("Siam", asia, null, 0, india, china, indonesia);
var siberia = new Array("Siberia", asia, null, 0, yakutsk, irkutsk, mongolia, china, ural);
var ural = new Array("Ural", asia, null, 0, siberia, china, afghanistan, ukraine);
var yakutsk = new Array("Yakutsk", asia, null, 0, kamchatka, irkutsk, siberia);

/* Australia (2) */
var easternAustralia = new Array("Eastern Australia", autralia, null, 0, westernAustralia, newGuinea);
var indonesia = new Array("Indonesia", autralia, null, 0, newGuinea, westernAustralia, siam);
var newGuinea = new Array("New Guinea", autralia, null, 0, easternAustralia, westernAustralia, indonesia);
var westernAustralia = new Array("Western Australia", autralia, null, 0, indonesia, newGuinea, easternAustralia);

/* Contennet */
var europe = new Array(icaland, scandinaiva, greatBritain, westernEurope, northenEurope, southernEourope, ukraine);
var northAmerica = new Array(alaska, alberta, centralAmerica, easternUsa, greenland, northwestTeritory, ontario, quebec, westernUsa);
var southAmerica = new Array(venezuela, brazil, peru, argentina);
var africa = new Array(northAfrica, egipt, congo, eastAfrica, southAfrica, madagascar);
var asia = new Array(middleEast, ural, siberia, yakutsk, kamchatka, irkutsk, mongolia, china, india, siam, japan);
var autralia = new Array(indonesia, newGuinea, westernAustralia, easternAustralia);

var countrys = new Array(icaland, scandinaiva, greatBritain, westernEurope, northenEurope, southernEourope, ukraine, alaska, alberta, centralAmerica, easternUsa, greenland, northwestTeritory, ontario, quebec, westernUsa, venezuela, brazil, peru, argentina, northAfrica, egipt, congo, eastAfrica, southAfrica, madagascar, middleEast, ural, siberia, yakutsk, kamchatka, irkutsk, mongolia, china, india, siam, japan, indonesia, newGuinea, westernAustralia, easternAustralia);



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

/* retunr number of troops to deploy depending on country owned by player */
function ArmyErned(numCountrys) {
    if (numCountrys < 9) {
        return 3;
    }
    return Math.floor(numCountrys / 3);
}



