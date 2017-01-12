var rand = Math.floor(Math.random() * 100) + 1;
var guessInput = document.getElementById("guessInput");
var count = 5;

function checkGuess() {
	var guessVal = parseInt(guessInput.value);
	if ((count <= 5) && (count >= 1) && (guessVal)) {
		count--;
		if (guessVal < rand) {
			alert("Hotter... " + count + " attempts left." + rand);
		}
		if (guessVal > rand) {
			alert("Colder... " + count + " attempts left." + rand);
		}
		if (guessVal === rand) {
			alert("You guessed the correct number!");
		}
		if (count === 0) {
			alert("You loose. " + count + " attempts left. Correct number was " + rand);
		}
	}
	return false;
}