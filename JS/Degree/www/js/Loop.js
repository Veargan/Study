function Loop(base, exp) {
	var res = 1;
	base = parseInt(base);
	exp = parseInt(exp);

	for (var i = 0; i < exp; i++) {
		res *= base;
	}
	return res;
}