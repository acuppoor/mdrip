function addListenerToResults() {
    var infectionResults = document.getElementsByClassName('infection_result_row');
    for (var i = 0; i < infectionResults.length; i++) {
        var item = infectionResults[i];
        item.addEventListener('click', function () {
            document.getElementById('infections_div').innerHTML += " <span class='badge badge-danger selectedInfection'>" + $(this).attr('data-name') + "</span> ";
            toggleInfectionsAndRegions("selectedInfection");
        });
    }

    var regionResults = document.getElementsByClassName('region_result_row');
    for (var i = 0; i < regionResults.length; i++) {
        var item = regionResults[i];
        item.addEventListener('click', function () {
            document.getElementById('regions_div').innerHTML += " <span class='badge badge-danger selectedRegion'>" + $(this).attr('data-name') + "</span> ";
            toggleInfectionsAndRegions("selectedRegion");
        });
    }

}

function toggleInfectionsAndRegions(className) {
    var items = document.getElementsByClassName(className);

    if (items === null) {
        items = $('.' + className);
    }
    for (var i = 0; i < items.length; i++) {
        items[i].addEventListener('click', function(event) {
            $(this).toggleClass("badge-danger");
            $(this).toggleClass("badge-neutral");
        });
    }
}


$('#chartSelection').change(function() {
    var element = $('#chartSelection');
    var selected = element.val();
    resetVisualisation();
    switch (selected) {
        case "Pie Chart":
            donut();
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
        infowindow.setContent("<div style='width:150px; text-align: center;'>" + "Test" + "</div>");

        //var coordOne = event.feature.getGeometry().getAt(0).getAt(0).getAt(0);
        //var newLat = (coordOne.lat() + event.latLng.lat()) / 2;
        //var newLng = (coordOne.lng() + event.latLng.lng()) / 2;
        //var newCoord = new google.maps.LatLng(newLat, newLng);

        infowindow.setPosition(event.latLng);
        infowindow.setOptions({ pixelOffset: new google.maps.Size(0,0) });
        infowindow.open(map);
    });
    map.data.loadGeoJson('/Assets/map/pakistan.json');//'@Url.Content("~/Assets/map/pakistan.json")');
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
            { label: "Infection 4", value: 20 },
            { label: "Infection 5", value: 20 }
        ]
    });
}

function scatter() {
    var regions = ['Region1', 'Region2', 'Region3', 'Region4', 'Region5', 'Region6'];
    var trace1 = {
        x: regions,
        y: [1, 2, 3, 4, 5],
        mode: 'markers',
        type: 'scatter',
        name: 'Infection A',
        text: ['A-1', 'A-2', 'A-3', 'A-4', 'A-5'],
        marker: { size: 12 }
    };

    var trace2 = {
        x: regions,
        y: [1, 3, 4, 5, 6],
        mode: 'markers',
        type: 'scatter',
        name: 'Infection B',
        text: ['B-a', 'B-b', 'B-c', 'B-d', 'B-e'],
        marker: { size: 12 }
    };

    var data = [trace1, trace2];

    var layout = {
        xaxis: {
            range: [-1, 6]
        },
        yaxis: {
            range: [0, 8]
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
            { y: 'Islamabad', a: 100},
            { y: 'Region 2', a: 75},
            { y: 'Region 3', a: 50},
            { y: 'Region 4', a: 75},
            { y: 'Region 5', a: 50},
            { y: 'Region 6', a: 75},
            { y: 'Region 7', a: 100 }
        ],
        xkey: 'y',
        ykeys: ['a'],
        hideHover: 'auto',
        labels: ['Prevalence']
    });

    Morris.Donut({
        element: 'piechart',
        data: [
            { label: "Infection 1", value: 12 },
            { label: "Infection 2", value: 30 },
            { label: "Infection 4", value: 20 },
            { label: "Infection 5", value: 20 }
        ]
    });
}