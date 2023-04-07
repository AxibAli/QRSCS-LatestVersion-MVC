 
var pap = window.location.pathname;
var papp = pap.split("/");
var pappp = "#".concat(papp[2]);
if (document.getElementById("editorview") != null) {
	document.getElementById("editorview").onclick = function (e) {
		jQuery_3_6_1(pappp).removeClass('active');
	}
}
if (document.getElementById("hearing_impaired") != null) {
	document.getElementById("hearing_impaired").onclick = function (e) {
		jQuery_3_6_1(pappp).removeClass('active');
	}
}
if (document.getElementById("update_section") != null) {
	document.getElementById("update_section").onclick = function (e) {
		jQuery_3_6_1(pappp).removeClass('active');
	}
}
if (document.getElementById("idd_disability") != null) {
	document.getElementById("idd_disability").onclick = function (e) {
		jQuery_3_6_1(pappp).removeClass('active');
	}
}
		if (document.getElementById("Visually_impared") != null) {
			document.getElementById("Visually_impared").onclick = function (e) {
		jQuery_3_6_1(pappp).removeClass('active');
	}
		}
if (document.getElementById("individualize_eplan") != null) {
	document.getElementById("individualize_eplan").onclick = function (e) {
		jQuery_3_6_1(pappp).removeClass('active');
	}
}

 

if (papp[2] == "NewAdmission" || papp[2] == "CaseHistory" || papp[2] == "ViewAllTeacherAndAssign") {
	jQuery_3_6_1("#editorview").addClass('active');
}
else if (papp[2] == "SpeechCaseHistory" || papp[2] == "AudiologyAssessment" || papp[2] == "SpeechTherapyAssessment" || papp[2] == "HIResult" || papp[2] == "Performance" || papp[2] == "Predict_Marks" ) {
	jQuery_3_6_1("#hearing_impaired").addClass('active')
}
else if (papp[2] == "OT" || papp[2] == "OT2" || papp[2] == "PT" || papp[2] == "PA" || papp[2] == "BT" || papp[2] == "IQ" || papp[2] == "IQ" || papp[2] == "IDDResult" || papp[2] == "IDDResult" || papp[2] == "Performance") {
	jQuery_3_6_1("#idd_disability").addClass('active');
}
else if (papp[2] == "AllStudentView" || papp[2] == "HIView" || papp[2] == "VIView" || papp[2] == "IDDView" ) {
	jQuery_3_6_1("#update_section").addClass('active');
}
else if (papp[2] == "VIResult" || papp[2] == "VIPerformance"  ) {
	jQuery_3_6_1("#Visually_impared").addClass('active');
}
else if (papp[2] == "IEP" || papp[2] == "ViewAllIEP"  ) {
	jQuery_3_6_1("#individualize_eplan").addClass('active');
}
else {
	jQuery_3_6_1(pappp).addClass('active');
}


// SIDEBAR DROPDOWN
const allDropdown = document.querySelectorAll('#sidebar .side-dropdown');
const sidebar = document.getElementById('sidebar');

allDropdown.forEach(item => {
	const a = item.parentElement.querySelector('a:first-child');
	a.addEventListener('click', function (e) {
		e.preventDefault();

		if (!this.classList.contains('active')) {
			allDropdown.forEach(i => {
				const aLink = i.parentElement.querySelector('a:first-child');

				aLink.classList.remove('active');
				i.classList.remove('show');
			})
		}
		 this.classList.toggle('active');
		item.classList.toggle('show');
		this.classList.add("active");
		//jQuery_3_6_1("#editorview").addClass('active');

	})
})

//jQuery_3_6_1("a").click(function () {

//	// let lst = ["Basic",'Select',"Checkbox","Radio"];
//	if (["Basic", 'Select', "Checkbox", "Radio"].includes(jQuery_3_6_1(this).text())) {
//		alert(jQuery_3_6_1(this).text());
//	}
//	else {
//		jQuery_3_6_1('a').removeClass("active");

//		jQuery_3_6_1(this).addClass("active");
//	};




//});

//jQuery_3_6_1('li > a').click(function () {
//	jQuery_3_6_1('a').removeClass();
	
//});



// SIDEBAR COLLAPSE
const toggleSidebar = document.querySelector('nav .toggle-sidebar');
const allSideDivider = document.querySelectorAll('#sidebar .divider');

if (sidebar.classList.contains('hide')) {
	allSideDivider.forEach(item => {
		item.textContent = '-'
	})
	allDropdown.forEach(item => {
		const a = item.parentElement.querySelector('a:first-child');
		// a.classList.remove('active');
		item.classList.remove('show');
	})
} else {
	allSideDivider.forEach(item => {
		item.textContent = item.dataset.text;
	})
}

toggleSidebar.addEventListener('click', function () {
	sidebar.classList.toggle('hide');

	if (sidebar.classList.contains('hide')) {
		allSideDivider.forEach(item => {
			item.textContent = '-'
		})

		allDropdown.forEach(item => {
			const a = item.parentElement.querySelector('a:first-child');
			// a.classList.remove('active');
			item.classList.remove('show');
		})
	} else {
		allSideDivider.forEach(item => {
			item.textContent = item.dataset.text;
		})
	}
})




sidebar.addEventListener('mouseleave', function () {
	if (this.classList.contains('hide')) {
		allDropdown.forEach(item => {
			const a = item.parentElement.querySelector('a:first-child');
			// a.classList.remove('active');
			item.classList.remove('show');
		})
		allSideDivider.forEach(item => {
			item.textContent = '-'
		})
	}
})



sidebar.addEventListener('mouseenter', function () {
	if (this.classList.contains('hide')) {
		allDropdown.forEach(item => {
			const a = item.parentElement.querySelector('a:first-child');
			// a.classList.remove('active');
			item.classList.remove('show');
		})
		allSideDivider.forEach(item => {
			item.textContent = item.dataset.text;
		})
	}
})




// PROFILE DROPDOWN
const profile = document.querySelector('nav .profile');
const imgProfile = profile.querySelector('img');
const dropdownProfile = profile.querySelector('.profile-link');

imgProfile.addEventListener('click', function () {
	dropdownProfile.classList.toggle('show');
})




// MENU
const allMenu = document.querySelectorAll('main .content-data .head .menu');

allMenu.forEach(item => {
	const icon = item.querySelector('.icon');
	const menuLink = item.querySelector('.menu-link');

	icon.addEventListener('click', function () {
		menuLink.classList.toggle('show');
	})
})



window.addEventListener('click', function (e) {
	if (e.target !== imgProfile) {
		if (e.target !== dropdownProfile) {
			if (dropdownProfile.classList.contains('show')) {
				dropdownProfile.classList.remove('show');
			}
		}
	}

	allMenu.forEach(item => {
		const icon = item.querySelector('.icon');
		const menuLink = item.querySelector('.menu-link');

		if (e.target !== icon) {
			if (e.target !== menuLink) {
				if (menuLink.classList.contains('show')) {
					menuLink.classList.remove('show')
				}
			}
		}
	})
})





// PROGRESSBAR
const allProgress = document.querySelectorAll('main .card .progress');

allProgress.forEach(item => {
	item.style.setProperty('--value', item.dataset.value)
})








