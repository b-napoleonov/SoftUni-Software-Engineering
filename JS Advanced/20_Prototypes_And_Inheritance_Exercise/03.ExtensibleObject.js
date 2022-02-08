function extensibleObject() {
  let proto = Object.getPrototypeOf(this);

    this.extend = function(template) {
        for (const [key, value] of Object.entries(template)) {
            if (typeof value === 'function') {
                proto[key] = value;
            }
            else{
                this[key] = value;
            }
        }
    }

    return this;
}

const template = {
    extensionMethod: function () { },
    extensionProperty: 'someString'
}
const myObj = extensibleObject();
myObj.extend(template);