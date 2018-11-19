export class User  {
    name: string;
    id: string;

    constructor(obj?: any) {
        Object.assign(this, obj);
    }
}