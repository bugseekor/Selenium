/**
 * Created by spark1435 on 4/1/2016.
 */

function LastOne() {

    var htmlCode = "";
    var linkText = "";

    var options = "";
    var index = localStorage.getItem("index");

    if(index == null || index == ""){
        return;
    }
    else{
        options = localStorage.getItem("row" + index);
    }
    var columns = options.split(",");

    var seller = columns[0];
    var address = columns[1];
    var city = columns[2];
    var phone = columns[3];
    var email = columns[4];
    var make = columns[5];
    var model = columns[6];
    var year = columns[7];

    htmlCode += "<table border=\"1\" style=\"border-collapse:collapse\">";
    htmlCode += "<tr><td>ID</td><td>Seller</td><td>Address</td>" +
        "<td>City</td><td>Phone</td><td>Email</td><td>Make</td>" +
        "<td>Model</td><td>Year</td></tr>"

    htmlCode += "<tr><td>" + index + "</td>" +
        "<td>" + seller + "</td>" +
        "<td>" + address + "</td>" +
        "<td>" + city + "</td>" +
        "<td>" + phone + "</td>" +
        "<td>" + email + "</td>" +
        "<td>" + make + "</td>" +
        "<td>" + model + "</td>" +
        "<td>" + year + "</td></tr>";

    htmlCode += "</table>";

    linkText = "<a id=\"link\" href=\"http://www.jdpower.com/cars/search/" +
        year + "-" + make + "-" + model + "/" +
        make + "/" + model + "/non-awardees-included/any-rating/" +
        year + "//all-msrp-ranges/all-mpg-ranges/\">" +
        "http://www.jdpower.com/cars/search/" +
        year + "-" + make + "-" + model + "/" +
        make + "/" + model + "/non-awardees-included/any-rating/" +
        year + "//all-msrp-ranges/all-mpg-ranges/" + "</a>";

    var lastRow = $("#lastRow");
    lastRow = lastRow.html(htmlCode);

    var link = $("#link");
    link = link.html(linkText);
}

$(document).ready(function () {
    LastOne();
});