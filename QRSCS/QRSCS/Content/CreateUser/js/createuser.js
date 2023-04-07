function forwardbtn() {
    const formd = document.getElementById("formmm");
    allInput = formd.querySelectorAll(".input-field input");
    var j = 0;
    for (i = 0; i <=6;i++) {
        if (allInput[i].value == "") {

            
            jQuery_3_6_1(".alert").css("background", "#ffe1e3");
            jQuery_3_6_1(".close-btn").css("background", "#fe9aa4");
            jQuery_3_6_1(" .fas").css("color", "#ff4658");
            jQuery_3_6_1(" .msg").css("color", "#ff99a4");
            jQuery_3_6_1(" .alert").css("color", "#ff4658");
            jQuery_3_6_1('.alert').css({ borderLeft: '6px solid #ff4658' });
            jQuery_3_6_1('.msg').text("Enter All Fields")
            jQuery_3_6_1('.alert').addClass("show");
            jQuery_3_6_1('.alert').removeClass("hide");
            jQuery_3_6_1('.alert').addClass("showAlert");
            setTimeout(function () {
                jQuery_3_6_1('.alert').removeClass("show");
                jQuery_3_6_1('.alert').addClass("hide");
            }, 5000);
            break;
        }
        else if (allInput[i].value != "") {
            j+= 1;;
            

        }
    };
    if (j == 7 && jQuery_3_6_1('#gen').val() == "Please Select") {
        jQuery_3_6_1(".alert").css("background", "#ffe1e3");
        jQuery_3_6_1(".close-btn").css("background", "#fe9aa4");
        jQuery_3_6_1(" .fas").css("color", "#ff4658");
        jQuery_3_6_1(" .msg").css("color", "#ff99a4");
        jQuery_3_6_1(" .alert").css("color", "#ff4658");
        jQuery_3_6_1('.alert').css({ borderLeft: '6px solid #ff4658' });
        jQuery_3_6_1('.msg').text("Select Gender")
        jQuery_3_6_1('.alert').addClass("show");
        jQuery_3_6_1('.alert').removeClass("hide");
        jQuery_3_6_1('.alert').addClass("showAlert");
        setTimeout(function () {
            jQuery_3_6_1('.alert').removeClass("show");
            jQuery_3_6_1('.alert').addClass("hide");
        }, 5000);
    }
    else if (j==7) {
     const form = document.getElementById("formmm");
   form.classList.add('secActive');
    }


}
jQuery_3_1_1("#desig").inputmask({ mask: "9999-9999999" });
function backwardbtn() {
    const form = document.getElementById("formmm");
    
    form.classList.remove('secActive');

}

jQuery_3_1_1("#NIC").inputmask({ mask: "99999-9999999-9" });

function preview_modal() {
    const previewBtn = document.getElementById("image-preview");
    previewBtn.classList.add("show");
    var a = document.getElementById('user-image');
    document.getElementById('photo-preview').src = window.URL.createObjectURL(a.files[0])
    
}
function img_modal_close() {
    const previewBtn = document.getElementById("image-preview");
    previewBtn.classList.remove("show");

}
document.getElementById("user-image").onchange = function (e) {
    document.getElementById("preview").style.visibility = "initial";    
}



