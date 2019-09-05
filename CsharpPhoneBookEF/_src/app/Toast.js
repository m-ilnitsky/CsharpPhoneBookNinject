import $ from "jquery";
import "bootstrap/dist/js/bootstrap.bundle.min";

export default class Toast {
    constructor(appendTo) {
        this.appendTo = appendTo;
    }

    create(title, message, delay) {
        const divToast = $("<div></div>").addClass("toast")
            .prop("role", "alert")
            .prop("aria-live", "assertive")
            .prop("aria-atomic", "true");

        const divToastHeader = $("<div></div>").addClass("toast-header")
            .appendTo(divToast);

        $("<strong></strong>").addClass("mr-auto")
            .text(title)
            .appendTo(divToastHeader);

        const buttonClose = $("<button></button>").addClass("ml-2 mb-1 close")
            .prop("data-dismiss", "toast")
            .prop("aria-label", "Close")
            .click(function () {
                divToast.toast("hide");
            })
            .appendTo(divToastHeader);

        $("<span>&times;</span>")
            .prop("aria-hidden", "true")
            .appendTo(buttonClose);

        $("<div></div>").addClass("toast-body")
            .text(message)
            .appendTo(divToast);

        divToast.appendTo(this.appendTo);
        divToast.toast({ delay: delay });
        divToast.toast("show");
    }
}
