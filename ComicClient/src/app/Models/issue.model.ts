import { Image } from "./image.model";
import { VolumeSnippet } from "./volumesnippet.model";

export class Issue  {
    aliases: object;
    api_detail_url: string;
    cover_date: string;
    date_added: string;
    date_last_updated: string;
    deck: object;
    description: string;
    id: number;
    image: Image;
    issue_number: string;
    name: string;
    site_detail_url: string;
    store_date: string;
    volume: VolumeSnippet;

    constructor(obj?: any) {
        Object.assign(this, obj);
    }
}