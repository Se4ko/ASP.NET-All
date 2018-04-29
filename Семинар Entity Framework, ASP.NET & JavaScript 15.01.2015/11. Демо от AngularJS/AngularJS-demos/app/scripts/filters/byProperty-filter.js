function FilterByProperty() {
    return function (input, propertyName, substr) {
        substr = (substr || '')
            .toLowerCase();
        var filteredInput = [];
        for (var index in input) {
            var item = input[index];
            if (item[propertyName].toString()
                .toLowerCase()) {
                filteredInput.push(item);
            }
        }
        return filteredInput;
    };
}