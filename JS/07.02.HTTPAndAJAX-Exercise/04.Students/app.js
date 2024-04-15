function attachEvents() {
  const baseURL = `http://localhost:3030/jsonstore/collections/students`;
  extractsStudentsRecords();

  const submitButtonElement = document.getElementById('submit');
  const inputFirstNameElement = document.getElementById('firstName');
  const inputLastNameElement = document.getElementById('lastName');
  const inputFacultyNumberElement = document.getElementById('facultyNumber');
  const inputGradeNameElement = document.getElementById('grade');
  const resultTbodyElement = document.querySelector('#results tbody');

  function extractsStudentsRecords() {
    fetch(`${baseURL}`)
    .then(studentsRecordsresponse => studentsRecordsresponse.json())
    .then(data => {
      const studentList = Object.values(data);

      resultTbodyElement.innerHTML = ``;

       for (const student of studentList) {
        const newTrElement = document.createElement('tr');

        const firstNameTdElement = document.createElement('td');
        firstNameTdElement.textContent = student.firstName;
        newTrElement.appendChild(firstNameTdElement);

        const lastNameTdElement = document.createElement('td');
        lastNameTdElement.textContent = student.lastName;
        newTrElement.appendChild(lastNameTdElement);

        const facultyNumberTdElement = document.createElement('td');
        facultyNumberTdElement.textContent = student.facultyNumber;
        newTrElement.appendChild(facultyNumberTdElement);

        const gradeNameTdElement = document.createElement('td');
        gradeNameTdElement.textContent = student.grade.toFixed(2);
        newTrElement.appendChild(gradeNameTdElement);

        resultTbodyElement.appendChild(newTrElement);
       }
    })
    .catch(error => console.log('Something went wrong'));
    
  }

  function createStudent() {
    
  }
}

attachEvents();