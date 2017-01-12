function Ball(x, y) {
	this.posX = x;
	this.posY = y;
	this.radius = getRandomInt(10, 20);
	this.color = getRandomColor();
	this.dx = getRandomInt(-8, 8);
	this.dy = getRandomInt(-8, 8);

	this.checkHit = function() {
		this.posX += this.dx;
		this.posY += this.dy;

		if ((this.posX - this.radius <= 0) || this.posX + this.radius > canvas.width) {
			this.dx = -this.dx;
		}  
		if ((this.posY - this.radius <= 0) || this.posY + this.radius > canvas.height) {
			this.dy = -this.dy;
		}
	};

	this.drawBall = function(context) {
		context.fillStyle = this.color;
		context.beginPath();
		context.arc(this.posX, this.posY, this.radius, 0, Math.PI * 2, true);
		context.fill();
		context.closePath();
	};
}