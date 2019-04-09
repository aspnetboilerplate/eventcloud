import { Component, Injector, ViewChild, ElementRef, AfterViewInit } from '@angular/core';
import { TenantRegistrationServiceProxy, CreateTenantDto, TenantDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/app-component-base';
import { Router } from '@angular/router';
import { LoginService } from 'account/login/login.service';
import { accountModuleAnimation } from '@shared/animations/routerTransition';
import { finalize } from 'rxjs/operators';

import * as _ from "lodash";

@Component({
    templateUrl: './register-tenant.component.html',
    animations: [accountModuleAnimation()]
})
export class RegisterTenantComponent extends AppComponentBase implements AfterViewInit{

    @ViewChild('cardBody') cardBody: ElementRef;

    saving: boolean = false;
    tenant: CreateTenantDto = new CreateTenantDto();

    constructor(
        injector: Injector,
        private _router: Router,
        public _loginService: LoginService,
        private _tenantRegistrationService: TenantRegistrationServiceProxy
    ) {
        super(injector);
    }

    ngAfterViewInit(): void {
        $(this.cardBody.nativeElement).find('input:first').focus();
        this.tenant.init({ isActive: true });
    }

    save(): void {
        this.saving = true;
        this._tenantRegistrationService.registerTenantAsync(this.tenant)
            .pipe(finalize(() => { this.saving = false; }))
            .subscribe((result: TenantDto) => {
                this.notify.info(this.l('SavedSuccessfully'));

                //Autheticate
                this.saving = true;
                abp.multiTenancy.setTenantIdCookie(result.id);
                this._loginService.authenticateModel.userNameOrEmailAddress = this.tenant.adminEmailAddress;
                this._loginService.authenticateModel.password = this.tenant.password;
                this._loginService.authenticate(() => { this.saving = false; });
            });
    }
}
