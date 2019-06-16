function ClickVacancy(event) {
	let elem = event.currentTarget;
	let vacancy = GetChildren(elem);
	$("#section").load("Home/test", vacancy);
}
function GetChildren(elem) {
	let children = elem.children[0].children;
	let vacancy = new Vacancy({
		id: children[0].value,
		name: children[1].value,
		salary: children[2].value,
		education: children[3].value,
		experience: children[4].value,
		know: children[5].value,
		task: children[6].value
	});
	return vacancy;
}

function Move(page) {
	$("#vacancy").load("Home/Vacancy?Page=" + page);
}

class Vacancy {

	constructor(options) {
		this.id = options.id;
		this.name = options.name;
		this.salary = options.salary;
		this.education = options.education;
		this.experience = options.experience;
		this.know = options.know;
		this.task = options.task;
	}
}