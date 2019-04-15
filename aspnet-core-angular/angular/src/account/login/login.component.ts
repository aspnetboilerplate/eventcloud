import { Component, Injector, ElementRef, ViewChild, OnInit } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { LoginService } from './login.service';
import { accountModuleAnimation } from '@shared/animations/routerTransition';
import { AbpSessionService } from '@abp/session/abp-session.service';
import { Router } from '@angular/router';

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
        private _router: Router,
        private _sessionService: AbpSessionService
    ) {
        super(injector);
    }

    get multiTenancySideIsTenant(): boolean {
        return this._sessionService.tenantId > 0;
    }

    ngOnInit() {
        if (this.appSession.tenant) {
            this.tenancyName = this.appSession.tenant.tenancyName;
            if (this.tenancyName == "Default") {
                this.loginService.authenticateModel.userNameOrEmailAddress = "john";
                this.loginService.authenticateModel.password = "123qwe";
            }
        }
    }

    ngAfterViewInit(): void {
        $(this.cardBody.nativeElement).find('input:first').focus();
    }

    redirectToRegisterTenant(): void {
        var tenantId = abp.multiTenancy.getTenantIdCookie();
        if (tenantId) {
            window.location.href = "account/register-tenant?TenantId=0";
        } else {
            this._router.navigate(['account/register-tenant']);
        }
    }

    login(): void {
        this.submitting = true;
        this.loginService.authenticate(
            () => this.submitting = false
        );
    }
}
