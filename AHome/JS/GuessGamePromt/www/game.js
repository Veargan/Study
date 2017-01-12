var rand = Math.floor(Math.random() * 100) + 1;
var count = 5;

function startGame() {
	var guessVal = prompt(" Guess 1 thru 100 ","");
	if ((count <= 5) && (count >= 1) && (guessVal)) {
		count--;
		if (guessVal < rand) {
			alert("Hotter... " + count + " attempts left. " + rand);
		}
		if (guessVal > rand) {
			alert("Colder... " + count + " attempts left. " + rand);
		}
		if (guessVal == rand) {
			alert("You guessed the correct number!");
			restart();
			return false;
		}
		if (count === 0) {
			alert("You loose. " + count + " attempts left. Correct number was " + rand);
			restart();
			return false;
		}
	}
	return startGame();
}

function restart() {
	count = 5;
	rand = Math.floor(Math.random() * 100) + 1;
}