let data = []

getdata();

async function getdata() {
    await fetch('http://localhost:21840/Brand/modelsofbrand?brandName=')
        .then(x => x.json())
        .then(y => {
            data = y;
            display();
        });
}