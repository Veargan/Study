QUnit.test("calculate should correct value plus", function(assert) {
	assert.equal(1, calculate(-4, 5, "+"), "Plus test succeed");
});

QUnit.test("calculateShouldReturnCorrectValuePlus", function(assert) {
	assert.equal(-2, calculate(3, 5, "-"), "Minus test succeed");
});

QUnit.test("calculateShouldReturnCorrectValueMultiply", function(assert) {
	assert.equal(15, calculate(5, 3, "*"), "Multiply test succed");
});

QUnit.test("calculateShouldReturnCorrectValueDivide", function(assert) {
	assert.equal(0.5, calculate(1, 2, "/"), "Divide test succeed");
});