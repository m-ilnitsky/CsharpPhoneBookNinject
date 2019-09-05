import $ from "jquery";

export default class PhoneBookService {
    getContacts(searchTerm) {
        return $.get({
            url: "api/PhoneBook/getContacts?term=" + searchTerm,
            cache: false
        });
    }

    post(url, data) {
        return $.post({
            url: url,
            contentType: "application/json",
            data: JSON.stringify(data)
        });
    }

    addContact(contact) {
        return this.post("api/PhoneBook/addContact", contact);
    }

    editContact(contact) {
        return this.post("api/PhoneBook/editContact", contact);
    }

    deleteContact(id) {
        return this.post("api/PhoneBook/deleteContact", id);
    }

    deleteContacts(ids) {
        return this.post("api/PhoneBook/deleteContacts", ids);
    }
}