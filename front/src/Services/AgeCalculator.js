export function getAge(dateString) { //parameter date from form, should look like "03/21/1986"
    var today = new Date();
    var birthDate = new Date(dateString);
    var age = today.getFullYear() - birthDate.getFullYear();
    var m = today.getMonth() - birthDate.getMonth();
    var d = today.getDay() - birthDate.getDay();
    if (m < 0 || (m === 0)
     || d < 0 || (d === 0)
     && today.getDate() < birthDate.getDate()) {
        age--;
    }
    return age;
}