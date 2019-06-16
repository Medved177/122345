var vacInfo = document.getElementsByClassName("user-info");

for (let i = 0; i < vacInfo.length; i++) {
	vacInfo[i].addEventListener("dblclick", ClickVacancy);
}