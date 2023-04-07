
function DataBind(result) {
    var SetData = jQuery_3_6_1("#SetStudentData");
            for (var i = 0; i < result.length; i++) {

                var Data = "<tr class='text-center'>" +
                    "<td>" + result[i].Gr_No + "</td>" +
                    "<td>" + result[i].Student_First_Name + "</td>" +
                    "<td>" + result[i].Student_Last_Name + "</td>" +
                    "<td>" + result[i].Father_Name + "</td>" + 
                    "<td>" + result[i].Gender + "</td>" + 
                    "<td>" + result[i].Disability + "</td>" 
                    + "</tr >";

                SetData.append(Data);
            }
}
function getstudents() {
    document.getElementById("tabless").style.visibility = "initial";
    jQuery_3_6_1('#SetStudentData').empty();
    jQuery_3_6_1.get("/Admin/ViewAllStudent/?classe=" + jQuery_3_6_1("#class_select").find(":selected").text(), null, DataBind);
}

