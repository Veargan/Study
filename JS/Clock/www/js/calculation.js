function calculate(hour, min) {
	var res;
	hour = parseInt(hour);
	min = parseInt(min);

	res = hour % 12 * 30 - 5.5 * min;
	if (res > 189) {
		res -= 360;
	} else if (res < -180) {
		res += 360;
	} 

	return Math.abs(res);
}