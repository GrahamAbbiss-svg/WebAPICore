function Welcome(person) {
    console.log('Button Clicked');
    return "<h2>Hello " + person + ", Lets learn TypeScript</h2>";
}
function ClickMeButton() {
    var user = "MithunVP- Changes";
    document.getElementById("divMsg").innerHTML = Welcome(user);
}
function TSButton() {
    var name = "Fred";
    document.getElementById("ts-example").innerHTML = greeter(user);
}
var Students = /** @class */ (function () {
    function Students(firstName, middleInitial, lastName) {
        this.firstName = firstName;
        this.middleInitial = middleInitial;
        this.lastName = lastName;
        this.fullName = firstName + " " + middleInitial + " " + lastName;
    }
    return Students;
}());
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
var DataNode = /** @class */ (function () {
    function DataNode(id, title, node) {
        this.id = id;
        this.title = title;
        this.node = node || [];
    }
    DataNode.prototype.addNode = function (node) {
        this.node.push(node);
    };
    return DataNode;
}());
function DoSomething() {
    var data = [
        new DataNode(1, 'something', [
            new DataNode(2, 'something inner'),
            new DataNode(3, 'something more')
        ]),
        new DataNode(4, 'sibling 1'),
        new DataNode(5, 'sibling 2', [
            new DataNode(6, 'child'),
            new DataNode(7, 'another child', [
                new DataNode(8, 'even deeper nested')
            ])
        ])
    ];
    return data;
}
function DoStudent() {
    var user = new Students("Fred", "M.", "Smith");
    return user;
}
function DoStudent1() {
    var user = [new Students("Fred", "M.", "Smith"), new Students("Jake", "S", "Jones")];
    return user;
}
var array = [];
function DoStudent2() {
    var intimate = new Students(document.getElementById('firstname').value, document.getElementById('middlename').value, document.getElementById('surname').value);
    array.push(intimate);
}
function GetStudents() {
    return array;
}
//# sourceMappingURL=app.js.map