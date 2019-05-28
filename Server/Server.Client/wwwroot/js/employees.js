var empInfo = document.getElementsByClassName("user-info");

for (let i = 0; i < empInfo.length; i++) {
	empInfo[i].addEventListener("dblclick", ClickEmployee);
}