<template>
    <div class="container phone-book">
        <div class="row phone-book_window">
            <div class="col-sm-12 col-md-3 phone-book_add-wrapper">
                <div class="bg-dark text-white phone-book_add-dialog">
                    <div class="form-group">
                        <h3>Новый контакт</h3>
                    </div>
                    <div class="form-group">
                        <label for="add-dialog_family">Фамилия </label>
                        <input type="text"
                               class="form-control"
                               name="family"
                               id="add-dialog_family"
                               placeholder="Ввести фамилию"
                               data-toggle="tooltip"
                               title="Можно не вводить если введено имя"
                               ref="newFamily"
                               v-model="newContact.family"
                               :class="{'is-invalid': newContact.isInvalidFamily}">
                        <div class="invalid-feedback">
                            Нет ни имени ни фамилии.
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="add-dialog_name">Имя </label>
                        <input type="text"
                               class="form-control"
                               name="name"
                               id="add-dialog_name"
                               placeholder="Ввести имя"
                               data-toggle="tooltip"
                               title="Можно не вводить если введена фамилия"
                               ref="newName"
                               v-model="newContact.name"
                               :class="{'is-invalid': newContact.isInvalidName}">
                        <div class="invalid-feedback">
                            Нет ни имени ни фамилии.
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="add-dialog_phone">Телефон </label>
                        <input type="text"
                               class="form-control"
                               name="phone"
                               id="add-dialog_phone"
                               placeholder="Ввести телефон"
                               data-toggle="tooltip"
                               title="Нужен корректный телефонный номер не совпадающий с уже имеющимися"
                               ref="newPhone"
                               v-model="newContact.phone"
                               :class="{'is-invalid': newContact.isInvalidPhone}">
                        <div class="invalid-feedback"
                             id="add-dialog_phone-feedback">
                            {{ newContact.invalidPhoneFeedback }}
                        </div>
                    </div>
                    <button type="submit"
                            class="btn btn-primary button add-button"
                            id="add-button"
                            title="Создать новый контакт"
                            @click="addContact">
                        Добавить
                    </button>
                </div>
            </div>

            <div class="col-sm-12 col-md-9 col-lg-8 col-xl-7 phone-book_table-wrapper">
                <div class="bg-dark phone-book_header">
                    <button type="submit"
                            class="btn btn-primary button edit-button"
                            id="edit-button"
                            title="Изменить все выделенные контакты"
                            @click="confirmEditChecked">
                        Изменить
                    </button>
                    <button type="submit"
                            class="btn btn-primary button delete-button"
                            id="delete-button"
                            title="Удалить все выделенные контакты"
                            @click="confirmRemoveChecked">
                        Удалить
                    </button>
                    <search-input ref="searchInput"
                                  input-type="text"
                                  reactionOn="change"
                                  placeholder="Найти"
                                  popover-text="Не найдено ни одного совпадения!"
                                  :trimed="true"
                                  button-title="Очистить поле поиска"
                                  :text.sync="filterString"
                                  :show-popover="!isContacts" />
                </div>
                <table class="table table-sm table-striped table-hover phone-book_table">
                    <thead class="thead-dark">
                        <tr>
                            <th>№</th>
                            <th>Фамилия</th>
                            <th>Имя</th>
                            <th>Телефон</th>
                            <th>
                                <input type="checkbox"
                                       class="checkbox"
                                       id="all-checkbox-top"
                                       v-model="checkedAll"
                                       @click="checkAll">
                            </th>
                            <th id="checked-counter-top" v-cloak v-text="checkedContactsCount+' / '+contacts.length"></th>
                        </tr>
                    </thead>
                    <tbody id="table-body">
                        <tr v-cloak v-for="(contact, index) in contacts"
                            :key="contact.id"
                            :class="{'checked-row': contact.checked}">
                            <td class="column-number" v-cloak v-text="index+1"></td>
                            <td class="column-family" v-cloak v-text="contact.family"></td>
                            <td class="column-name" v-cloak v-text="contact.name"></td>
                            <td class="column-phone" v-cloak v-text="contact.phone"></td>
                            <td class="column-checkbox">
                                <input type="checkbox"
                                       class="checkbox"
                                       v-model="contact.checked"
                                       @click="check(contact)">
                            </td>
                            <td class="column-buttons">
                                <div class="circle-button add-button"
                                     title="Создать новый контакт на основе данного"
                                     @click="copyContact(contact)">
                                    <img src="icon-add.png"
                                         alt="a">
                                </div>
                                <div class="circle-button edit-button"
                                     title="Изменить контакт"
                                     @click="editContact(contact)">
                                    <img src="icon-edit.png"
                                         alt="e">
                                </div>
                                <div class="circle-button delete-button"
                                     title="Удалить контакт"
                                     @click="confirmRemove(contact)">
                                    <img src="icon-close.png"
                                         alt="x">
                                </div>
                            </td>
                        </tr>

                    </tbody>
                    <tfoot class="thead-dark">
                        <tr>
                            <th>№</th>
                            <th>Фамилия</th>
                            <th>Имя</th>
                            <th>Телефон</th>
                            <th>
                                <input type="checkbox"
                                       class="checkbox"
                                       id="all-checkbox-bottom"
                                       v-model="checkedAll"
                                       @click="checkAll">
                            </th>
                            <th id="checked-counter-bottom" v-cloak
                                v-text="checkedContactsCount+' / '+contacts.length"></th>
                        </tr>
                    </tfoot>
                </table>
            </div>
        </div>

        <message-dialog ref="errorMessage"
                        title="Ошибка"
                        :top-message="errorMessage" />

        <message-dialog ref="messageDialog"
                        title="Сообщение"
                        top-message="Не выбрано ни одного контакта!"
                        bottom-message="Для выполнения операции выберите контакты!" />

        <confirm-dialog ref="confirmDialog"
                        title="Запрос подтверждения"
                        :lines="[confirmDialog.message]"
                        :ok-text="confirmDialog.okButtonText"
                        :ok-function="confirm" />

        <confirm-dialog ref="confirmDialogRemoveContact"
                        title="Запрос подтверждения"
                        :lines="confirmRemoveContact"
                        ok-text="Удалить"
                        :ok-function="removeContact" />

        <edit-dialog ref="editDialog"
                     title="Изменение данных контакта"
                     :contact="editedContact"
                     :cancel-function="cancelChange"
                     :ok-function="applyChange" />

    </div>
