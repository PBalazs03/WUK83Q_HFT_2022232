let data = []

getdata();

async function getdata() {
    await fetch('http://localhost:21840/Brand/modelsofbrand?brandName=')
        .then(x => x.json())
        .then(y => {
            data = y;
            console.log(data)
            display();
        });
}
function display() {
    document.getElementById('resultNoNCrudYOOCandRMOTB').innerHTML = "";
    data.forEach(t => {
        document.getElementById('resultNoNCrudYOOCandRMOTB').innerHTML +=
            "<tr><td>"
            + t.
    });
}