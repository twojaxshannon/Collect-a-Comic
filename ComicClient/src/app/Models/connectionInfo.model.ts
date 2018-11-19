import { HttpClient } from "@angular/common/http";

export class ConnectionInfo  {
    http: HttpClient;
    apiUrl: string;

    constructor(obj?: any) {
        Object.assign(this, obj);
    }
}