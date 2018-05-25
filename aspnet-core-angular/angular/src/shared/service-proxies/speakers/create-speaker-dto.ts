export interface ICreateSpeakerDto {
    //attributes
}

export class CreateSpeakerDto implements ICreateSpeakerDto {
    //attributes

    constructor(data?: ICreateSpeakerDto) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(data?: any) {
        if (data) {
            //this.attribute = data["attribute"];
        }
    }

    static fromJS(data: any): CreateSpeakerDto {
        data = typeof data === 'object' ? data : {};
        let result = new CreateSpeakerDto();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        //data["attribute"] = this.attribute;
        return data;
    }

    clone() {
        const json = this.toJSON();
        let result = new CreateSpeakerDto();
        result.init(json);
        return result;
    }
}