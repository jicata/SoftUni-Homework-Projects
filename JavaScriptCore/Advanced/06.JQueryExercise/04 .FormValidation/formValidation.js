function validate() {
    function companyInfo() {
        if (this.checked) {
            $(`#companyInfo`).css('display', 'block');
        }
        else {
            $(`#companyInfo`).css('display', 'none');
        }
    }

    $(`#company`).change(companyInfo);
    $(`#submit`).click(validateAllTheFields);

    function validateAllTheFields() {
        let username = $(`#username`);
        let email = $(`#email`);
        let password = $(`#password`);
        let confirmPassword = $(`#confirm-password`);
        let companyNumber;


        if ($(`#company`).is(":checked")) {
            companyNumber = $(`#companyNumber`);
            validateCompanyNumber(companyNumber)
        }else{
            $('#companyNumber').css("border","none");
        }
        validateUsername(username);
        validateEmail(email);
        validatePassword(password, confirmPassword);

        let redBoxesCount = $(`*`).filter(function(){
            "use strict";

            return $(this).css('border-color') == 'rgb(255, 0, 0)';

        }).length;

        let resultDiv = $('#valid');
        if(redBoxesCount != 0){
            resultDiv.css('display','none');
        }
        else{
            resultDiv.css('display','block');
        }

        function validateCompanyNumber(companyNumber) {
            let companyNumberText = Number(companyNumber.val());
            if (companyNumberText >= 1000 && companyNumberText <= 9999) {
                companyNumber.css('border', 'none');
            } else {
                companyNumber.css('border-color', 'red');
            }
        }

        function validatePassword(password, confirmPassword) {
            "use strict";
            let passwordPattern = /^([a-zA-Z0-9_]){5,15}$/;
            let passwordText = password.val();
            let confirmPasswordText = confirmPassword.val();
            let match = passwordPattern.exec(passwordText);
            if (!match || passwordText != confirmPasswordText) {
                password.css('border-color', 'red');
                confirmPassword.css('border-color', 'red');
            }
            else {
                password.css('border', 'none');
                confirmPassword.css('border', 'none');
            }
        }


        function validateEmail(email) {
            let emailText = email.val();
            if (emailText.indexOf('@') != -1 && emailText.indexOf('.') != -1) {
                email.css('border', 'none');
            }
            else {
                email.css('border-color', 'red');
            }
        }


        function validateUsername(username) {
            let usernamePattern = /^(?:[\w\d]){3,20}$/;
            let usernameText = username.val();
            let match = usernamePattern.exec(usernameText);
            if (!match) {
                username.css('border-color', 'red');
            } else {
                username.css('border', 'none');
            }
        }
    }
}
