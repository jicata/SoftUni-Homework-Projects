function attachEvents() {
    let appId = `kid_BJXTsSi-e`;
    let kinveyUrl = `https://baas.kinvey.com/appdata/${appId}/`;
    let base64auth = btoa(`guest:guest`);
    let authHeader = {"Authorization": "Basic " + base64auth};

    (function () {
        let studentsUrl  = kinveyUrl + "students";
        let req = {
            url:studentsUrl,
            headers:authHeader
        };

        let student = {
            ID : 1337,
            FirstName : `Kiro Ti Si`,
            LastName : `Ebasi manqkaaa`,
            FacultyNumber : `133758327`,
            Grade : 2
        };
        let addAStudentReq = {
            type:'POST',
            url: studentsUrl,
            headers: authHeader,
            data:JSON.stringify(student),
            contentType:"application/json",
        };


        $.ajax(addAStudentReq)
            .catch(error);

        $.ajax(req)
            .then(renderStudents)
            .catch(error);

        function renderStudents(response) {
            for(let student of response){
                let facultyId = student.FacultyNumber;
                let firstName = student.FirstName;
                let grade = student.Grade;
                let id = student.ID;
                let lastName = student.LastName;
                $(`<tr>`)
                    .append($(`<td>${id}</td>`))
                    .append($(`<td>${firstName}</td>`))
                    .append($(`<td>${lastName}</td>`))
                    .append($(`<td>${facultyId}</td>`))
                    .append($(`<td>${grade}</td>`))
                    .appendTo($("#results"))

            }
        }

        function error() {
            console.log('woorps');
        }
    })();




}