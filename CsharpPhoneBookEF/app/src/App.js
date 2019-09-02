"use strict";

import Vue from "vue";

import "../icon-add.png";
import "../icon-close.png";
import "../icon-edit.png";

import PhoneBook from "./PhoneBook.vue";

(function () {
    new Vue({
        el: "#App",
        template: "<phone-book ref='AppPhoneBook'/>",
        components: {
            "phone-book": PhoneBook
        }
    });
})();