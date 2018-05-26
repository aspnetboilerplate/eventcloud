import { SpeakerDto } from "@shared/service-proxies/speakers/speaker-dto";

export interface IPagedResultDtoOfSpeakerDto {
    totalCount: number | undefined;
    items: SpeakerDto[] | undefined;
}

export class PagedResultDtoOfSpeakerDto implements IPagedResultDtoOfSpeakerDto {
    totalCount: number | undefined;
    items: SpeakerDto[] | undefined;

    constructor(data?: IPagedResultDtoOfSpeakerDto) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(data?: any) {
        if (data) {
            this.totalCount = data["totalCount"];
            if (data["items"] && data["items"].constructor === Array) {
                this.items = [];
                for (let item of data["items"])
                    this.items.push(SpeakerDto.fromJS(item));
            }
        }
    }

    static fromJS(data: any): PagedResultDtoOfSpeakerDto {
        data = typeof data === 'object' ? data : {};
        let result = new PagedResultDtoOfSpeakerDto();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["totalCount"] = this.totalCount;
        if (this.items && this.items.constructor === Array) {
            data["items"] = [];
            for (let item of this.items)
                data["items"].push(item.toJSON());
        }
        return data;
    }

    clone() {
        const json = this.toJSON();
        let result = new PagedResultDtoOfSpeakerDto();
        result.init(json);
        return result;
    }
}