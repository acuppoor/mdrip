function addListenerToResults() {
    var infectionResults = document.getElementsByClassName('infection_result_row');
    for (var i = 0; i < infectionResults.length; i++) {
        var item = infectionResults[i];
        item.addEventListener('click', function () {
            document.getElementById('infections_div').innerHTML += '<button class="vis-badge vis-badge-infection vis-badge-selected selectedInfection">' + $(this).attr('data-name') + ' <hr class="vis-vr">&nbsp;<a href="#" style="color:black;" class="fa fa-trash"></a></button>';
            toggleInfectionsAndRegions("selectedInfection");
        });
    }

    var regionResults = document.getElementsByClassName('region_result_row');
    for (var i = 0; i < regionResults.length; i++) {
        var item = regionResults[i];
        item.addEventListener('click', function () {
            document.getElementById('regions_div').innerHTML += '<button class="vis-badge vis-badge-region vis-badge-selected selectedRegion">' +$(this).attr('data-name')+' <hr class="vis-vr">&nbsp;<a href="#" style="color:black;" class="fa fa-trash"></a></button>';
            toggleInfectionsAndRegions("selectedRegion");
        });
    }

}

function refreshVis() {
    // the key is the region id as in the pakistan.json file
    // lat, lng for each bacteria and any other details that will be asked by the client
    // needs prevalence, death, color hex code for each region
    // sum of prevalence and death is optional since can be done in front end
    // below is an example of the json the api/controller must respond with
    
    var result = {
            1: {
                name:'Region One',
                results:{
                    'infectionOne': {
                        prevalence: {
                            '2018-01-01': 10,
                            '2018-02-01': 23,
                            '2018-03-01': 45
                        },
                        deathrate: {
                            '2018-01-01': 4,
                            '2018-02-01': 8,
                            '2018-03-01': 20
                        },
                        prevalencecolor: '#868686',
                        deathratecolor: '#868686',
                        lat: 30,
                        lng: 69.3 // other details for the visualisation goes below this line
                    }
                }
            }
    };

    var element = $('#chartSelection');
    var selected = element.val();
    switch (selected) {
        case "Pie Chart":
        case "Bar Chart":
            testbarchart(result);//donut();
            break;
        case "Scatter Plot":
            scatter();
            break;
        case "Line Graph":
            lineGraph();
            break;
        case "Choropleth Map":
            choropleth();
            break;
        case "Geographic Map":
            geographicmap();
            break;
        default:
    }
}


function testbarchart(result) {

    resetVisualisation();
    var visDiv = $('#visualisation');

    var barchart = document.createElement('div');
    barchart.id = 'barchart';
    barchart.setAttribute("style", "width:50%; height;100%; vertical-align: middle; text-align: center; float:left");
    visDiv[0].appendChild(barchart);

    var piechart = document.createElement('div');
    piechart.id = 'piechart';
    piechart.setAttribute("style", "width:50%; height;100%; float:right;");
    visDiv[0].appendChild(piechart);
    
    // need to check if both prevalence and deathrate is selected. assuming yes here;
    deathRate = true; prevalence = true;
    var forBarchart = [];
    var forPiechart = [];
    for (var item in result){
        var value = result[item];
        var pushOne = {};
        pushOne.y = value['name'];
        if (prevalence) {
            var totalprevalences = 0;
            for (var subitem in value['results']){
                prevalences = value['results'][subitem]['prevalence'];
                for (var subsubitem in prevalences){
                    totalprevalences += prevalences[subsubitem];
                }
            }
            pushOne.a = totalprevalences;
        }
        if (deathRate){
            var totaldeaths = 0;
            for (var subitem in value['results']){
                deathRates = value['results'][subitem]['deathrate'];
                for (var subsubitem in deathRates){
                    totaldeaths += deathRates[subsubitem];
                }
            }
            pushOne.b = totaldeaths;
        }
        forBarchart.push(pushOne);
        
    }
    ykeys = []; labels = [];
    if (prevalence && deathRate){
        ykeys=['a', 'b']; labels['Prevalence', 'Death Rate'];
    } else {
        if (prevalence){
            xkeys=['a']; labels['Prevalence'];
        } else {
            xkeys=['b']; labels['Death Rate'];
        }
    }

    Morris.Bar({
        element: 'barchart',
        data: forBarchart,
        xkey: 'y',
        ykeys: ykeys,
        hideHover: 'auto',
        labels: labels
    });

    Morris.Donut({
        element: 'piechart',
        data: [
            { label: "Infection 1", value: 12 },
            { label: "Infection 2", value: 30 },
            { label: "Infection 3", value: 20 }
        ]
    });
}


