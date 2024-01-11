function backtomain() {
    window.location.assign("index.html");
}


let noncrudcoll01 = [];


//async function NonCrudYOOC() {
//    await fetch('http://localhost:21840/Auto/youngorold?YoungOrOld=')
//        .then(x => x.json())
//        .then(y => {
//            noncrudcoll01 = y;
//            console.log(noncrudcoll01)
//            display012();
//        });
//}

//async function NonCrudRMOTB() {
//    await fetch('http://localhost:21840/Brand/modelsofbrand?brandName=')
//        .then(x => x.json())
//        .then(y => {
//            noncrudcoll01 = y;
//            console.log(noncrudcoll01)
//            display012();
//        });
//}

//function display012() {
//    document.getElementById('NonCrudAvgCarAgeFORM3').style.display = "none";
//    document.getElementById('NonCrudBrandWTMCFORM4').style.display = "none";
//    document.getElementById('NonCrudConcernWTMBFORM5').style.display = "none";

//    document.getElementById('NonCrudYOOCandRMOTBFORM1').style.display = "initial";
//    document.getElementById('resultNoNCrudYOOCandRMOTB').innerHTML = "";
//    noncrudcoll01.forEach(t => {
//        document.getElementById('resultNoNCrudYOOCandRMOTB').innerHTML +=
//            "<tr><td>" + t.autoId
//            + "</td><td>" + t.brand
//            + "</td><td>" + t.type
//            + "</td><td>" + t.vintage
//            + "</td><td>" + t.ownerId
//            + "</td><td>" + t.brandId
//            + "</td></td>";
//        console.log(t);
//    })
//}


function display03() {
    //document.getElementById('NonCrudYOOCandRMOTBFORM1').style.display = "none";
    //document.getElementById('NonCrudBrandWTMCFORM4').style.display = "none";
    //document.getElementById('NonCrudConcernWTMBFORM5').style.display = "none";

   /* document.getElementById('NonCrudAvgCarAgeFORM3').style.display = "initial";*/
    document.getElementById('resultNoNCrudAvgCarAge').innerHTML = "";
    noncrudcoll01.forEach(t => {
        document.getElementById('resultNoNCrudAvgCarAge').innerHTML +=
            + "</td><td>" + t.NonCrudAvgCarAge
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

