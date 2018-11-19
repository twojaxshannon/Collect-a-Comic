export class VolumeSort  {
    date_added: string;
    date_last_updated: string;
    id: string;
    name: string;

    constructor(obj?: any) {
        Object.assign(this, obj);
    }
}