function toggleInfectionsAndRegions(className) {
    var items = document.getElementsByClassName(className);

    if (items === null) {
        items = $('.' + className);
    }
    for (var i = 0; i < items.length; i++) {
        items[i].addEventListener('click', function(event) {
            $(this).toggleClass("vis-badge-selected");
            $(this).toggleClass("vis-badge-notselected");
        });
    }
}


$('#chartSelection').change(function() {
    var element = $('#chartSelection');
    var selected = element.val();
    resetVisualisation();
    switch (selected) {
        case "Pie Chart":
            barchart();//donut();
            break;
        case "Bar Chart":
            barchart();
            break;
        case "Scatter Plot":
            scatter();
            break;
        case "Line Graph":
            lineGraph();
            break;
        case "Choropleth Map":
            choropleth();
            break;
        case "Geographic Map":
            geographicmap();
            break;
        default:
    }
});


function resetVisualisation() {
    $('#visualisation').innerHTML = "";
    $("#visualisation").html("");
}

function geographicmap() {
    var mapProp = {
        center: new google.maps.LatLng(30.3, 69.3),
        zoom: 5,
        styles: [
            {
                "featureType": "administrative",
                "elementType": "geometry",
                "stylers": [
                    {
                        "visibility": "off"
                    }
                ]
            },
            {
                "featureType": "poi",
                "stylers": [
                    {
                        "visibility": "off"
                    }
                ]
            },
            {
                "featureType": "road",
                "elementType": "labels.icon",
                "stylers": [
                    {
                        "visibility": "off"
                    }
                ]
            },
            {
                "featureType": "transit",
                "stylers": [
                    {
                        "visibility": "off"
                    }
                ]
            }
        ]
    };
    var map = new google.maps.Map(document.getElementById("visualisation"), mapProp);

    var image = {
        url:"/Assets/map/icon.png",//url: '@Url.Content("~/Assets/map/icon.png")',
        size: new google.maps.Size(15, 15)
    };

    var contentString = '<div id="content">' +
        '<div id="siteNotice">' +
        '</div>' +
        '<h5 id="firstHeading" class="firstHeading">Toxin-medicated Diseases of S.Aureus S</h5><h6>Introduction of the infection</h6>'+
        '<div id="bodyContent">' +
        '<p><b>Prevalence: 125</b>,<br/>' +
        '<b>Mortality: 35</b>,<br/>' +
        '<b>Bateria: Staphylococcus Aureus (Anaerobic)</b>,<br/>' +
        '<b>Infection: Toxin-medicated diseases of S.Aureus include food poisoning' +
        'due to ingestion of enterotoxins, while toxic shock syndrome toxin 1 is responsible for toxic shock.,</b >,<br /></p>' +
        '<p><table style="width:100%"> <tr> <td>'+
        'Timeline: June 2005 - September 2005<br /> </td> <td>'+
        'Affected People: <Gender> and <Age><br /> </td> </tr> <tr> <td> Strain: -- <br />' +
        '    </td> <td> Taxonomy: --<br /> </td> </tr> <tr> <td> Morphology: --<br />  </td> <td> Virulence Factors: --<br />' +
        '    </td> </tr> <tr> <td> Interaction with Organisms: -- <br /> </td> <td> Antibiotics: -- <br /> </td> </tr>'+
        '<tr> <td> Treatments: -- <br /> </td>'+
        '</tr></table></p>' +
        '<p>Location: Military Hospital, Rawalpindi, Pakistan (<a href="#">Lat: 30.3, Long: 60.3</a>)</p>' +
        '<a href="#">See References</p>' +
        '</div>' +
        '</div>';

    var marker = new google.maps.Marker({
        position: { lat: 30.3, lng: 69.3 },
        map: map,
        icon: image
    });
    var infowindow = new google.maps.InfoWindow({
        content: contentString,
        maxWidth: 400
    });
    var isOpen = false;
    var isClicked = false;

    google.maps.event.addListener(infowindow, 'closeclick', function () {
        isOpen = false;
        isClicked = false;
    });

    marker.addListener('mouseover', function () {
        if (!isClicked) {
            infowindow.open(map, marker);
            isOpen = true;
        }
    });
    marker.addListener('mouseout', function () {
        if (isOpen && !isClicked) {
            isOpen = false;
            infowindow.close();
        }
    });

    marker.addListener('click', function () {
        isOpen = false;
        isClicked = true;
        infowindow.open(map, marker);
    });
}

