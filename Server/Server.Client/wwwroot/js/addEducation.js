$("#addEducationButton").click(function () {

	let type = $("#addTypeEduc").val();
	let university = $("#addUniverEduc").val();
	let specialty = $("addSpecialEduc").val();
	let view = $("#addViewEduc").val();
	let employee = $("#addEmp").val();
    let valid = true;

	if (type === "") {
		$("#addTypeEduc").prop("placeholder", "Заполните это поле");
		$("#addTypeEduc").addClass("text-box__field_invalid");
        valid = false;
    }

	if (university === "") {
		$("#addUniverEduc").prop("placeholder", "Заполните это поле");
		$("#addUniverEduc").addClass("text-box__field_invalid");
        valid = false;
	}

	if (specialty === "") {
		$("#addSpecialEduc").prop("placeholder", "Заполните это поле");
		$("#addSpecialEduc").addClass("text-box__field_invalid");
		valid = false;
	}

	if (view === "") {
		$("#addViewEduc").prop("placeholder", "Заполните это поле");
		$("#addViewEduc").addClass("text-box__field_invalid");
		valid = false;
	}

	if (employee === "") {
		$("#addEmp").prop("placeholder", "Заполните это поле");
		$("#addEmp").addClass("text-box__field_invalid");
        valid = false;
    }

    if (valid) {
        $.ajax({
            type: 'GET',
			url: 'Home/AddEducation',
			data: new Education({ id: 0, type: type, university: university, specialty: specialty, view: view, employee: employee }),

            success: function (result) {
				$("#employees").load("Home/Employees?Page=1");
                if (!result) alert("Произошла ошибка при попытке добавить образование, повторите пожалуйста ваш запрос позже.");
            },

            error: function () {
				$("#employees").load("Home/Employees?Page=1");
                alert("Произошел сбой");
            }
        });
    }  
});
class Education {

	constructor(options) {
		this.id = options.id;
		this.type = options.type;
		this.university = options.university;
		this.specialty = options.specialty;
		this.view = options.view;
		this.employee = options.employee;
	}
}