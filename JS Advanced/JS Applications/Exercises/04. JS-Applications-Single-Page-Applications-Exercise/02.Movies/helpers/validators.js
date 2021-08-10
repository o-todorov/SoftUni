export default {
    validateEmail: (email) => {
        let pattern = /^\w+@(\w+\.){1,}[A-Za-z]+$/;
        if(email.match(pattern)) return true;
        window.alert('Invalid email.\nPlease enter a valid email address.');
        return false;
    },
    validatePasswords: (password, rePassword) => {
        if(password.length < 6){
            window.alert('Password too short.\nPlease enter at least 6 charachters.');
            return false;
        }
        if(password != rePassword){
            window.alert('Passwords does not match!');
            return false;
        }
        return true;
    },
    validatePassword: (password) => {
        if(password.length < 6){
            window.alert('Password too short.\nPlease enter a correct password.');
            return false;
        }
        return true;
    },
    validateForEmptyFields: (values) => {
        if(values.some(v => !v)){
            window.alert('All fields must not be empty!');
            return false;
        }
        return true;
    }
}