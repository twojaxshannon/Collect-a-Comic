import { VolumeFilter } from "./volumeFilter.model";
import { VolumeSort } from "./volumeSort.model";
import { IssueFilter } from "./issueFilter.model";
import { IssueSort } from "./issueSort.model";

export class ComicSearch  {
    volumeFilterCriteria: VolumeFilter = new VolumeFilter();
    volumeSortCriteria: VolumeSort = new VolumeSort();
    issueFilterCriteria: IssueFilter = new IssueFilter();
    issueSortCriteria: IssueSort = new IssueSort();

    constructor(obj?: any) {
        Object.assign(this, obj);
    }
}