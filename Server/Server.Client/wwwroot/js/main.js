function Move(page, filter) {
	if (filter != undefined) $("#Employee").load("Home/Employee?Page=" + page + "&Filter=" + filter);
	else $("#Employee").load("Home/Employee?Page=" + page);
}