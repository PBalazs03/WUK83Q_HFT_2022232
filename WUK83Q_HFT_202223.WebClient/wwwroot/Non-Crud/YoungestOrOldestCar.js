let data = []

getdata();

async function getdata() {
    let YoO = document.getElementById('YoO').nodeValue;
    await fetch('http://localhost:21840/Auto/youngorold?YoungOrOld=')
        .then(x => x.json())
        .then(y => {
            data = y;
            console.log(data)
            display();
        });
}





function display() {
    document.getElementById('resultNoNCrudYOOC').innerHTML = "";
    data.forEach(t => {
        document.getElementById('resultNoNCrudYOOC').innerHTML +=
            "<tr><td>"
            + t.

                console.log(t);
    });
}

