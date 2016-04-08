/**
 * Created by spark1435 on 3/28/2016.
 */
function btnSave_click(){
    if(validate_frm()){
        var seller = $("#sellerName").val();
        var address = $("#address").val();
        var city = $("#city").val();
        var phone = $("#phone").val();
        var email = $("#email").val();
        var make = $("#maker").val();
        var model = $("#model").val();
        var year = $("#year").val();

        var options = [seller, address, city, phone, email, make, model, year];
        var index = localStorage.getItem("index");
        if(index == null || index == ""){
            index = 1;
        }
        else{
            index++;
        }
        localStorage.setItem("row" + index, options);

        localStorage.setItem("index", index);

        window.location = './display.html';
    }
}

function validate_frm() {
    var form = $("#frm");
    form.validate({
        rules: {
            sellerName:{
                required: true
            },
            address:{
                required: true
            },
            city:{
                required: true
            },
            phone:{
                required: true,
                phonecheck: true
            },
            email:{
                required: true,
                email: true
            },
            maker:{
                required: true
            },
            model:{
                required: true
            },
            year:{
                required: true,
                number: true,
                rangelength: [4,4]
            },
        },
        messages: {
            sellerName: {
                required: "Seller Name is required"
            },
            address:{
                required: "Address is required"
            },
            city:{
                required: "City is required"
            },
            phone:{
                required: "Phone Number is required",
                phonecheck: "Valid form : 1231231234, 123-123-1234, or (123)123-1234"
            },
            email:{
                required: "Email Address is required",
                email: "Valid format is like abc@def.com"
            },
            maker:{
                required: "Vehicle Make is required"
            },
            model:{
                required: "Model is required"
            },
            year:{
                required: "Year is required",
                number: "Only numbers are alowed",
                rangelength: "Year should be 4 digits like 2010"
            },
        }
    });
    return form.valid();
}

jQuery.validator.addMethod("phonecheck", function(value, element){
        var regex = /(^\d{10}$)|(^\d{3}-\d{3}-\d{4}$)|(^\(\d{3}\)\d{3}-\d{4}$)/;
        return this.optional(element) || regex.test(value);
    },
    "1 digit, 1 cap, no special");


function init() {
    $("#btnSave").on("click", btnSave_click);
}

$(document).ready(function () {
    init();
});
