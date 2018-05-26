export interface ICreateSpeakerDto {
    eventId: string,
    profilePic: string,
    name: string,
    title: string,
    about: string,
    twitter: string,
    gitHub: string,
    instagram: string,
    isActive: boolean
}

export class CreateSpeakerDto implements ICreateSpeakerDto {
    eventId: string;
    profilePic: string;
    name: string;
    title: string;
    about: string;
    twitter: string;
    gitHub: string;
    instagram: string;
    isActive: boolean;

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
            this.eventId = data["eventId"];
            this.profilePic = data["profilePic"];
            this.name = data["name"];
            this.title = data["title"];
            this.about = data["about"]; 
            this.twitter = data["twitter"];
            this.gitHub = data["gitHub"];
            this.instagram = data["instagram"];
            this.isActive = data["isActive"];
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
        data["eventId"] = this.eventId;
        data["profilePic"] = this.profilePic;
        data["name"] = this.name;
        data["title"] = this.title;
        data["about"] = this.about;
        data["twitter"] = this.twitter;
        data["gitHub"] = this.gitHub;
        data["instagram"] = this.instagram;
        data["isActive"] = this.isActive;
        return data;
    }

    clone() {
        const json = this.toJSON();
        let result = new CreateSpeakerDto();
        result.init(json);
        return result;
    }
}