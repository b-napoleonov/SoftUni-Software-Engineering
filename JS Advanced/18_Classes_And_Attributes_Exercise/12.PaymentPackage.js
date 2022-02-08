const describe = require("mocha").describe;
const assert = require("chai").assert;

class PaymentPackage {
  constructor(name, value) {
    this.name = name;
    this.value = value;
    this.VAT = 20; // Default value
    this.active = true; // Default value
  }

  get name() {
    return this._name;
  }

  set name(newValue) {
    if (typeof newValue !== "string") {
      throw new Error("Name must be a non-empty string");
    }
    if (newValue.length === 0) {
      throw new Error("Name must be a non-empty string");
    }
    this._name = newValue;
  }

  get value() {
    return this._value;
  }

  set value(newValue) {
    if (typeof newValue !== "number") {
      throw new Error("Value must be a non-negative number");
    }
    if (newValue < 0) {
      throw new Error("Value must be a non-negative number");
    }
    this._value = newValue;
  }

  get VAT() {
    return this._VAT;
  }

  set VAT(newValue) {
    if (typeof newValue !== "number") {
      throw new Error("VAT must be a non-negative number");
    }
    if (newValue < 0) {
      throw new Error("VAT must be a non-negative number");
    }
    this._VAT = newValue;
  }

  get active() {
    return this._active;
  }

  set active(newValue) {
    if (typeof newValue !== "boolean") {
      throw new Error("Active status must be a boolean");
    }
    this._active = newValue;
  }

  toString() {
    const output = [
      `Package: ${this.name}` + (this.active === false ? " (inactive)" : ""),
      `- Value (excl. VAT): ${this.value}`,
      `- Value (VAT ${this.VAT}%): ${this.value * (1 + this.VAT / 100)}`,
    ];
    return output.join("\n");
  }
}

describe("Class PaymentPackage works as intended", () => {
  describe("Name property", function () {
    it("Should throw an error if the first parameter is an empty string", function () {
      assert.throws(
        function () {
          new PaymentPackage("", 500);
        },
        Error,
        "Name must be a non-empty string"
      );
    });

    it("Should throw an error if the first parameter is a non-string", function () {
      assert.throws(
        function () {
          new PaymentPackage(6, 500);
        },
        Error,
        "Name must be a non-empty string"
      );
      assert.throws(
        function () {
          new PaymentPackage({}, 500);
        },
        Error,
        "Name must be a non-empty string"
      );
      assert.throws(
        function () {
          new PaymentPackage([], 500);
        },
        Error,
        "Name must be a non-empty string"
      );
    });

    it("Should be equal to the given name", function () {
      let obj = new PaymentPackage("Consultation", 800);
      assert.equal(obj.name, "Consultation");
    });

    it("Should work when we change the name", function () {
      let obj = new PaymentPackage("Consultation", 800);
      obj.name = "Test";
      assert.equal(obj.name, "Test");
    });
  });

  describe("Value property", function () {
    it("Should throw an error if the second parameter is a non-number or has a negative value", function () {
      assert.throws(
        function () {
          new PaymentPackage("Test", -5);
        },
        Error,
        "Value must be a non-negative number"
      );

      assert.throws(
        function () {
          new PaymentPackage("Test", "");
        },
        Error,
        "Value must be a non-negative number"
      );
      assert.throws(
        function () {
          new PaymentPackage("Test", {});
        },
        Error,
        "Value must be a non-negative number"
      );
      assert.throws(
        function () {
          new PaymentPackage("Test", []);
        },
        Error,
        "Value must be a non-negative number"
      );
    });

    it("Should be equal to the given value", function () {
      let obj = new PaymentPackage("Consultation", 800);
      assert.equal(obj.value, 800);
    });

    it("Should work when we change the value", function () {
      let obj = new PaymentPackage("Consultation", 800);
      obj.value = 222;
      assert.equal(obj.value, 222);
    });
  });

  describe("VAT property", function () {
    it("Should throw an error if the value is a non-number or has a negative value", function () {
      let obj = new PaymentPackage("Consultation", 800);

      assert.throws(
        function () {
          obj.VAT = -5;
        },
        Error,
        "VAT must be a non-negative number"
      );
      assert.throws(
        function () {
          obj.VAT = "";
        },
        Error,
        "VAT must be a non-negative number"
      );
      assert.throws(
        function () {
          obj.VAT = {};
        },
        Error,
        "VAT must be a non-negative number"
      );
      assert.throws(
        function () {
          obj.VAT = [];
        },
        Error,
        "VAT must be a non-negative number"
      );
    });

    it("Should be equal to the default value", function () {
      let obj = new PaymentPackage("Consultation", 800);
      assert.equal(obj.VAT, 20);
    });

    it("Should work when we change the value", function () {
      let obj = new PaymentPackage("Consultation", 800);
      obj.VAT = 333;
      assert.equal(obj.VAT, 333);
    });
  });

  describe("Active property", function () {
    it("Should throw an error if the value is a non-boolean type", function () {
      let obj = new PaymentPackage("Consultation", 800);

      assert.throws(
        function () {
          obj.active = -5;
        },
        Error,
        "Active status must be a boolean"
      );
      assert.throws(
        function () {
          obj.active = "";
        },
        Error,
        "Active status must be a boolean"
      );
      assert.throws(
        function () {
          obj.active = {};
        },
        Error,
        "Active status must be a boolean"
      );
      assert.throws(
        function () {
          obj.active = [];
        },
        Error,
        "Active status must be a boolean"
      );
    });

    it("Should be equal to the default value", function () {
      let obj = new PaymentPackage("Consultation", 800);
      assert.equal(obj.active, true);
    });

    it("Should work when we change the status to false", function () {
      let obj = new PaymentPackage("Consultation", 800);
      obj.active = false;
      assert.equal(obj.active, false);
    });
  });

  describe("toString method", function () {
    it("Should return a specific message if the status is false", function () {
      let inactivePackage = new PaymentPackage("Consultation", 800);
      inactivePackage.active = false;
      let expectedMessage = [
        `Package: Consultation` + " (inactive)",
        `- Value (excl. VAT): 800`,
        `- Value (VAT 20%): 960`,
      ];

      assert.equal(inactivePackage.toString(), expectedMessage.join("\n"));
    });

    it("Should return a specific message if the status is true", function () {
      let package = new PaymentPackage("HR Services", 1500);
      let expectedMessage = [
        `Package: HR Services`,
        `- Value (excl. VAT): 1500`,
        `- Value (VAT 20%): 1800`,
      ];

      assert.equal(package.toString(), expectedMessage.join("\n"));
    });

    it("Should return a specific message if the values are 0", () => {
      let obj = new PaymentPackage("HR Services", 0);
      obj.VAT = 0;
      let expectedMessage = [
        `Package: HR Services`,
        `- Value (excl. VAT): 0`,
        `- Value (VAT 0%): 0`,
      ];

      assert.equal(obj.toString(), expectedMessage.join("\n"));
    });
  });
});