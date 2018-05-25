import { Component, ViewChild, Injector, Output, EventEmitter, ElementRef } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap';

import { AppComponentBase } from '@shared/app-component-base';

import { SpeakerDto } from '@shared/service-proxies/speakers/speaker-dto';

import { SpeakerServiceProxy } from '@shared/service-proxies/service-proxies';

@Component({
    selector: 'edit-speaker-modal',
    templateUrl: './edit-speaker.component.html'
})
export class EditSpeakerComponent extends AppComponentBase {
    @ViewChild('editSpeakerModal') modal: ModalDirective;
    @ViewChild('modalContent') modalContent: ElementRef;

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active: boolean = false;
    saving: boolean = false;

    speaker: SpeakerDto = null;

    constructor(
        injector: Injector,
        private _speakerService: SpeakerServiceProxy
    ) {
        super(injector);
    }

    show(id: string): void {
        this._speakerService.get(id)
        .subscribe(
        (result) => {
        this.speaker = result;
        this.active = true;
        this.modal.show();
        }
        );
    }

    onShown(): void {
        $.AdminBSB.input.activate($(this.modalContent.nativeElement));
    }

    save(): void {
        var roles = [];
        $(this.modalContent.nativeElement).find("[name=role]").each(function (ind: number, elem: Element) {
            if ($(elem).is(":checked")) {
                roles.push(elem.getAttribute("value").valueOf());
            }
        });

        this.saving = true;
        this._speakerService.update(this.speaker)
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