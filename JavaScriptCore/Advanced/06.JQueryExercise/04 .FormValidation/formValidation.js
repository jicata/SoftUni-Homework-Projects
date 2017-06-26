function validate() {
    let isCompany = false;
    function companyInfo() {
        if (this.checked) {
            $(`#companyInfo`).css('display', 'block');
            isCompany = true;
        }
        else {
            $(`#companyInfo`).css('display', 'none');
            isCompany = false;
        }
    }

    $(`#company`).change(companyInfo);
    $(`#submit`).click(validateAllTheFields);

    function validateAllTheFields() {
        let allValidFields = 0;

        let username = $(`#username`);
        let email = $(`#email`);
        let password = $(`#password`);
        let confirmPassword = $(`#confirm-password`);
        let companyNumber;


        if ($(`#company`).is(":checked")) {
            companyNumber = $(`#companyNumber`);
            validateCompanyNumber(companyNumber);

        } else {
            $('#companyNumber').removeAttr('style');
            $('#companyNumber').css("border", "none");
        }
        validateUsername(username);
        validateEmail(email);
        validatePassword(password, confirmPassword);


        let resultDiv = $('#valid');
        console.log(allValidFields);
        if(!isCompany && allValidFields==3){
            resultDiv.css('display', 'block');
        }
        else if(isCompany && allValidFields ==4){
            resultDiv.css('display', 'block');
        }
        else{
            resultDiv.css('display', 'none');
        }

        function validateCompanyNumber(companyNumber) {
            let companyNumberText = Number(companyNumber.val());
            if (companyNumberText >= 1000 && companyNumberText <= 9999) {
                companyNumber.removeAttr('style');
                companyNumber.css('border', 'none');
                allValidFields++;
            } else {
                companyNumber.removeAttr('style');
                companyNumber.css('border-color', 'red');
            }
        }

        function validatePassword(password, confirmPassword) {
            "use strict";
            let passwordPattern = /^([a-zA-Z0-9_]){5,15}$/;
            let passwordText = password.val();
            let confirmPasswordText = confirmPassword.val();
            let match = passwordPattern.exec(passwordText);
            password.removeAttr('style');
            confirmPassword.removeAttr('style');
            if (!match || passwordText != confirmPasswordText) {
                password.css('border-color', 'red');
                confirmPassword.css('border-color', 'red');
            }
            else {
                password.css('border', 'none');
                confirmPassword.css('border', 'none');
                allValidFields++;
            }
        }


        function validateEmail(email) {
            let emailText = email.val();
            email.removeAttr('style');
            if (emailText.indexOf('@') != -1 && emailText.indexOf('.',emailText.indexOf('@')) != -1) {
                email.css('border', 'none');
                allValidFields++;
            }
            else {
                email.css('border-color', 'red');
            }
        }


        function validateUsername(username) {
            let usernamePattern = /^(?:[a-zA-Z0-9]){3,20}$/;
            let usernameText = username.val();
            let match = usernamePattern.exec(usernameText);
            username.removeAttr('style');
            if (!match) {
                username.css('border-color', 'red');
            } else {
                username.css('border', 'none');
                allValidFields++;
            }
        }
    }
}
