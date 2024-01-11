function backtomain() {
    window.location.assign("index.html");
}


let noncrudcoll01 = [];


//async function ReadYoungestOrOldestCar(YoungOrOld) {
//    document.getElementById('statisticsTitle').innerHTML =
//        '<h2>Youngest or oldest car' + YoungOrOld + '</h2>';
//    document.getElementById('youngestOrOldestCarresults').style.display = 'block';
//    await fetch('http://localhost:21840/Auto/youngorold?YoungOrOld=' + YoungOrOld)
//        .then(x => x.json())
//        .then(y => {
//            displayYoungestOrOldestCar(y, 'youngestOrOldestCarresults');
//            console.log(y)
//        });
//}

//async function ReadModelsOfTheBrand(brandName) {
//    document.getElementById('statisticsTitle').innerHTML =
//        '<h2>Models of the this brand: ' + brandName + '</h2>';
//    document.getElementById('MOTBResults').style.display = 'block';
//    await fetch('http://localhost:21840/Brand/modelsofbrand?brandName=' + brandName)
//        .then(x => x.json())
//        .then(y => {
//            displayModelsOFB(y, 'MOTBResults');
//        });
//}

//async function ReadAvgCarAge() {
//    document.getElementById('statisticsTitle').innerHTML =
//        '<h2>Average car age</h2>';
//    document.getElementById('AvgCarAgeResults').style.display = "block";
//        await fetch('http://localhost:21840/Auto/average')
//            .then(x => x.json())
//            .then(y => {
//                displayAvgCarAge(y, 'AvgCarAgeResults');
//            });
//}

//async function ReadBrandWithTheMostCars() {
//    document.getElementById('statisticsTitle').innerHTML =
//        '<h2>Brand with the most cars</h2>';
//    document.getElementById('brandWTMCResults').style.display = "block";
//    await fetch('http://localhost:21840/Brand/brandwiththemostcars')
//        .then(x => x.json())
//        .then(y => {
//            displayWTMC(y, 'brandWTMCResults');
//        });

//}

//async function ReadConcernWithTheMostBrand() {
//    document.getElementById('statisticsTitle').innerHTML =
//        '<h2>Concern with the most cars</h2>';
//    document.getElementById('concernWTMBResults').style.display = 'block';
//    await fetch('http://localhost:21840/Concern/mostbrandconcern')
//        .then(x => x.json())
//        .then(y => {
//            displayMBC(y, 'concernWTMBResults');
//        });
//}


//function displayYoungestOrOldestCar(y, contId) {          // auto
//    const container = document.getElementById(contId);
//    let htmlContent = '<ul>';
//    y.forEach(t => {
//        htmlContent +=
//            "<tr><td>" + t.autoId +
//            "</td><td>" + t.brand +
//            "</td></tr>" + t.type +
//            "</td></tr>" + t.vintage +
//            "</td></tr>" + t.ownerId + "</td></tr>";
//        htmlContent += '</ul>';
//        container.innerHTML = htmlContent;
//    });
//}

//function displayModelsOFB(y, contId) {          // brand
//    const container = document.getElementById(contId);
//    let htmlContent = '<ul>';
//    y.forEach(t => {
//        htmlContent += "<tr><td>" + t.type + "</td><td>";
//    });
//    htmlContent += '</ul>';
//    container.innerHTML = htmlContent;
//}

//function displayWTMC(y, contId) {          // brand

//    const container = document.getElementById(contId);
//    container.innerHTML = `<p>Brand with the most cars: ${y}</p>`;
//}

//function displayAvgCarAge(y, contId) {          // auto

//    const container = document.getElementById(contId);
//    container.innerHTML = `<p>Average car vintage: ${y}</p>`;
//}

//function displayMBC(y, contId) {          // concern
//    const container = document.getElementById(contId);
//    container.innerHTML = `<p>Concern with the most brands: ${y}</p>`;
//}


async function NonCrudYOOC() {
    await fetch('http://localhost:21840/Auto/youngorold?YoungOrOld=')
        .then(x => x.json())
        .then(y => {
            noncrudcoll01 = y;
            console.log(noncrudcoll01)
            display012();
        });
}

