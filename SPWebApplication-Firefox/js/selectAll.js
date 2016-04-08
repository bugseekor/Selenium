/**
 * Created by spark1435 on 4/1/2016.
 */

function displayAll() {

    var htmlCode = "";

    htmlCode += "<table border=\"1\" style=\"border-collapse:collapse\">";
    htmlCode += "<tr><td>ID</td><td>Seller</td><td>Address</td>" +
            "<td>City</td><td>Phone</td><td>Email</td><td>Make</td>" +
            "<td>Model</td><td>Year</td></tr>"

    var index = localStorage.getItem("index");
    var options = "";

    if(index == null || index == ""){
        return;
    }

    for (var i = 1; i <= index; i++) {
        options = localStorage.getItem("row" + i);
        var columns = options.split(",");

        var seller = columns[0];
        var address = columns[1];
        var city = columns[2];
        var phone = columns[3];
        var email = columns[4];
        var make = columns[5];
        var model = columns[6];
        var year = columns[7];

        htmlCode += "<tr><td>" + i + "</td>" +
            "<td>" + seller + "</td>" +
            "<td>" + address + "</td>" +
            "<td>" + city + "</td>" +
            "<td>" + phone + "</td>" +
            "<td>" + email + "</td>" +
            "<td>" + make + "</td>" +
            "<td>" + model + "</td>" +
            "<td>" + year + "</td></tr>";
    }
    htmlCode += "</table>";

    var fullList = $("#fullList");
    fullList = fullList.html(htmlCode);
}

function btnClear_click(){
    localStorage.clear();
    location.reload();
}

$(document).ready(function () {
    $("#clear").on("click", btnClear_click);
    displayAll();
});