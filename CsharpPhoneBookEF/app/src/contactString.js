export function contactString(number) {
    const twoDigits = number % 100;
    const lastDigit = number % 10;

    if ((twoDigits >= 5 && twoDigits <= 20) || (lastDigit === 0) || (lastDigit >= 5 && lastDigit <= 9)) {
        return "контактов";
    }

    if (lastDigit === 1) {
        return "контакт";
    }

    if (lastDigit >= 2 && lastDigit <= 4) {
        return "контакта";
    }

    return "хм..мммм";
}