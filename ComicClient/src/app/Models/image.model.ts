export class Image  {
    icon_url: string;
    medium_url: string;
    screen_url: string;
    screen_large_url: string;
    small_url: string;
    thumb_url: string;
    tiny_url: string;
    original_url: string;
    image_tags: string;

    constructor(obj?: any) {
        Object.assign(this, obj);
    }
}