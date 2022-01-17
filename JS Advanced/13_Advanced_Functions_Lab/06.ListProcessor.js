function listProcessor(input){
    let result = {
        list: [],
        add(text){
            this.list.push(text);
        },
        remove(text){
            this.list = this.list.filter(t => t !== text);
        },
        print(){
            console.log(this.list.join(','));
        }
    }
    
    for (const arg of input) {
        let command = arg.split(' ')[0];
        let text = arg.split(' ')[1];

        switch (command) {
            case 'add':
                result.add(text);
                break;
            case 'remove':
                result.remove(text);
                break;
            case 'print':
                result.print();
                break;
        }
    }
}

listProcessor(['add hello', 'add again', 'remove hello', 'add again', 'print']);