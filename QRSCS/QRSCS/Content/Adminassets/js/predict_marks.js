function DataBind(result) {
    var SetData = jQuery_3_6_1("#SetStudentData");
    
        
        var Data = "<tr class='text-center'>" +
            "<td id='gr_'>" + result.Gr_No + "</td>" +
            "<td>" + result.Student_First_Name + "</td>" +
            "<td>" + result.Student_Last_Name + "</td>" +
            "<td>" + result.Father_Name + "</td>" +
            "<td>" + result.Gender + "</td>" +
            "<td>" + result.Disability + "</td>"
        + "</tr >";
    
        SetData.append(Data);
}
function getstudent() {
    document.getElementById("tabless").style.visibility = "initial";
    jQuery_3_6_1('#SetStudentData').empty();
    jQuery_3_6_1.get("/Admin/GetTheStudent/?classe=" + jQuery_3_6_1("#_gr_no").val(), null, DataBind);
    
}

function create_csv() {
    var url = "/Editor/CSV_FILE_FOR_STA/?uid=" + jQuery_3_6_1("#gr_").text();
    jQuery_3_6_1.ajax({
        type: "POST",
        url: url,

        success: function (data) {
            if (data == "Successful") {
                jQuery_3_6_1(".alert").css("background", "#c2f3d6");
                jQuery_3_6_1(".close-btn").css("background", "#96eab8");
                jQuery_3_6_1(" .fas").css("color", "#24a058");
                jQuery_3_6_1(" .msg").css("color", "#34a56d");
                jQuery_3_6_1(" .alert").css("color", "#ff4658");
                jQuery_3_6_1(".msg").text("CSV File Created");
                jQuery_3_6_1('.alert').css({ borderLeft: '6px solid #30d375' });

                jQuery_3_6_1('.alert').addClass("show");
                jQuery_3_6_1('.alert').removeClass("hide");
                jQuery_3_6_1('.alert').addClass("showAlert");
                setTimeout(function () {
                    jQuery_3_6_1('.alert').removeClass("show");
                    jQuery_3_6_1('.alert').addClass("hide");
                }, 5000);
                jQuery_3_6_1("#button_change").text("Start Processing");
                jQuery_3_6_1("#button_change").attr("onclick", "Processing_function()");

            }
            else if (data == "UnSuccessful") {
                jQuery_3_6_1(".msg").text("No Records Found");
                 

                jQuery_3_6_1('.alert').addClass("show");
                jQuery_3_6_1('.alert').removeClass("hide");
                jQuery_3_6_1('.alert').addClass("showAlert");
                setTimeout(function () {
                    jQuery_3_6_1('.alert').removeClass("show");
                    jQuery_3_6_1('.alert').addClass("hide");
                }, 5000);
            }
        }
    });
}



function Processing_function() {
    var url = "/Editor/exec/?uid=" + jQuery_3_6_1("#gr_").text();
    jQuery_3_6_1.ajax({
        type: "POST",
        url: url,

        success: function (data) {
            if (data == "success") {
                jQuery_3_6_1(".alert").css("background", "#c2f3d6");
                jQuery_3_6_1(".close-btn").css("background", "#96eab8");
                jQuery_3_6_1(" .fas").css("color", "#24a058");
                jQuery_3_6_1(" .msg").css("color", "#34a56d");
                jQuery_3_6_1(" .alert").css("color", "#ff4658");
                jQuery_3_6_1(".msg").text("Processing Done");
                jQuery_3_6_1('.alert').css({ borderLeft: '6px solid #30d375' });

                jQuery_3_6_1('.alert').addClass("show");
                jQuery_3_6_1('.alert').removeClass("hide");
                jQuery_3_6_1('.alert').addClass("showAlert");
                setTimeout(function () {
                    jQuery_3_6_1('.alert').removeClass("show");
                    jQuery_3_6_1('.alert').addClass("hide");
                }, 5000);
                jQuery_3_6_1("#button_change").text("Generate Report");
                jQuery_3_6_1("#button_change").attr("onclick", "generate_report()");

            }
            else if (data == "unsuccesfull") {
                jQuery_3_6_1(".msg").text("Processing Not Done!");


                jQuery_3_6_1('.alert').addClass("show");
                jQuery_3_6_1('.alert').removeClass("hide");
                jQuery_3_6_1('.alert').addClass("showAlert");
                setTimeout(function () {
                    jQuery_3_6_1('.alert').removeClass("show");
                    jQuery_3_6_1('.alert').addClass("hide");
                }, 5000);
            }
        }
    });
}




function generate_report() {
    var url = "/Editor/Prediction_CSV_to/?uid=" + jQuery_3_6_1("#gr_").text();
    jQuery_3_6_1.ajax({
        type: "POST",
        url: url,

        success: function (data) {
            data = JSON.parse(data);
            dates = [];
            marks = [];
            for (var i = 0; i < data.length; i++) {
               
                var x = data[i].Date;
                x = x.split("T")[0];
                var xx = x;
                dates.push(xx);
                marks.push(data[i].Marks);
            }
           
            var optionsArea = {
                series: [
                    {
                        name: "Marks",
                        data: marks
                    }                   
                ],
                chart: {
                    id: 'yt',
                    group: 'social',
                    type: 'area',
                    height: 400
                },
                colors: ['#8274dd'],
                dataLabels: {
                    enabled: true,
                },
                stroke: {
                    show: true,
                    curve: 'smooth',
                    lineCap: 'butt',
                    colors: undefined,
                    width: 1,
                    dashArray: 0,
                },
                title: {
                    text: 'Speech Therapy Assessment Marks',
                    align: 'left'
                },
                grid: {
                    borderColor: '#e7e7e7',
                    row: {
                        colors: ['#f3f3f3', 'transparent'], // takes an array which will be repeated on columns
                        opacity: 0.5
                    },
                },
                markers: {
                    size: 1
                },
                xaxis: {
                    categories: dates,
                    title: {
                        text: 'Marks Prediction'
                    }
                },
                yaxis: {
                    title: {
                        text: 'Marks'
                    },
                    min: 0,
                    max: 100
                },
                legend: {
                    position: 'top',
                    horizontalAlign: 'right',
                    floating: true,
                    offsetY: -25,
                    offsetX: -5
                }
            };

            var chartArea = new ApexCharts(document.querySelector("#chart6"), optionsArea);
            chartArea.render();
             
             
        }
    });
}