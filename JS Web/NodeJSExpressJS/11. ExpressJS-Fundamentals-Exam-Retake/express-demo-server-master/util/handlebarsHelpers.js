module.exports = {
    isInRole: (role, roles, opts) => {
        if (roles.indexOf(role) !== -1) {
            return opts.fn(this);
        }
        return opts.inverse(this);
    }
}