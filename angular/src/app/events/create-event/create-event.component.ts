import {
  Component,
  ViewChild,
  Injector,
  Output,
  EventEmitter,
  ElementRef,
  OnInit,
} from "@angular/core";
import { DatePipe } from "@angular/common";
import {
  EventServiceProxy,
  CreateEventInput,
} from "@shared/service-proxies/service-proxies";
import { AppComponentBase } from "@shared/app-component-base";
import { BsModalRef } from "ngx-bootstrap/modal";
import { ModalDirective } from "ngx-bootstrap/modal";
import * as moment from "moment";

@Component({
  selector: "create-event-modal",
  templateUrl: "./create-event.component.html",
})
export class CreateEventComponent extends AppComponentBase implements OnInit {
  @ViewChild("createEventModal") modal: ModalDirective;
  @ViewChild("modalContent") modalContent: ElementRef;
  @ViewChild("eventDate") eventDate: ElementRef;

  @Output() onSave = new EventEmitter<any>();

  active: boolean = false;
  saving: boolean = false;
  event = new CreateEventInput();

  constructor(
    injector: Injector,
    private _eventService: EventServiceProxy,
    private datePipe: DatePipe,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }
  ngOnInit(): void {
    throw new Error("Method not implemented.");
  }

  save(): void {
    this.saving = true;

    const selectedDate = moment(
      this.datePipe.transform(this.eventDate.nativeElement.value, "yyyy-MM-dd")
    );
    const today = moment().startOf("day");

    if (selectedDate.isBefore(today)) {
      this.notify.error(this.l("PastDateError"));
      this.saving = false;
      return;
    }

    this.event.date = selectedDate;

    this._eventService.create(this.event).subscribe(
      () => {
        this.notify.info(this.l("SavedSuccessfully"));
        this.bsModalRef.hide();
        this.onSave.emit();
        
      },
      () => {
        this.saving = false;
      }
    );
  }
}
