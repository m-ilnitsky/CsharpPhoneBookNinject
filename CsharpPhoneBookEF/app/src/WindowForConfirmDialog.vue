<template>
    <div class="modal"
         tabindex="-1"
         role="dialog"
         aria-labelledby="exampleModalLabel"
         aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header text-white">
                    <h5 class="modal-title">{{ title }}</h5>
                    <button type="button"
                            class="close"
                            data-dismiss="modal"
                            aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body bg-dark text-white">
                    <ul style="list-style-type:none;">
                        <li v-for="line in lines">{{ line }}</li>
                    </ul>
                </div>
                <div class="modal-footer bg-dark text-white">
                    <button type="button"
                            class="button btn btn-secondary"
                            data-dismiss="modal">
                        Отменить
                    </button>
                    <button type="button"
                            class="button btn btn-primary"
                            @click="okFunction">
                        {{ okText }}
                    </button>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
    import "bootstrap/dist/js/bootstrap.bundle.min";

    export default {
        props: {
            title: {
                type: String,
                default: "Запрос подтверждения"
            },
            lines: {
                type: [Array, Object],
                required: true
            },
            okText: {
                type: String,
                default: "Подтвердить"
            },
            okFunction: {
                type: Function,
                required: true
            }
        }
    }
</script>