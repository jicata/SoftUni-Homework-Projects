/*jshint esversion: 6 */
$(function () {
    $("#btnLoad").click(loadContacts);
    $("#btnCreate").click(createContact);
    let url = "https://phonebook-433dc.firebaseio.com/phonebook";

    function loadContacts() {
        $("#phonebook").empty();
        $.get(url+".json")
            .then(displayContacts)
            .catch(error);
    }

    function displayContacts(response) {
        let phonebook = response.phonebook;
        for(let contact in phonebook){
            let name = phonebook[contact]["person"];
            let phone = phonebook[contact]["phone"];
            $(`<li>${name}: ${phone}</li>`)
                .append($("<button>Delete</button>")
                    .click(deleteContact.bind(this,contact)))
                .appendTo($("#phonebook"));

        }
    }

    function createContact() {
        let newContact = JSON.stringify({
            person:$("#person").val(),
            phone:$("#phone").val()
        });
        $.post(url+"/phonebook.json",newContact)
            .then(loadContacts)
            .catch(error);

        $("#person").val('');
        $("#phone").val('');
    }

    function deleteContact(key) {
        let request = {
            method: 'DELETE',
            url: url + '/phonebook/' + key + '.json'
        };

        $.ajax(request)
            .then(loadContacts)
            .catch(error);
    }

    function error() {

    }
});