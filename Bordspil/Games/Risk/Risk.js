/* Here within dwell the code for the game Risk */
var canvas, ctx;
var countrys = [];
var selectedCountry;
var x, y;

$(function () {
    var stage = new Kinetic.Stage({
        container: 'container',
        width: 1000,
        height: 800
    });
    var mapLayer = new Kinetic.Layer({
        y: 20,
        scale: 1
    });
    var topLayer = new Kinetic.Layer({
        y: 20,
        scale: 1
    });

    /*
     * loop through country data stroed in the worldMap
     * variable defined in the worldMap.js asset
     */
    for (var key in worldMap.shapes) {
        var path = new Kinetic.Path({
            data: worldMap.shapes[key],
            fill: '#eee',
            stroke: '#555',
            strokeWidth: 1
        });

        path.on('mouseover', function () {
            this.setFill('#88888');
            this.moveTo(topLayer);
            topLayer.drawScene();
            console.log(this)
        });

        path.on('mouseout', function () {
            this.setFill('#eee');
            this.moveTo(mapLayer);
            topLayer.draw();
        });

        mapLayer.add(path);
    }

    stage.add(mapLayer);
    stage.add(topLayer);

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



