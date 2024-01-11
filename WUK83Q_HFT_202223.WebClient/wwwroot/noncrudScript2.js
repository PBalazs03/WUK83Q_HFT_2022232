function backtomain() {
    window.location.assign("index.html");
}


//let noncrudcoll01 = [];

let noncrudcoll01 = [1, 2, 3];
console.log(noncrudcoll01); // This works

noncrudcoll01 = [];
let avg;
let brandName;


function display03() {
    console.log(avg);
    document.getElementById('resultNoNCrudAvgCarAge').textContent = "";
    document.getElementById('resultNoNCrudAvgCarAge').textContent =
        avg;
    
}

function display04() {
    console.log(brandName);
    document.getElementById('resultNoNCrudAvgCarAge2').textContent = "";
    document.getElementById('resultNoNCrudAvgCarAge2').textContent =
        brandName;

}

async function NonCrudAvgCarAge() {
    await fetch('http://localhost:21840/Auto/average')
        .then(x => x.json())
        .then(y => {
            //console.log(y);
            avg = y;
            display03();
        })
        .catch(error => {
            console.error("Error fetching data:", error);
        });
}

async function NonCrudBrandWTMC() {
    await fetch('http://localhost:21840/Brand/brandwiththemostcars')
        .then(x => x.json())
        .then(y => {
            brandName = y;
            display04();
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

