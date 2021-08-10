
function solve(){

    let studentsURL = 'http://localhost:3030/jsonstore/collections/students';

    let extractStudents = (function (){
        fetch(studentsURL)
            .then(res => res.json())
            .then(students => fillinTable(Object.values(students)))
            .catch(err => console.log('Error during date extraction'));
    })();

    document.querySelector('#form').addEventListener('submit', createStudent);

    // functionality:
    function fillinTable(students){
        document.querySelector('#results tbody')
                .append(...students.map(createStudentTR));
    }

    function createStudentTR(student){
        return createElement( 
            'tr',
            createElement('td', student.firstName),
            createElement('td', student.lastName),
            createElement('td', student.facultyNumber),
            createElement('td', student.grade)
        )
    }

    async function createStudent(e){
        e.preventDefault();
        let formDate = new FormData(e.currentTarget);
        let facultyNumber = formDate.get('facultyNumber');
        facultyNumber = /[\D]/.test(facultyNumber)?undefined: facultyNumber;

        let student = {
            firstName: formDate.get('firstName'),
            lastName: formDate.get('lastName'),
            facultyNumber,
            grade: Number(formDate.get('grade'))
        }

        for (const key in student) {
            if (!student[key]) return;
        }

        let postMethod = {method: 'POST', 
                            headers: {'Content-Type': 'application/json'}, 
                            body: JSON.stringify(student)};

        try {
            await fetch(studentsURL, postMethod);
            document.querySelector('#results tbody')
                    .appendChild(createStudentTR(student));
        } catch (error) {
            console.log('Error creating new student');
        }
    }

    function createElement(tag, ...args){
        let e =  document.createElement(tag);
        args.forEach(x => {typeof x === 'string' || typeof x === 'number'? e.textContent = x:
            Array.isArray(x)? e.setAttribute(x[0], x[1]): e.appendChild(x);
        });
        return e;
    }
}

solve();