function Welcome(person) {
    return "<h2>Hello " + person + ", Lets learn TypeScript</h2>";
}
function ClickMeButton() {
    var user = "MithunVP";
    document.getElementById("divMsg").innerHTML = Welcome(user);
}
function TSButton() {
    var name = "Fred";
    document.getElementById("ts-example").innerHTML = greeter(user);
}
var Student = /** @class */ (function () {
    function Student(firstName, middleInitial, lastName) {
        this.firstName = firstName;
        this.middleInitial = middleInitial;
        this.lastName = lastName;
        this.fullName = firstName + " " + middleInitial + " " + lastName;
    }
    return Student;
}());
function greeter(person) {
    return "Hello, " + person.firstName + " " + person.lastName;
}
var user = new Student("Fred", "M.", "Smith");
//# sourceMappingURL=app.js.map