async function NonCrudRMOTB() {
    await fetch('http://localhost:21840/Brand/modelsofbrand?brandName=')
        .then(x => x.json())
        .then(y => {
            noncrudcoll01 = y;
            console.log(noncrudcoll01)
            display012();
        });
}

function display012() {
    document.getElementById('NonCrudAvgCarAgeFORM3').style.display = "none";
    document.getElementById('NonCrudBrandWTMCFORM4').style.display = "none";
    document.getElementById('NonCrudConcernWTMBFORM5').style.display = "none";

    document.getElementById('NonCrudYOOCandRMOTBFORM1').style.display = "initial";
    document.getElementById('resultNoNCrudYOOCandRMOTB').innerHTML = "";
    noncrudcoll01.forEach(t => {
        document.getElementById('resultNoNCrudYOOCandRMOTB').innerHTML +=
            "<tr><td>" + t.autoId
            + "</td><td>" + t.brand
            + "</td><td>" + t.type
            + "</td><td>" + t.vintage
            + "</td><td>" + t.ownerId
            + "</td><td>" + t.brandId
            + "</td></td>";
        console.log(t);
    })
}

async function NonCrudAvgCarAge() {
    await fetch('http://localhost:21840/Auto/average')
        .then(x => x.json())
        .then(y => {
            noncrudcoll01 = y;
            console.log(noncrudcoll01)
            display03();
        });
}

function display03() {
    document.getElementById('NonCrudYOOCandRMOTBFORM1').style.display = "none";
    document.getElementById('NonCrudBrandWTMCFORM4').style.display = "none";
    document.getElementById('NonCrudConcernWTMBFORM5').style.display = "none";

    document.getElementById('NonCrudAvgCarAgeFORM3').style.display = "initial";
    document.getElementById('resultNoNCrudAvgCarAge').innerHTML = "";
    noncrudcoll01.forEach(t => {
        document.getElementById('resultNoNCrudAvgCarAge').innerHTML +=
            + "</td><td>" + t.vintage
            + "</td></td>";
        console.log(t);
    })
}

async function NonCrudBrandWTMC() {
    await fetch('http://localhost:21840/Brand/brandwiththemostcars')
        .then(x => x.json())
        .then(y => {
            noncrudcoll01 = y;
            console.log(noncrudcoll01)
            display04();
        });
}

function display04() {
    document.getElementById('NonCrudYOOCandRMOTBFORM1').style.display = "none";
    document.getElementById('NonCrudAvgCarAgeFORM3').style.display = "none";
    document.getElementById('NonCrudConcernWTMBFORM4').style.display = "none";

    document.getElementById('NonCrudBrandWTMCFORM5').style.display = "initial";
    document.getElementById('resultNoNCrudBrandWTMC').innerHTML = "";
    noncrudcoll01.forEach(t => {
        document.getElementById('resultNoNCrudBrandWTMC').innerHTML +=
            "<tr><td>"
            + t.brand + "</td></tr>";
        console.log(t);
    })
}

async function NonCrudConcernWTMB() {
    await fetch('http://localhost:21840/Concern/mostbrandconcern')
        .then(x => x.json())
        .then(y => {
            noncrudcoll01 = y;
            console.log(noncrudcoll01)
            display05();
        });
}

function display05() {
    document.getElementById('NonCrudYOOCandRMOTBFORM1').style.display = "none";
    document.getElementById('NonCrudAvgCarAgeFORM3').style.display = "none";
    document.getElementById('NonCrudBrandWTMCFORM4').style.display = "none";

    document.getElementById('NonCrudConcernWTMBFORM5').style.display = "initial";
    document.getElementById('resultNoNCrudBrandWTMC').innerHTML = "";
    noncrudcoll01.forEach(t => {
        document.getElementById('resultNoNCrudBrandWTMC').innerHTML +=
            "<tr><td>"
            + t.concern + "</td></tr>";
        console.log(t);
    })
}

