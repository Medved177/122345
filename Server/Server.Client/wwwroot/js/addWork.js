$("#addWorkButton").click(function () {

	let name = $("#addnameWork").val();
	let Dolg = $("#addDolgWork").val();
	let experience = $("addExpWork").val();
	let employee = $("#addEmp").val();
    let valid = true;

	if (name === "") {
		$("#addnameWork").prop("placeholder", "Заполните это поле");
		$("#addnameWork").addClass("text-box__field_invalid");
        valid = false;
    }

	if (Dolg === "") {
		$("#addDolgWork").prop("placeholder", "Заполните это поле");
		$("#addDolgWork").addClass("text-box__field_invalid");
        valid = false;
	}

	if (experience === "") {
		$("#addExpWork").prop("placeholder", "Заполните это поле");
		$("#addExpWork").addClass("text-box__field_invalid");
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
			url: 'Home/AddWork',
			data: new LastWork({ id: 0, name: name, experience: experience, employee: employee }),

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
class LastWork {

	constructor(options) {
		this.id = options.id;
		this.name = options.name;
		this.experience = options.experience;
		this.employee = options.employee;
	}
}