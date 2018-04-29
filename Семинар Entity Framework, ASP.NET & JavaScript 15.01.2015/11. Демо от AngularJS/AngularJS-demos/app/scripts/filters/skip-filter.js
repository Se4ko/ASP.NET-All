function SkipFilter() {
    return function (input, count) {
        count = count || 0;
        return input.slice(count);
    };
}