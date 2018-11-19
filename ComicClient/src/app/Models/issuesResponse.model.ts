import { Issue } from "./issue.model";

export class IssuesResponse  {
    error: string;
    limit: number;
    offset: number;
    number_of_page_results: number;
    number_of_total_results: number;
    status_code: number;
    results: Issue[];
    version: string;

    constructor(obj?: any) {
        Object.assign(this, obj);
    }
}