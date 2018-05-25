import { Component, ViewChild, Injector, Output, EventEmitter, ElementRef, OnInit } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap';

import { SpeakerServiceProxy } from '@shared/service-proxies/service-proxies';
import { CreateSpeakerDto } from '@shared/service-proxies/speakers/create-speaker-dto';

import { AppComponentBase } from '@shared/app-component-base';

import { AbpSessionService } from 'abp-ng2-module/src/session/abp-session.service';

@Component({
    selector: 'create-speaker-modal',
    templateUrl: './create-speaker.component.html'
})
export class CreateSpeakerComponent extends AppComponentBase implements OnInit {
    @ViewChild('createSpeakerModal') modal: ModalDirective;
    @ViewChild('modalContent') modalContent: ElementRef;

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active: boolean = false;
    saving: boolean = false;
    speaker: CreateSpeakerDto = null;

    constructor(
        injector: Injector,
        private _speakerService: SpeakerServiceProxy,
        private _sessionService: AbpSessionService
    ) {
        super(injector);
    }

    ngOnInit(): void {

    }

    show(): void {
        this.active = true;
        this.modal.show();
        this.speaker = new CreateSpeakerDto();
        this.speaker.init({ isActive: true });
    }

    onShown(): void {
        $.AdminBSB.input.activate($(this.modalContent.nativeElement));
    }

    save(): void {
        this.saving = true;

        this._speakerService.create(this.speaker)
        .finally(() => { this.saving = false; })
        .subscribe(() => {
        this.notify.info(this.l('SavedSuccessfully'));
        this.close();
        this.modalSave.emit(null);
        });
    }

    close(): void {
        this.active = false;
        this.modal.hide();
    }
}