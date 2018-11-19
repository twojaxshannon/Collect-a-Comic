export class IssueFilter  {
    aliases: string;
    cover_date: string;
    date_added: string;
    date_last_updated: string;
    id: string;
    issue_number: string;
    name: string;
    store_date: string;
    volume: string;

    constructor(obj?: any) {
        Object.assign(this, obj);
    }
}