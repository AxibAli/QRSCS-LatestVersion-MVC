
function Account_info_Function(a, b, c, d, e) {
	var options = {
		series: [a, b, c, d, e],
		chart: {
			width: 400,
			type: 'donut',

		},
		plotOptions: {
			pie: {
				startAngle: -90,
				endAngle: 270
			}
		},
		labels: ["Super-Admin", "Admin", "Teachers", "Students", "Staff"],
		dataLabels: {
			enabled: false
		},
		fill: {
			type: 'gradient',
		},
		legend: {
			formatter: function (val, opts) {

				return val + " : " + opts.w.globals.series[opts.seriesIndex]
			}
		},

		responsive: [{
			breakpoint: 450,
			options: {
				chart: {
					height: 400,
					width: 450
				},
				legend: {
					position: 'top'
				}
			}
		}]
	};

	var chart = new ApexCharts(document.querySelector("#chart"), options);
	chart.render();

}

// APEXCHART



//chart2
function disability_chart(a, b, c) {
	var options1 = {
		colors: ['#ff4560', '#13e090', '#775dd0'],
		series: [{
			name: 'Count',
			data: [a, b, c]
		}],
		chart: {

			height: 300,
			type: 'bar',
			events: {
				click: function (chart, w, e) {
					// console.log(chart, w, e)
				}
			}
		},

		plotOptions: {
			bar: {
				columnWidth: '50%',
				distributed: true,
			}
		},

		dataLabels: {
			enabled: true
		},
		legend: {
			show: true
		},
		xaxis: {
			categories: [
				['HI', 'DISABLED'],
				['VI', 'DISABLED'],
				['IDD', 'DISABLED'],

			],
			labels: {
				style: {

					fontSize: '12px'
				}
			}
		}

	};

	var chart1 = new ApexCharts(document.querySelector("#chart1"), options1);
	chart1.render();

}

//chart3
function Students_Record(a, b, c, d, e, f, g, h, i, j) {
var options2 = {

	series: [{
		name: 'Count',
		data: [a, b, c, d, e, f, g, h, i, j]
	}],
	chart: {

		height: 300,
		type: 'bar',
		events: {
			click: function (chart, w, e) {
				// console.log(chart, w, e)
			}
		}
	},

	plotOptions: {
		bar: {
			columnWidth: '75%',
			distributed: true,
		}
	},

	dataLabels: {
		enabled: true
	},
	legend: {
		show: false
	},
	xaxis: {
		categories: [
			['Class', '1'],
			['Class', '2'],
			['Class', '3'],
			['Class', '4'],
			['Class', '5'],
			['Class', '6'],
			['Class', '7'],
			['Class', '8'],
			['Class', '9'],
			['Class', '10'],


		],
		labels: {
			style: {

				fontSize: '12px'
			}
		}
	}

};

var chart1 = new ApexCharts(document.querySelector("#chart2"), options2);
chart1.render();
}


//chart4
function Disability_Comparison(a,b,c,d,e) {
	var options = {
		series: [a, b, c,d,e],
		chart: {
			width: 400,
			type: 'donut',

		},
		plotOptions: {
			pie: {
				startAngle: -90,
				endAngle: 270
			}
		},
		labels: ["HI DISABLED", "VI DISABLED", "IDD DISABLED", "P.H DISABLED", "C.P DISABLED"],
		dataLabels: {
			enabled: false
		},
		fill: {
			type: 'gradient',
		},
		legend: {
			formatter: function (val, opts) {

				return val + " : " + opts.w.globals.series[opts.seriesIndex]
			}
		},

		responsive: [{
			breakpoint: 450,
			options: {
				chart: {
					height: 400,
					width: 450
				},
				legend: {
					position: 'top'
				}
			}
		}]
	};

	var chart = new ApexCharts(document.querySelector("#chart3"), options);
	chart.render();
}
function generateDayWiseTimeSeries(baseval, count, yrange) {
	var i = 0;
	var series = [];
	while (i < count) {
		var x = baseval;
		var y =
			Math.floor(Math.random() * (yrange.max - yrange.min + 1)) + yrange.min;

		series.push([x, y]);
		baseval += 86400000;
		i++;
	}
	return series;
};
var parts = '2014-04-03'.split('-');
// Please pay attention to the month (parts[1]); JavaScript counts months from 0:
// January - 0, February - 1, etc.
var mydate = new Date(parts[0], parts[1] - 1, parts[2]); 

var optionsArea = {
	series: [{
		name: "Marks",
		data: [[mydate, 34], [mydate, 54], [mydate, 23]]
	}],
	chart: {
		id: 'yt',
		group: 'social',
		type: 'area',
		height: 400
	},
	stroke: {
		show: true,
		curve: 'smooth',
		lineCap: 'butt',
		colors: undefined,
		width: 1,
		dashArray: 0,
	},
	legend: {
		position: 'top',
		horizontalAlign: 'right',
		floating: true,
		offsetY: -25,
		offsetX: -5
	},
	colors: ['#8274dd']
};

var chartArea = new ApexCharts(document.querySelector("#chart6"), optionsArea);
chartArea.render();