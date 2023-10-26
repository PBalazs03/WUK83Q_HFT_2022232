let autos = [];

fetch('http://localhost:21840/auto')
    .then(x => x.json())
    .then(y => {
        autos = y;
        console.log(autos);
        display();
    });



function display() {
    autos.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.AutoId + "</td><td>" + t.Brand + "</td><td>" + t.Type + "</td><td>" + t.Vintage + "</td><td>" + t.OwnerId + "</td></tr>";
        console.log(t.AutoId)
    });
}