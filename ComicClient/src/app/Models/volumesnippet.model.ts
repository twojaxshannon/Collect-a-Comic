export class VolumeSnippet  {
    api_detail_url: string;
    id: number;
    name: string;
    site_detail_url: string;

    constructor(obj?: any) {
        Object.assign(this, obj);
    }
}