import { Component, Injector, ViewChild } from '@angular/core';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { EventServiceProxy, EventListDto, ListResultDtoOfEventListDto, EntityDtoOfGuid } from '@shared/service-proxies/service-proxies';
import { PagedListingComponentBase, PagedRequestDto } from "shared/paged-listing-component-base";
import { CreateEventComponent } from "app/events/create-event/create-event.component";

@Component({
    templateUrl: './events.component.html',
    animations: [appModuleAnimation()]
})
export class EventsComponent extends PagedListingComponentBase<EventListDto> {

    @ViewChild('createEventModal') createEventModal: CreateEventComponent;

    active: boolean = false;
    events: EventListDto[] = [];
    includeCanceledEvents:boolean=false;

    constructor(
        injector: Injector,
        private _eventService: EventServiceProxy
    ) {
        super(injector);
    }

    protected list(request: PagedRequestDto, pageNumber: number, finishedCallback: Function): void {
        this.loadEvent();
        finishedCallback();
    }

    protected delete(event: EntityDtoOfGuid): void {
        abp.message.confirm(
            'Are you sure you want to cancel this event?',
            (result: boolean) => {
                if (result) {
                    this._eventService.cancelAsync(event)
                        .subscribe(() => {
                            abp.notify.info('Event is deleted');
                            this.refresh();
                        });
                }
            }
        );
    }

    includeCanceledEventsCheckboxChanged() {
        this.loadEvent();
    };

    // Show Modals
    createEvent(): void {
        this.createEventModal.show();
    }

    loadEvent() {
        this._eventService.getListAsync(this.includeCanceledEvents)
            .subscribe((result: ListResultDtoOfEventListDto) => {
                this.events = result.items;
            });
    }
}
