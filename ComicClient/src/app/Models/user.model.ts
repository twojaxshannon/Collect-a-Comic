import {Deserializable} from '../Interfaces/deserializable.model'

export class User  {
    name: string;
    id: string;

    constructor(obj?: any) {
        Object.assign(this, obj);
    }

    // TODO: Test, then get rid of the deserialize interface.
}