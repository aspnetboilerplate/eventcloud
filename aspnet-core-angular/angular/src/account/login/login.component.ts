import { Component, Injector, ElementRef, ViewChild } from '@angular/core';
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
export class LoginComponent extends AppComponentBase {

    @ViewChild('cardBody') cardBody: ElementRef;

    submitting: boolean = false;

    constructor(
        injector: Injector,
        public loginService: LoginService,
        private _sessionService: AbpSessionService
    ) {
        super(injector);
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
