$("#addEmployeeButton").click(function () {

	let family = $("#addFamilyEmp").val();
	let name = $("#addNameEmp").val();
	let mname = $("#addMnameEmp").val();
	let email = $("#addEmailEmp").val();
	let year = $("#addYearEmp").val();
    let valid = true;

	if (family === "") {
		$("#addFamilyEmp").prop("placeholder", "Заполните это поле");
		$("#addFamilyEmp").addClass("text-box__field_invalid");
        valid = false;
    }

    if (name === "") {
        $("#addNameEmp").prop("placeholder", "Заполните это поле");
        $("#addNameEmp").addClass("text-box__field_invalid");
        valid = false;
	}

	if (mname === "") {
		$("#addMnameEmp").prop("placeholder", "Заполните это поле");
		$("#addMnameEmp").addClass("text-box__field_invalid");
		valid = false;
	}

	if (email === "") {
		$("#addEmailEmp").prop("placeholder", "Заполните это поле");
		$("#addEmailEmp").addClass("text-box__field_invalid");
		valid = false;
	}

    if (year === "") {
		$("#addYearEmp").prop("placeholder", "Заполните это поле");
		$("#addYearEmp").addClass("text-box__field_invalid");
        valid = false;
    }

    if (valid) {
        $.ajax({
            type: 'GET',
			url: 'Home/AddEmployee',
			data: new Employee({ id: 0, family: family, name: name, mname: mname, email: email, year: year }),

            success: function (result) {
				$("#employees").load("Home/Employees?Page=1");
                if (!result) alert("Произошла ошибка при попытке добавить пользователя, повторите пожалуйста ваш запрос позже.");
            },

            error: function () {
				$("#employees").load("Home/Employees?Page=1");
                alert("Произошел сбой");
            }
        });
    }  
});
class Employee {

	constructor(options) {
		this.id = options.id;
		this.family = options.family;
		this.name = options.name;
		this.mname = options.mname;
		this.email = options.email;
		this.year = options.year;
	}
}