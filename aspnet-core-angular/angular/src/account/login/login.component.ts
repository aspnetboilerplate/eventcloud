import { Component, Injector, ElementRef, ViewChild, OnInit } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { LoginService } from './login.service';
import { accountModuleAnimation } from '@shared/animations/routerTransition';
import { AbpSessionService } from '@abp/session/abp-session.service';

@Component({
    templateUrl: './login.component.html',
    styleUrls: [
        './login.component.less'
    ],
    animations: [accountModuleAnimation()]
})
export class LoginComponent extends AppComponentBase implements OnInit {

    @ViewChild('cardBody') cardBody: ElementRef;

    submitting: boolean = false;
    tenancyName: string;

    constructor(
        injector: Injector,
        public loginService: LoginService,
        private _sessionService: AbpSessionService
    ) {
        super(injector);
    }

    ngOnInit() {
        if (this.appSession.tenant) {
            this.tenancyName = this.appSession.tenant.tenancyName;
            if (this.tenancyName == "Default") {
                this.loginService.authenticateModel.userNameOrEmailAddress = "admin";
                this.loginService.authenticateModel.password = "123qwe";
            }
        }
    }

    ngAfterViewInit(): void {
        $(this.cardBody.nativeElement).find('input:first').focus();
    }

    get multiTenancySideIsTenant(): boolean {
        return this._sessionService.tenantId > 0;
    }

    login(): void {
        this.submitting = true;
        this.loginService.authenticate(
            () => this.submitting = false
        );
    }
}