</template>

<script>
    import "./PhoneBook.scss";

    import $ from "jquery";
    import "bootstrap/dist/js/bootstrap.bundle.min";

    import WindowForMessageDialog from "./WindowForMessageDialog.vue";
    import WindowForConfirmDialog from "./WindowForConfirmDialog.vue";
    import WindowForEditContactDialog from "./WindowForEditContactDialog.vue";
    import InputWithResetButton from "./InputWithResetButton.vue";

    import PhoneBookService from "./PhoneBookService.js";
    import Toast from "./Toast.js";

    import { contactString } from "./contactString.js";

    const IS_PHONE_NUMBER = 1;
    const CONTACT_NOT_FOUND = 11;
    const ALL_CONTACTS_NOT_FOUND = 21;

    export default {
        data() {
            return {
                contacts: [],
                checkedContacts: [],
                isContacts: true,
                newContact: {
                    family: "",
                    name: "",
                    phone: "",
                    isInvalidFamily: false,
                    isInvalidName: false,
                    isInvalidPhone: false,
                    invalidPhoneFeedback: ""
                },
                editedContact: {
                    family: "",
                    name: "",
                    phone: "",
                    initPhone: "",
                    isInvalidFamily: false,
                    isInvalidName: false,
                    isInvalidPhone: false,
                    invalidFamilyFeedback: "Нет ни имени ни фамилии.",
                    invalidNameFeedback: "Нет ни имени ни фамилии.",
                    invalidPhoneFeedback: ""
                },
                contactForRemove: {},
                contactForEdit: {},
                isEditing: false,
                editIndex: -1,
                filterString: "",
                checkedAll: false,
                confirmRemoveContact: {
                    message: "",
                    family: "",
                    name: "",
                    phone: ""
                },
                confirmDialog: {
                    message: "",
                    okButtonText: ""
                },
                errorMessage: "",
                windowWidth: window.innerWidth,
                service: new PhoneBookService(),
                toast: new Toast("#toastBox")
            }
        },
        components: {
            "message-dialog": WindowForMessageDialog,
            "confirm-dialog": WindowForConfirmDialog,
            "edit-dialog": WindowForEditContactDialog,
            "search-input": InputWithResetButton
        },
        computed: {
            isLargeWidth() {
                return this.windowWidth >= 768;
            },
            tooltipPlacement() {
                if (this.isLargeWidth) {
                    return "right";
                }

                return "bottom";
            },
            checkedContactsCount() {
                return this.contacts.reduce((number, contact) => {
                    if (contact.checked) {
                        return number + 1;
                    }
                    return number;
                }, 0);
            }
        },
        watch: {
            filterString(newString) {
                this.loadContacts(newString);
            }
        },
        methods: {
            loadContacts(filter) {
                this.service.getContacts(filter)
                    .done(response => {
                        this.contacts = response.map(contact => {
                            contact.checked = false;
                            return contact;
                        });
                        this.implementChecked();
                        this.isContacts = this.contacts.length > 0;
                    });
            },
            implementChecked() {
                let idIndex = 0;
                let contactIndex = 0;

                while (idIndex < this.checkedContacts.length && contactIndex < this.contacts.length) {
                    if (this.contacts[contactIndex].id === this.checkedContacts[idIndex]) {
                        this.contacts[contactIndex].checked = true;
                        contactIndex++;
                        idIndex++;
                    } else if (this.contacts[contactIndex].id > this.checkedContacts[idIndex]) {
                        idIndex++;
                    } else {
                        contactIndex++;
                    }
                }

                this.updateCheckAll();
            },
            updateCheckedContacts() {
                this.checkedContacts = this.contacts
                    .filter(contact => contact.checked)
                    .map(contact => contact.id);
            },
            updateCheckAll() {
                if (this.contacts.length === 0) {
                    this.checkedAll = false;
                } else {
                    const isNoChecked = this.contacts.some(element => !element.checked);

                    if (this.checkedAll && isNoChecked) {
                        this.checkedAll = false;
                    } else if (!this.checkedAll && !isNoChecked) {
                        this.checkedAll = true;
                    }
                }
            },
            checkAll() {
                if (!this.checkedAll) {
                    this.checkedAll = true;
                    this.contacts.forEach(element => element.checked = true);
                } else {
                    if (this.contacts.every(element => element.checked)) {
                        this.checkedAll = false;
                        this.contacts.forEach(element => element.checked = false);
                    } else {
                        this.checkedAll = true;
                        this.contacts.forEach(element => element.checked = true);
                    }
                }

                this.updateCheckedContacts();
            },
            check(contact) {
                contact.checked = !contact.checked;

                this.updateCheckAll();

                this.updateCheckedContacts();
            },
            copyContact(contact) {
                this.newContact.family = contact.family;
                this.newContact.name = contact.name;
                this.$refs.newPhone.focus();
            },
            simplifyPhone(phoneNumber) {
                return phoneNumber.trim()
                    .replace(/[+]/g, "")
                    .replace(/[(]/g, "")
                    .replace(/[)]/g, "")
                    .replace(/[-]/g, "");
            },
            hasPhone(phoneNumber) {
                const newPhone = this.simplifyPhone(phoneNumber);

                let isPhone = false;

                this.contacts.forEach(contact => {
                    const phoneInRow = this.simplifyPhone(contact.phone);

                    if (phoneInRow === newPhone) {
                        isPhone = true;
                        return false;
                    }
                });

                return isPhone;
            },
            isCorrectPhone(phoneNumber) {
                const phoneRegexp = /^(\+)?([0-9]+)?([(][0-9]+[)])?([\-0-9]+)?[0-9]$/;
                return phoneRegexp.test(phoneNumber);
            },
            addContact() {
                this.newContact.isInvalidFamily = false;
                this.newContact.isInvalidName = false;
                this.newContact.isInvalidPhone = false;

                if (this.newContact.family === "" && this.newContact.name === "") {
                    this.newContact.isInvalidFamily = true;
                    this.newContact.isInvalidName = true;
                }

                if (this.newContact.phone.trim().length === 0) {
                    this.newContact.isInvalidPhone = true;
                    this.newContact.invalidPhoneFeedback = "Нет номера телефона";
                } else if (!this.isCorrectPhone(this.newContact.phone.trim())) {
                    this.newContact.isInvalidPhone = true;
                    this.newContact.invalidPhoneFeedback = "Некорректный номер телефона";
                } else if (this.hasPhone(this.newContact.phone)) {
                    this.newContact.isInvalidPhone = true;
                    this.newContact.invalidPhoneFeedback = "Такой номер телефона уже есть";
                }

                if (this.newContact.isInvalidFamily || this.newContact.isInvalidName) {
                    this.$refs.newFamily.focus();
                    return;
                }

                if (this.newContact.isInvalidPhone) {
                    this.$refs.newPhone.focus();
                    return;
                }

                const contact = {
                    family: this.newContact.family.trim(),
                    name: this.newContact.name.trim(),
                    phone: this.newContact.phone.trim()
                };

                this.service.addContact(contact)
                    .done((res) => {
                        if (res.success) {
                            this.toast.create("Создание", "Добавлен контакт: " + this.newContact.family + " " + this.newContact.name + " " + this.newContact.phone, 6000);
                            this.loadContacts(this.filterString);
                            this.newContact.phone = "";
                            this.$refs.newPhone.focus();
                        } else {
                            if (res.errorCode === IS_PHONE_NUMBER) {
                                this.newContact.isInvalidPhone = true;
                                this.newContact.invalidPhoneFeedback = res.message;
                                this.$refs.newPhone.focus();
                            } else {
                                this.errorMessage = "Ошибка добавления контакта!"
                                $(this.$refs.errorMessage.$el).modal("show");
                            }
                        }
                    });
            },
            confirmRemove(contact) {
                this.confirmRemoveContact.message = "Вы действительно хотите удалить контакт?";
                this.confirmRemoveContact.family = contact.family;
                this.confirmRemoveContact.name = contact.name;
                this.confirmRemoveContact.phone = contact.phone;

                this.contactForRemove = contact;

                $(this.$refs.confirmDialogRemoveContact.$el).modal("show");
            },
            removeContact() {
                this.service.deleteContact(this.contactForRemove.id)
                    .done((res) => {
                        if (res.success) {
                            this.toast.create("Удаление", "Удалён контакт: " + this.contactForRemove.family + " " + this.contactForRemove.name + " " + this.contactForRemove.phone, 6000);
                            this.loadContacts(this.filterString);
                            $(this.$refs.confirmDialogRemoveContact.$el).modal("hide");
                        } else {
                            this.loadContacts(this.filterString);
                            $(this.$refs.confirmDialogRemoveContact.$el).modal("hide");

                            if (res.errorCode === CONTACT_NOT_FOUND) {
                                this.errorMessage = "Ошибка удаления контакта! : " + res.message;
                            } else {
                                this.errorMessage = "Ошибка удаления контакта!";
                            }

                            $(this.$refs.errorMessage.$el).modal("show");
                        }
                    });
            },
            removeCheckedContacts() {
                const ids = this.contacts.filter(contact => contact.checked)
                    .map(contact => contact.id);

                this.service.deleteContacts(ids)
                    .done((res) => {
                        if (res.success) {
                            this.toast.create("Удаление", "Удалено " + res.deleteCount + " " + contactString(res.deleteCount), 6000);
                            this.loadContacts(this.filterString);
                        } else {
                            this.loadContacts(this.filterString);

                            if (res.errorCode === ALL_CONTACTS_NOT_FOUND) {
                                this.errorMessage = "Ошибка удаления контактов! : " + res.message;
                            } else {
                                this.errorMessage = "Ошибка удаления контактов!";
                            }

                            $(this.$refs.errorMessage.$el).modal("show");
                        }
                    });
            },
            confirmRemoveChecked() {
                if (this.checkedContactsCount === 0) {
                    $(this.$refs.messageDialog.$el).modal("show");
                } else if (this.checkedContactsCount === 1) {
                    const checkedContacts = this.contacts.filter(contact => contact.checked);
                    this.confirmRemove(checkedContacts[0]);
                } else {
                    this.confirmDialog.message = "Вы действительно хотите удалить " + this.checkedContactsCount + " " + contactString(this.checkedContactsCount) + "?";
                    this.confirmDialog.okButtonText = "Удалить все";
                    $(this.$refs.confirmDialog.$el).modal("show");
                }
            },
            cancelChange() {
                $(this.$refs.editDialog.$el).modal("hide");
                this.isEditing = false;
                this.editIndex = -1;
            },
            applyChange() {
                this.editedContact.isInvalidFamily = false;
                this.editedContact.isInvalidName = false;
                this.editedContact.isInvalidPhone = false;

                if (this.editedContact.family === "" && this.editedContact.name === "") {
                    this.editedContact.isInvalidFamily = true;
                    this.editedContact.isInvalidName = true;
                }

                if (this.editedContact.phone.trim().length === 0) {
                    this.editedContact.isInvalidPhone = true;
                    this.editedContact.invalidPhoneFeedback = "Нет номера телефона";
                } else if (!this.isCorrectPhone(this.editedContact.phone.trim())) {
                    this.editedContact.isInvalidPhone = true;
                    this.editedContact.invalidPhoneFeedback = "Некорректный номер телефона";
                } else if ((this.editedContact.initPhone.trim() !== this.editedContact.phone.trim()) && this.hasPhone(this.editedContact.phone)) {
                    this.editedContact.isInvalidPhone = true;
                    this.editedContact.invalidPhoneFeedback = "Такой номер телефона уже есть";
                }

                if (this.editedContact.isInvalidFamily || this.editedContact.isInvalidName) {
                    this.$refs.editDialog.$refs.editFamily.focus();
                    return;
                }

                if (this.editedContact.isInvalidPhone) {
                    this.$refs.editDialog.$refs.editPhone.focus();
                    return;
                }

                if (this.editedContact.initFamily.trim() !== this.editedContact.family.trim()
                    || this.editedContact.initName.trim() !== this.editedContact.name.trim()
                    || this.editedContact.initPhone.trim() !== this.editedContact.phone.trim()) {

                    this.contactForEdit.family = this.editedContact.family.trim();
                    this.contactForEdit.name = this.editedContact.name.trim();
                    this.contactForEdit.phone = this.editedContact.phone.trim();

                    this.service.editContact(this.contactForEdit)
                        .done((res) => {
                            if (res.success) {
                                this.toast.create("Редактирование", "Изменён контакт: " + this.contactForEdit.family + " " + this.contactForEdit.name + " " + this.contactForEdit.phone, 6000);
                                this.loadContacts(this.filterString);

                                this.contacts
                                    .filter(contact => contact.id === this.contactForEdit.id)
                                    .forEach(contact => contact.checked = false);

                                this.updateCheckedContacts();

                                $(this.$refs.editDialog.$el).modal("hide");
                                this.isEditing = false;
                            } else {
                                if (res.errorCode === IS_PHONE_NUMBER) {
                                    this.editedContact.isInvalidPhone = true;
                                    this.editedContact.invalidPhoneFeedback = res.message;
                                    this.$refs.editDialog.$refs.editPhone.focus();
                                } else if (res.errorCode === CONTACT_NOT_FOUND) {
                                    $(this.$refs.editDialog.$el).modal("hide");
                                    this.isEditing = false;
                                    this.editIndex = -1;

                                    this.loadContacts(this.filterString);

                                    this.errorMessage = "Ошибка изменения контакта! : " + res.message;
                                    $(this.$refs.errorMessage.$el).modal("show");
                                }
                            }
                        });
                } else {
                    $(this.$refs.editDialog.$el).modal("hide");
                    this.isEditing = false;
                }
            },
            editContact(contact) {
                this.editedContact.family = contact.family;
                this.editedContact.name = contact.name;
                this.editedContact.phone = contact.phone;

                this.editedContact.initFamily = contact.family;
                this.editedContact.initName = contact.name;
                this.editedContact.initPhone = contact.phone;

                this.editedContact.isInvalidFamily = false;
                this.editedContact.isInvalidName = false;
                this.editedContact.isInvalidPhone = false;

                this.contactForEdit = contact;

                $(this.$refs.editDialog.$el).modal("show");
                this.$refs.editDialog.$refs.editPhone.focus();
            },
            confirmEditChecked() {
                if (this.checkedContactsCount === 0) {
                    $(this.$refs.messageDialog.$el).modal("show");
                    return;
                }

                const checkedContacts = this.contacts.filter(contact => contact.checked);

                if (this.checkedContactsCount === 1) {
                    this.editContact(checkedContacts[0]);
                } else {
                    this.confirmDialog.message = "Вы действительно хотите изменить " + this.checkedContactsCount + " " + contactString(this.checkedContactsCount) + "?";
                    this.confirmDialog.okButtonText = "Изменить";
                    $(this.$refs.confirmDialog.$el).modal("show");
                }
            },
            editCheckedContacts() {
                const checkedContacts = this.contacts.filter(contact => contact.checked);

                this.isEditing = false;
                this.editIndex = 0;

                //let count = 0;

                const timerId = setInterval(() => {
                    //count++;
                    //console.log(count);
                    if (this.editIndex >= checkedContacts.length || this.editIndex < 0) {
                        clearInterval(timerId);
                        return;
                    }

                    if (!this.isEditing) {
                        //console.log("this.editIndex = " + this.editIndex);
                        this.isEditing = true;
                        this.editContact(checkedContacts[this.editIndex]);
                        this.editIndex++;
                    }
                }, 50);
            },
            confirm() {
                if (this.confirmDialog.okButtonText === "Удалить все") {
                    this.removeCheckedContacts();
                } else if (this.confirmDialog.okButtonText === "Изменить") {
                    this.editCheckedContacts();
                }

                $(this.$refs.confirmDialog.$el).modal("hide");
            }
        },
        mounted() {
            window.onresize = () => {
                this.windowWidth = window.innerWidth;
            };

            const self = this;

            $([this.$refs.newFamily, this.$refs.newName, this.$refs.newPhone]).tooltip({
                container: "body",
                placement() {
                    return self.tooltipPlacement;
                }
            });

            this.loadContacts("");

            this.$refs.searchInput.focus();
        }
    }
</script>