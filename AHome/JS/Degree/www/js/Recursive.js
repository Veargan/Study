function Recursive(base, exp) {
	var res;
	base = parseInt(base);
	exp = parseInt(exp);

	if (exp != 1) {
		return base*Recursive(base, exp-1);
	} else {
		return base;
	}
}