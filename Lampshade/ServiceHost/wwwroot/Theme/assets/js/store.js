let click = document.getElementById('button');

click.addEventListener('mousedown', () => {
    click.style.backgroundColor = "red";
    click.style.color = "#fff";
});

click.addEventListener('mouseup', () => {
    click.style.backgroundColor = "#fff";
    click.style.color = "#000";

});
click.addEventListener('touchstart', () => {
    click.style.backgroundColor = "red";
    click.style.color = "#fff";
});
click.addEventListener('touchend', () => {
    click.style.backgroundColor = "#fff";
    click.style.color = "#000";
});