export class VolumeFilter  {
    name: string;
    publisher: string;

    constructor(obj?: any) {
        Object.assign(this, obj);
    }
}