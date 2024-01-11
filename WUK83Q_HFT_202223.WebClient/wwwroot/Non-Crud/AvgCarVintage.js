let data = []

getdata();

async function getdata() {
    await fetch('http://localhost:21840/Auto/average')
        .then(x => x.json())
        .then(y => {
            data = y;
            display();
        });
}

function display() {
    document.getElementById('resultNoNCrudAvgCarAge').innerHTML = "";
    data.forEach(d => {
        document.getElementById('resultNoNCrudAvgCarAge').innerHTML +=
            "<tr><td>"
            + d.data + "</td></tr>";
    });
}