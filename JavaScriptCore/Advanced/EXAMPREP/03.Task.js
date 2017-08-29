/*jshint esversion: 6 */
class Task {
    constructor(title, deadline) {
        if (new Date().getTime() > deadline.getTime()) {
            throw new Error
        }

        this.title = title;
        this._deadline = deadline;
        this.status = 'Open';
    }

    get isOverdue() {
        return Date.now() > this._deadline &&
            this.status != 'Complete';

    }

    get deadline() {
        return this._deadline;
    }

    set deadline(value) {
        if (value < Date.now()) {
            throw new Error("")
        }
        this._deadline = value;
    }

    static comparator(a,b){
        let statusWeights = {
            'In Progress': 3,
            'Open': 2,
            'Complete': 1
        };

        if(a.isOverdue && !b.isOverdue){
            return -1;
        }
        if(!a.isOverdue && b.isOverdue){
            return 1;
        }
        let aStatusWeight = statusWeights[a.status];
        let bStatusWeight = statusWeights[b.status];
        if(aStatusWeight == bStatusWeight ||
            a.isOverdue && b.isOverdue){
            return a.deadline.getTime() - b.deadline.getTime();
        }
        if(aStatusWeight > bStatusWeight){
            return -1;
        }
        if(bStatusWeight > aStatusWeight){
            return 1;
        }
        return 0;

    }

    toString() {
        let statusIcon = '';
        switch (this.status) {
            case 'Open':
                statusIcon = "\u2731";
                break;
            case 'In Progress':
                statusIcon = "\u219D";
                break;
            case 'Complete':
                statusIcon = "\u2714";
                break;
        }
        if(this.isOverdue){
            statusIcon = "\u26A0";
        }
        let result = `[${statusIcon}]`;
        if(this.status == 'Complete'){
            return `${result} ${this.title}`;
        }
        if(this.isOverdue){
            return `${result} ${this.title} (overdue)`;
        }
        return `${result} ${this.title} (deadline: ${this.deadline})`;

    }

}
let date1 = new Date();
date1.setDate(date1.getDate() + 7); // Set date 7 days from now
let task1 = new Task('JS Homework', date1);
let date2 = new Date();
date2.setFullYear(date2.getFullYear() + 1); // Set date 1 year from now
let task2 = new Task('Start career', date2);
console.log(task1 + '\n' + task2);
let date3 = new Date();
date3.setDate(date3.getDate() + 3); // Set date 3 days from now
let task3 = new Task('football', date3);
// Create two tasks with deadline set to current time
let task4 = new Task('Task 4', new Date());
let task5 = new Task('Task 5', new Date());
task1.status = 'In Progress';
task3.status = 'In Progress';
task5.status = "Complete";
let tasks = [task1, task2, task3, task4, task5];
setTimeout(() => {
    tasks.sort(Task.comparator);
    console.log(tasks.join('\n'));
}, 1000); // Sort and print one second later
