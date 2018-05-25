import { Component, Injector, ViewChild } from "@angular/core";
import { appModuleAnimation } from '@shared/animations/routerTransition';

import { PagedListingComponentBase, PagedRequestDto } from 'shared/paged-listing-component-base';

import { SpeakerDto } from '@shared/service-proxies/speakers/speaker-dto';
import { PagedResultDtoOfSpeakerDto } from '@shared/service-proxies/speakers/pagedresult-dto-of-speaker-dto';

import { CreateSpeakerComponent } from '@app/speakers/create-speaker/create-speaker.component';
import { EditSpeakerComponent } from '@app/speakers/edit-speaker/edit-speaker.component';

import { SpeakerServiceProxy } from '@shared/service-proxies/service-proxies';

@Component({
    templateUrl: './speakers.component.html',
    animations: [appModuleAnimation()]
})
export class SpeakersComponent extends PagedListingComponentBase<SpeakerDto> {
    @ViewChild('createSpeakerModal') createSpeakerModal: CreateSpeakerComponent;
    @ViewChild('editSpeakerModal') editSpeakerModal: EditSpeakerComponent;

    active: boolean = false;
    speakers: SpeakerDto[] = [];

    constructor(
        injector: Injector,
        private _speakerService: SpeakerServiceProxy
    ) {
        super(injector);
    }

    protected list(request: PagedRequestDto, pageNumber: number, finishedCallback: Function): void {
        this._speakerService.getAll(request.skipCount, request.maxResultCount)
            .finally(() => {
                finishedCallback();
            })
            .subscribe((result: PagedResultDtoOfSpeakerDto) => {
                this.speakers = result.items || [];

                if (this.speakers.length > 0)
                    this.showPaging(result, pageNumber);
            });
    }

    protected delete(
        speaker: SpeakerDto
    ): void {
        abp.message.confirm(
            "Deseja remover '" + speaker.name + "'?",
            (result: boolean) => {
                if (result) {
                    this._speakerService.remove(speaker.id)
                        .subscribe(() => {
                            abp.notify.info("Removido o: " + speaker.name);
                            this.refresh();
                        });
                }
            }
        );
    }

    //Show Modals
    createSpeaker(): void {
        this.createSpeakerModal.show();
    }

    editSpeaker(
        speaker: SpeakerDto
    ): void {
        this.editSpeakerModal.show(speaker.id);
    }
}