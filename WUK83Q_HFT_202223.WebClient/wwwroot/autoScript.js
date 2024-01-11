function backtomain() {
    window.location.assign("index.html");
}
let autocoll = [];
let connection;
let autoIdToUpdate = -1;
getdata();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl('http://localhost:21840/hub')
        .configureLogging(signalR.LogLevel.Information)
        .build();
    connection.on("AutoCreated", (user, message) => {
        getdata();
    });
    connection.on("AutoDeleted", (user, message) => {
        getdata();
    });
    connection.on("AutoUpdated", (user, message) => {
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
        const response = await fetch('http://localhost:21840/Auto');

        if (!response.ok) {
            throw new Error(`Failed to fetch data. Status: ${response.status}`);
        }

        const data = await response.json();
        autocoll = data;
        console.log(autocoll);
        display();
    } catch (error) {
        console.error('Error fetching data:', error);
    }
    
}
function display() {
    document.getElementById('resultareaauto').innerHTML = "";
    autocoll.forEach(t => {
        document.getElementById('resultareaauto').innerHTML +=
            "<tr><td>" + t.autoId
        + "</td><td>" + t.brand
        + "</td><td>" + t.type
        + "</td><td>" + t.vintage
        + "</td><td>" + t.ownerId
        + "</td><td>" + t.brandId
        + "</td><td>" + `<button type="button" onclick="remove(${t.autoId})">Delete</button>` +
        `<button type="button" onclick="showupdate(${t.autoId})">Update</button>` +
            "</td></tr>";
       
        console.log(t);
    })
}
function showupdate(id) {
    document.getElementById('AutoIdToUpdate').value = autocoll.find(t => t['autoId'] == id)['autoId'];
    document.getElementById('AutoBrandToUpdate').value = autocoll.find(t => t['autoId'] == id)['autoBrand'];
    document.getElementById('AutoTypeToUpdate').value = autocoll.find(t => t['autoId'] == id)['autoType'];
    document.getElementById('VintageToUpdate').value = autocoll.find(t => t['autoId'] == id)['vintage'];
    document.getElementById('OwnerIdToUpdate').value = autocoll.find(t => t['autoId'] == id)['ownerId'];
    document.getElementById('BrandIdToUpdate').value = autocoll.find(t => t['autoId'] == id)['brandId'];


    document.getElementById('updateformdiv').style.display = "flex";
    autoIdToUpdate = id;
}
function update() {
    document.getElementById('updateformdiv').style.display = "none";

    let aidu = document.getElementById('AutoIdToUpdate').value;
    let abtu = document.getElementById('AutoBrandToUpdate').value;
    let attu = document.getElementById('AutoTypeToUpdate').value;
    let vtu = document.getElementById('VintageToUpdate').value;
    let oitu = document.getElementById('OwnerIdToUpdate').value;
    let biu = document.getElementById('BrandIdToUpdate').value;

    
    fetch('http://localhost:21840/Auto', {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                autoId: aidu,
                autoBrand: abtu,
                autoType: attu,
                vintage: vtu,
                ownerId: oitu,
                brandId: biu,

                autoId: autoIdToUpdate
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
    fetch('http://localhost:21840/Auto/' + id, {
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
    let aid = document.getElementById('autoId').value;
    let abbrand = document.getElementById('autoBrand').value;
    let atype = document.getElementById('autoType').value;
    let vint = document.getElementById('vintage').value;
    let oid = document.getElementById('ownerId').value;
    let bid = document.getElementById('brandId').value;
    fetch('http://localhost:21840/Auto', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                autoId: aid,
                autoBrand: abbrand,
                autoType: atype,
                vintage: vint,
                ownerId: oid,
                brandId: bid
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