function BallList() {
	this.ballArray = new Array(0);

	this.add = function (Ball) {
		var newArray = new Array(this.ballArray.length + 1);
		for (var i = 0; i < this.ballArray.length; i++) {
			newArray[i] = this.ballArray[i];
		}
		newArray[this.ballArray.length] = Ball;

		this.ballArray = newArray;
	};

	this.update = function(Context) {
		for (var i = 0; i < this.ballArray.length; i++) {
			this.ballArray[i].checkHit();
			this.ballArray[i].drawBall(Context);
		}
	};
}