var canvas = document.getElementById('canvas');
var context = canvas.getContext('2d'); 

var ball = {};
ball.x = 250;
ball.y = 450;
ball.radius = 6;
ball.startAngle = 0;
ball.endAngle = Math.PI * 2;
ball.color = 'rgb(10,10,150)';
ball.speed = 4;
ball.dx = ball.speed;
ball.dy = - ball.speed;

var tx = ball.x, ty = ball.y;

function drawBall() {
    context.fillStyle = ball.color;
    context.beginPath();
    context.arc( ball.x,  ball.y, ball.radius, 0,Math.PI * 2 , true);
    context.fill();
    context.closePath();
}

function convertToGrad (rad) {
    return Math.PI/180*rad;
}

function checkHit(){ 
    if (ball.x - ball.radius < 0){
        ball.dx = ball.speed;
    }  
    if (ball.x + ball.radius > canvas.width){
        ball.dx = - Math.abs(ball.speed);
        } //right wall 
        if (ball.y - ball.radius < 0){
            ball.dy = ball.speed;
        }
        if (ball.y +  ball.radius + ball.speed > canvas.height ) {


        }
    }

    var   angle =  function  (rad) {
        return Math.PI/180*rad;
    };

    ball.dx = Math.sin(angle(135))* ball.speed;
    ball.dy = Math.cos(angle(135))* ball.speed;
    function animation() {
        // context.clearRect(0,0,500,500);  // clear canvas
        console.log ('dx ' + ball.dx + ' dy ' + ball.dy);
        ball.x += ball.dx  ;
        ball.y += ball.dy  ;

        checkHit();
        drawBall();
        requestAnimationFrame(animation);
    }
    animation();