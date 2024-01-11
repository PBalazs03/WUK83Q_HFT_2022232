let data = []

getdata();

async function getdata() {
    await fetch('http://localhost:21840/Concern/mostbrandconcern')
        .then(x => x.json())
        .then(y => {
            data = y;
            display();
        });
}

function display() {
    document.getElementById('resultNoNCrudBrandWTMC').innerHTML = "";
    data.forEach(d => {
        document.getElementById('resultNoNCrudBrandWTMC').innerHTML +=
            "<tr><td>"
            + d.concernName + "</td></tr>";
    });
}