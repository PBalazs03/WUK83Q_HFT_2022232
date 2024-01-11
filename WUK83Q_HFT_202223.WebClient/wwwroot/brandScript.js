function backtomain() {
    window.location.assign("index.html");
}
let brandcoll = [];
let connection;
let brandIdToUpdate = -1;
getdata();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl('http://localhost:21840/hub')
        .configureLogging(signalR.LogLevel.Information)
        .build();
    connection.on("BrandCreated", (user, message) => {
        getdata();
    });
    connection.on("BrandDeleted", (user, message) => {
        getdata();
    });
    connection.on("BrandUpdated", (user, message) => {
        getdata();
    });
    connection.onclose(async () => {
        await start();
    });
    start();
}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
        await getdata();  // Wait for data before proceeding*/
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
}
async function getdata() {
    try {
        const response = await fetch('http://localhost:21840/Brand');

        if (!response.ok) {
            throw new Error(`Failed to fetch data. Status: ${response.status}`);
        }

        const data = await response.json();
        brandcoll = data;
        console.log(brandcoll);
        display();
    } catch (error) {
        console.error('Error fetching data:', error);
    }
}
function display() {
    document.getElementById('resultareabrand').innerHTML = "";
    brandcoll.forEach(t => {
        document.getElementById('resultareabrand').innerHTML +=
            "<tr><td>" + t.brandId
        + "</td><td>" + t.brandName
        + "</td><td>"
        + t.originOfBrand + "</td><td>"
        + t.bornOfBrand + "</td><td>"
        + t.isProducingFullyElectricCars + "</td><td>"
        + t.hasFormula1Team + "</td><td>"
        + t.concernId + "</td><td>"
        + `<button type="button" onclick="remove(${t.brandId})">Delete</button>` +
            `<button type="button" onclick="showupdate(${t.brandId})">Update</button>` +
            "</td></tr>";
        console.log(t);
    })
}
function showupdate(id) {
    document.getElementById('brandnametoupdate').value = brandcoll.find(t => t['brandId'] == id)['brandName'];
    document.getElementById('originofbrandtoupdate').value = brandcoll.find(t => t['brandId'] == id)['OriginOfBrand'];
    document.getElementById('bornofbrandtoupdate').value = brandcoll.find(t => t['brandId'] == id)['BornOfBrand'];
    document.getElementById('isproducingfullyelectriccartoupdate').value = brandcoll.find(t => t['brandId'] == id)['IsProducingFullyElectricCars'];
    document.getElementById('hasformula1teamtoupdate').value = brandcoll.find(t => t['brandId'] == id)['HasFormula1Team'];
    document.getElementById('concernidtoupdate').value = brandcoll.find(t => t['brandId'] == id)['ConcernId'];

    document.getElementById('updateformdiv').style.display = "flex";
    brandIdToUpdate = id;
}
function update() {
    document.getElementById('updateformdiv').style.display = "none";
    let bname = document.getElementById('brandnametoupdate').value;
    let oobtu = document.getElementById('originofbrandtoupdate').value;
    let bobtu = document.getElementById('bornofbrandtoupdate').value;
    let ipfectu = document.getElementById('isproducingfullyelectriccartoupdate').value;
    let hfottu = document.getElementById('hasformula1teamtoupdate').value;
    let cidtu = document.getElementById('concernidtoupdate').value;
    fetch('http://localhost:21840/Brand', {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                brandName: bname,
                OriginOfBrand: oobtu,
                BornOfBrand: bobtu,
                IsProducingFullyElectricCars: ipfectu,
                HasFormula1Team: hfottu,
                ConcernId: cidtu,

                brandId: brandIdToUpdate
            }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}
function remove(id) {
    fetch('http://localhost:21840/Brand/' + id, {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json',
        },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}
function create() {
    let bid = document.getElementById('brandId').value;
    let bname = document.getElementById('brandName').value;
    let oob = document.getElementById('OriginOfBrand').value;
    let bob = document.getElementById('BornOfBrand').value;
    let ipfec = document.getElementById('IsProducingFullyElectricCars').value;
    let hfot = document.getElementById('HasFormula1Team').value;
    let cid = document.getElementById('ConcernId').value;
    fetch('http://localhost:21840/Brand', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                brandId: bid,
                brandName: bname,
                originOfBrand: oob,
                isProducingFullyElectricCars: ipfec,
                hasFormula1Team: hfot,
                concernId: cid
            }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}