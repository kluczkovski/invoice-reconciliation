export class Greeting{

    constructor(public name: string){}

    greet(){
        console.log(`hello, ${this.name}!`);
    }
}