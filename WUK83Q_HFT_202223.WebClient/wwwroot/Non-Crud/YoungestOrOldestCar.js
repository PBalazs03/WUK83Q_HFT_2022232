let data = []

getdata();

async function getdata() {
    await fetch('http://localhost:21840/Auto/youngorold?YoungOrOld=')
        .then(x => x.json())
        .then(y => {
            data = y;
            display();
        });
}