
function GetChildren(elem) {
	let children = elem.children[0].children;
	let employee = new Employee({
		Id: children[0].value,
		Family: children[1].value,
		Name: children[2].value,
		Mname: children[3].value,
		Year: children[4].value,
		Email: children[5].value
	});
	return employee;
}

function Move(page) {
	$("#employees").load("Home/Employees?Page=" + page);
}

class Employee {

	constructor(options) {
		this.Id = options.id;
		this.Family = options.Family;
		this.Name = options.Name;
		this.Mname = options.Mname;
		this.Email = options.Email;
		this.Year = options.Year;
	}
}