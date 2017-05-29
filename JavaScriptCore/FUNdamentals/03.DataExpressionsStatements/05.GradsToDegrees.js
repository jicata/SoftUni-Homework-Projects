function GradsToDegrees(grad) {
    grad = Number(grad[0]);
    grad = grad % 400;
    if(grad<0){
        grad+=400;
    }
    let degrees = grad * 0.9;
    console.log(degrees);
}