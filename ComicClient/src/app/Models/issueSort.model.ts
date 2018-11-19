export class IssueSort  {
    cover_date: string;
    date_added: string;
    date_last_updated: string;
    id: string;
    issue_number: string;
    store_date: string;
    name: string;

    constructor(obj?: any) {
        Object.assign(this, obj);
    }
}