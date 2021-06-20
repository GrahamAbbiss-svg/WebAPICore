function Welcome(person: string) {
    console.log('Button Clicked');
    return "<h2>Hello " + person + ", Lets learn TypeScript</h2>";
}

function ClickMeButton() {
    let user: string = "MithunVP- Changes";
    document.getElementById("divMsg").innerHTML = Welcome(user);
    
    
}

function TSButton() {
    let name: string = "Fred";
    document.getElementById("ts-example").innerHTML = greeter(user);
}

class Students {
    fullName: string;
    constructor(public firstName: string, public middleInitial: string, public lastName: string) {
        this.fullName = firstName + " " + middleInitial + " " + lastName;
    }
}

class Student {
    fullName: string;
    constructor(public firstName: string, public middleInitial: string, public lastName: string) {
        this.fullName = firstName + " " + middleInitial + " " + lastName;
    }
}

interface Person {
    firstName: string;
    lastName: string;
}

function greeter(person: Person) {
    return "Hello, " + person.firstName + " " + person.lastName;
}

let user = new Student("Fred", "M.", "Smith");

interface IDataNode {
    id: number;
    title: string;
    node: Array<IDataNode>;
}
class DataNode implements IDataNode {
    id: number;
    title: string;
    node: Array<IDataNode>;

    constructor(id: number, title: string, node?: Array<IDataNode>) {
        this.id = id;
        this.title = title;
        this.node = node || [];
    }

    addNode(node: IDataNode): void {
        this.node.push(node);
    }
}
function DoSomething() {

    let data: Array<IDataNode> = [
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

    let user = new Students("Fred", "M.", "Smith");
    return user;
}

function DoStudent1() {
    let user: Array<Students> = [new Students("Fred", "M.", "Smith"), new Students("Jake", "S", "Jones")]
    return user;
}
var array = [];
function DoStudent2() {
    const intimate = new Students((<HTMLInputElement>document.getElementById('firstname')).value, (<HTMLInputElement>document.getElementById('middlename')).value, (<HTMLInputElement>document.getElementById('surname')).value)
    
    array.push(intimate);
}
function GetStudents() {
    return array;
}
