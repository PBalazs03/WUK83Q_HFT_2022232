function backtomain() {
    window.location.assign("index.html");
}
let ownerncoll = [];
let connection;
let ownerIdToUpdate = -1;
getdata();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl('http://localhost:21840/hub')
        .configureLogging(signalR.LogLevel.Information)
        .build();
    connection.on("OwnerCreated", (user, message) => {
        getdata();
    });
    connection.on("OwnerDeleted", (user, message) => {
        getdata();
    });
    connection.on("OwnerUpdated", (user, message) => {
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
        const response = await fetch('http://localhost:21840/Owner');

        if (!response.ok) {
            throw new Error(`Failed to fetch data. Status: ${response.status}`);
        }

        const data = await response.json();
        ownerncoll = data;
        console.log(ownerncoll);
        display();
    } catch (error) {
        console.error('Error fetching data:', error);
    }
}
function display() {
    document.getElementById('resultareaowner').innerHTML = "";
    ownerncoll.forEach(t => {
        document.getElementById('resultareaowner').innerHTML +=
            "<tr><td>" + t.ownerId
        + "</td><td>" + t.name
        + "</td><td>" + t.birthDate
        + "</td><td>" + t.birthPlace
        + "</td><td>" + `<button type="button" onclick="remove(${t.ownerId})">Delete</button>` +
            `<button type="button" onclick="showupdate(${t.ownerId})">Update</button>` +
            "</td></tr>";
        console.log(t);
    })
}
function showupdate(id) {
    document.getElementById('ownernametoupdate').value = ownerncoll.find(t => t['OwnerId'] == id)['name'];
    document.getElementById('birthdatetoupdate').value = ownerncoll.find(t => t['OwnerId'] == id)['birthDate'];
    document.getElementById('birthplacetoupdate').value = ownerncoll.find(t => t['OwnerId'] == id)['birthPlace'];

    document.getElementById('ownerupdateformdiv').style.display = "flex";
    ownerIdToUpdate = id;
}
function update() {
    document.getElementById('ownerupdateformdiv').style.display = "none";

    let ontu = document.getElementById('ownernametoupdate').value;
    let bdtu = document.getElementById('birthdatetoupdate').value;
    let bptu = document.getElementById('birthplacetoupdate').value;
    fetch('http://localhost:21840/Owner', {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                name: ontu,
                birthDate: bdtu,
                birthPlace: bptu,
                OwnerId: ownerIdToUpdate
                

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
    fetch('http://localhost:21840/Owner/' + id, {
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
    let oid = document.getElementById('ownerId').value;
    let nam = document.getElementById('name').value;
    let bd = document.getElementById('birthDate').value;
    let bp = document.getElementById('birthPlace').value;
    fetch('http://localhost:21840/Owner', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                ownerId: oid,
                name: nam,
                birthDate: bd,
                birthPlace: bp

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