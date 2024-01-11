function backtomain() {
    window.location.assign("index.html");
}
let concerncoll = [];
let connection;
let concernIdToUpdate = -1;
getdata();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl('http://localhost:21840/hub')
        .configureLogging(signalR.LogLevel.Information)
        .build();
    connection.on("ConcernCreated", (user, message) => {
        getdata();
    });
    connection.on("ConcernDeleted", (user, message) => {
        getdata();
    });
    connection.on("ConcernUpdated", (user, message) => {
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
        const response = await fetch('http://localhost:21840/Concern');

        if (!response.ok) {
            throw new Error(`Failed to fetch data. Status: ${response.status}`);
        }

        const data = await response.json();
        concerncoll = data;
        console.log(concerncoll);
        display();
    } catch (error) {
        console.error('Error fetching data:', error);
    }
}
function display() {
    document.getElementById('resultareaconcern').innerHTML = "";
    concerncoll.forEach(t => {
        document.getElementById('resultareaconcern').innerHTML +=
            "<tr><td>" + t.concernId
        + "</td><td>" + t.concernName
        + "</td><td>" + t.bornOfConcern
        + "</td><td>" + t.countryOfConcern
        + "</td><td>" + t.positionInRanking
        + "</td><td>" +`<button type="button" onclick="remove(${t.concernId})">Delete</button>` +
            `<button type="button" onclick="showupdate(${t.concernId})">Update</button>` +
            "</td></tr>";
        console.log(t);
    })
}
function showupdate(id) {
    document.getElementById('concernnametoupdate').value = concerncoll.find(t => t['concernId'] == id)['concernName'];
    document.getElementById('bornOfConcernToUpdate').value = concerncoll.find(t => t['concernId'] == id)['bornOfConcern'];
    document.getElementById('countryOfConcernToUpdate').value = concerncoll.find(t => t['concernId'] == id)['countryOfConcern'];
    document.getElementById('positionInRankingToUpdate').value = concerncoll.find(t => t['concernId'] == id)['positionInRanking'];

    document.getElementById('concerntoupdateformdiv').style.display = "flex";
    concernIdToUpdate = id;
}
function update() {
    document.getElementById('concerntoupdateformdiv').style.display = "none";

    let cntu = document.getElementById('concernnametoupdate').value;
    let boctu = document.getElementById('bornOfConcernToUpdate').value;
    let coctu = document.getElementById('countryOfConcernToUpdate').value;
    let pirtu = document.getElementById('positionInRankingToUpdate').value;


    fetch('http://localhost:21840/Concern', {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                concernName: cntu,
                bornOfConcern: boctu,
                countryOfConcern: coctu,
                positionInRanking: pirtu,
                concernId: concernIdToUpdate

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
    fetch('http://localhost:21840/Concern/' + id, {
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
    let cid = document.getElementById('concernId').value;
    let cname = document.getElementById('concernName').value;
    let boc = document.getElementById('bornOfConcern').value;
    let coc = document.getElementById('countryOfConcern').value;
    let pir = document.getElementById('positionInRanking').value;
    fetch('http://localhost:21840/Concern', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                concernId: cid,
                concernName: cname,
                bornOfConcern: boc,
                countryOfConcern: coc,
                positionInRanking: pir
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