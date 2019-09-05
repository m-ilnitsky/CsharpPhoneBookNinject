<template>
    <div class="search-wrapper">
        <input :type="inputType"
               class="search-input"
               :placeholder="placeholder"
               data-toggle="popover"
               data-placement="bottom"
               :data-content="popoverText"
               v-model="inputString"
               @input="onInput"
               @change="onChange"
               ref="input">
        <div class="search-reset-button"
             :class="{'visible-button': isText}"
             @click="reset">
            <img src="/../../_public/icon-close.png"
                 alt="x"
                 :title="buttonTitle">
        </div>
    </div>
</template>

<script>
    import $ from "jquery";
    import "bootstrap/dist/js/bootstrap.bundle.min";

    export default {
        props: {
            text: {
                type: String,
                required: true
            },
            reactionOn: {
                type: String,
                required: true,
                validator(value) {
                    return ["input", "change"].indexOf(value) !== -1;
                }
            },
            inputType: {
                type: String,
                default: "text",
                validator(value) {
                    return ["text", "email", "tel", "url"].indexOf(value) !== -1;
                }
            },
            placeholder: {
                type: String,
                default: ""
            },
            popoverText: {
                type: String,
                default: ""
            },
            trimed: {
                type: Boolean,
                default: false
            },
            showPopover: {
                type: Boolean,
                default: false
            },
            buttonTitle: {
                type: String,
                default: "Очистить"
            }
        },
        data() {
            return {
                inputString: this.text,
                reactOnInput: (this.reactionOn === "input"),
                reactOnChange: (this.reactionOn === "change")
            }
        },
        computed: {
            isText() {
                if (this.trimed) {
                    return this.inputString.trim() !== "";
                }

                return this.inputString !== "";
            }
        },
        methods: {
            reset() {
                this.inputString = "";
                this.updateText();
            },
            updateText() {
                if (this.trimed) {
                    this.$emit("update:text", this.inputString.trim());
                }

                this.$emit("update:text", this.inputString);
            },
            onInput() {
                if (this.reactOnInput) {
                    this.updateText();
                }
            },
            onChange() {
                if (this.reactOnChange) {
                    this.updateText();
                }
            },
            focus() {
                this.$refs.input.focus();
            }
        },
        mounted() {
            $(this.$refs.input.$el).popover({ container: "body" });
            $(this.$refs.input.$el).popover("disable");
        },
        beforeUpdate() {
            if (this.isText && this.showPopover) {
                $(this.$refs.input).popover("enable");
                $(this.$refs.input).popover("show");
            } else {
                $(this.$refs.input).popover("disable");
                $(this.$refs.input).popover("hide");
            }
        }
    }
</script>