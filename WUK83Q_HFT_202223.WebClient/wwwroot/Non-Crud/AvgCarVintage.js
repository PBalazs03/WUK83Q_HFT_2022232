function backtomain() {
    window.location.assign("index.html");
}

let data = []

getdata();

async function getdata() {
    await fetch('http://localhost:21840/Auto/average')
        .then(x => x.json())
        .then(y => {
            data = y;
            console.log(data)
            display();
        });
}

function display() {
    document.getElementById('resultNoNCrudAvgCarAge').innerHTML = "";
    data.forEach(d => {
        document.getElementById('resultNoNCrudAvgCarAge').innerHTML +=
            "<tr><td>"
            + d.y + "</td></tr>";
    });
}