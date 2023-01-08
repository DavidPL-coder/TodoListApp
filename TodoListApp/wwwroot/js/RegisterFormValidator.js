class RegisterFormValidator {
    #validationRules;

    constructor() {
        this.#validationRules = [];
    }

    initValidator() {
        this.#setValidationRules();
        this.#setValidationCheckBeforeSubmit();
        this.#ShowErrorModalIfUserJustExists();
    }

    #setValidationRules() {
        const nameInput = document.querySelector("#name-input");
        const passwordInput = document.querySelector("#password-input");
        const hasWhitespaces = text => /\s/.test(text);
        const hasValidEmailForm = text => /^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(text);
        const isStrongPassword = text => /\p{Lu}/u.test(text) && /\p{Ll}/u.test(text) && /\d/.test(text);

        this.#addValidationRule("name-input", "name-validation-control", input => input.value.length >= nameInput.minLength && !hasWhitespaces(input.value));
        this.#addValidationRule("email-input", "email-validation-control", input => hasValidEmailForm(input.value));
        this.#addValidationRule("password-input", "password-validation-control", input => input.value.length >= passwordInput.minLength && isStrongPassword(input.value) && !hasWhitespaces(input.value));
        this.#addValidationRule("confirm-password-input", "confirm-password-validation-control", input => input.value === passwordInput.value);
    }

    #setValidationCheckBeforeSubmit() {
        const submitBtn = document.querySelector("#register-submit-btn");
        submitBtn.addEventListener("click", event => {
            for (const rule of this.#validationRules) {
                const isRuleMet = this.#setInputAndValidationControlState(rule.input, rule.validationControl, rule.predicate);
                if (!isRuleMet)
                    event.preventDefault();
            }
        });
    }

    #ShowErrorModalIfUserJustExists() {
        if (viewBag_UserJustExists) {
            const errorModal = new bootstrap.Modal(document.querySelector("#error-modal"));
            errorModal.show();
        }
    }

    #addValidationRule(inputId, validationControlId, predicate) {
        const input = document.querySelector(`#${inputId}`);
        const validationControl = document.querySelector(`#${validationControlId}`);

        input.addEventListener("focusout", () => this.#setInputAndValidationControlState(input, validationControl, predicate));

        const validationRule = { input, validationControl, predicate };
        this.#validationRules.push(validationRule);
    }

    #setInputAndValidationControlState(input, validationControl, predicate) {
        const isValid = predicate(input);

        if (isValid) {
            validationControl.style.display = "none";
            input.style.borderColor = "lightgray";
        }
        else {
            validationControl.style.display = "block";
            input.style.borderColor = "red";
        }

        return isValid;
    }
}

const formValidator = new RegisterFormValidator();
formValidator.initValidator();
