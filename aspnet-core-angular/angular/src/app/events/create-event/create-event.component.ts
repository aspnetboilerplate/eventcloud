import { Component, ViewChild, Injector, Output, EventEmitter, ElementRef } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap';
import { EventServiceProxy, CreateEventInput } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/app-component-base';
import { finalize } from 'rxjs/operators';

import * as _ from "lodash";
import * as moment from 'moment';

@Component({
    selector: 'create-event-modal',
    templateUrl: './create-event.component.html'
})
export class CreateEventComponent extends AppComponentBase {

    @ViewChild('createEventModal') modal: ModalDirective;
    @ViewChild('modalContent') modalContent: ElementRef;
    @ViewChild('eventDate') eventDate: ElementRef;

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active: boolean = false;
    saving: boolean = false;
    event: CreateEventInput = null;

    constructor(
        injector: Injector,
        private _eventService: EventServiceProxy
    ) {
        super(injector);
    }

    show(): void {
        this.active = true;
        this.modal.show();
        this.event = new CreateEventInput();
        this.event.init({ isActive: true });
    }

    onShown(): void {
        $.AdminBSB.input.activate($(this.modalContent.nativeElement));
        $(this.eventDate.nativeElement).datetimepicker({
            locale: abp.localization.currentLanguage.name,
            format: 'L'
        });
    }

    save(): void {
        this.saving = true;

        this.event.date = moment($(this.eventDate.nativeElement).data('DateTimePicker').date().format('YYYY-MM-DDTHH:mm:ssZ'));

        this._eventService.createAsync(this.event)
            .pipe(finalize(() => { this.saving = false; }))
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
