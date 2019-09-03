import $ from "jquery";

export default class PhoneBookService {
    getContacts(searchTerm) {
        return $.get({
            url: "/getContacts?term=" + searchTerm,
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
        return this.post("/addContact", { request: contact });
    }

    editContact(contact) {
        return this.post("/editContact", { request: contact });
    }

    deleteContact(id) {
        return this.post("/deleteContact", { id: id });
    }

    deleteContacts(ids) {
        return this.post("/deleteContacts", { ids: ids });
    }
}