function choropleth() {
    var mapProp = {
        center: new google.maps.LatLng(30.3, 69.3),
        zoom: 5,
        styles: [
            {
                "featureType": "administrative",
                "elementType": "geometry",
                "stylers": [
                    {
                        "visibility": "off"
                    }
                ]
            },
            {
                "featureType": "poi",
                "stylers": [
                    {
                        "visibility": "off"
                    }
                ]
            },
            {
                "featureType": "road",
                "elementType": "labels.icon",
                "stylers": [
                    {
                        "visibility": "off"
                    }
                ]
            },
            {
                "featureType": "transit",
                "stylers": [
                    {
                        "visibility": "off"
                    }
                ]
            }
        ]
    };
    var map = new google.maps.Map(document.getElementById("visualisation"), mapProp);
    var infowindow = new google.maps.InfoWindow();
    map.data.addListener('mouseover', function (event) {
        infowindow.setContent("<div style='width:auto; color: #0f0f0f'>" + 
            "<table>"+
                "<tr> <td>Location: </td><td>"+event.feature.getProperty('districts') + ", " + event.feature.getProperty('province_territory') +"</td>"+ 
                "<tr><td>Prevalence: </td><td>12</td></tr>"+
                "<tr><td>Death Rate: </td><td>13</td></tr>"+
            "</table></div>");

        //var coordOne = event.feature.getGeometry().getAt(0).getAt(0).getAt(0);
        //var newLat = (coordOne.lat() + event.latLng.lat()) / 2;
        //var newLng = (coordOne.lng() + event.latLng.lng()) / 2;
        //var newCoord = new google.maps.LatLng(newLat, newLng);

        // var heatmapData = [event.feature.getGeometry().getAt(0).getAt(0).getAt(0)];
        // var heatmap = new google.maps.visualization.HeatmapLayer({
        //     data: heatmapData
        // });
        // heatmap.setMap(map);

        infowindow.setPosition(event.latLng);
        infowindow.setOptions({ pixelOffset: new google.maps.Size(0,0) });
        infowindow.open(map);
    });
    map.data.loadGeoJson('/Assets/map/pakistan.json');//'@Url.Content("~/Assets/map/pakistan.json")');
    map.data.setStyle({
        fillColor: 'green',
        strokeWeight: 0.5
    });

    

}

function lineGraph() {
    Morris.Line({
        element: 'visualisation',
        data: [
            { x: '2018-01', y: 100 },
            { x: '2018-02', y: 0 },
            { x: '2018-03', y: 0 },
            { x: '2018-04', y: 345 },
            { x: '2018-05', y: 0 },
            { x: '2018-06', y: 200 },
            { x: '2018-07', y: 50 },
            { x: '2018-08', y: 0 }
        ],
        xkey: 'x',
        ykeys: ['y'],
        smooth: false,
        hideHover: 'auto',
        axes: true,
        grid: true,
        labels: ['Prevalence']
    });
}

function donut() {
    Morris.Donut({
        element: 'visualisation',
        data: [
            { label: "Infection 1", value: 12 },
            { label: "Infection 2", value: 30 },
            { label: "Infection 3", value: 20 }
        ]
    });
}

function scatter() {
    var regions = ['Region 1', 'Region 2', 'Region 3'];
    var trace1 = {
        x: regions,
        y: [1, 2, 3],
        mode: 'markers',
        type: 'scatter',
        name: 'Infection 1',
        // text: ['1', '2', '3'],
        marker: { size: 12 }
    };

    var trace2 = {
        x: regions,
        y: [2, 4, 6],
        mode: 'markers',
        type: 'scatter',
        name: 'Infection 2',
        marker: { size: 12 }
    };

    var trace3 = {
        x: regions,
        y: [3, 6, 9],
        mode: 'markers',
        type: 'scatter',
        name: 'Infection 3',
        marker: { size: 12 }
    };

    var data = [trace1, trace2, trace3];

    var layout = {
        xaxis: {
            range: [-1, 4]
        },
        yaxis: {
            range: [0, 10]
        },
        title: 'Prevalence at Different Regions'
    };

    Plotly.newPlot('visualisation', data, layout);
}

function barchart() {

    var visDiv = $('#visualisation');

    var barchart = document.createElement('div');
    barchart.id = 'barchart';
    barchart.setAttribute("style", "width:50%; height;100%; vertical-align: middle; text-align: center; float:left");
    visDiv[0].appendChild(barchart);

    var piechart = document.createElement('div');
    piechart.id = 'piechart';
    piechart.setAttribute("style", "width:50%; height;100%; float:right;");
    visDiv[0].appendChild(piechart);

    Morris.Bar({
        element: 'barchart',
        data: [
            { y: 'Region 1', a: 100, b:10},
            { y: 'Region 2', a: 75, b:15},
            { y: 'Region 3', a: 50, b:30}
        ],
        xkey: 'y',
        ykeys: ['a', 'b'],
        hideHover: 'auto',
        labels: ['Prevalence', 'Death Rate']
    });

    Morris.Donut({
        element: 'piechart',
        data: [
            { label: "Infection 1", value: 12 },
            { label: "Infection 2", value: 30 },
            { label: "Infection 3", value: 20 }
        ]
    });
}