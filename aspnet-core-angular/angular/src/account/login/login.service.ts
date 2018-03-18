import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { TokenAuthServiceProxy, AuthenticateModel, AuthenticateResultModel, ExternalLoginProviderInfoModel, ExternalAuthenticateModel, ExternalAuthenticateResultModel } from '@shared/service-proxies/service-proxies';
import { UrlHelper } from '@shared/helpers/UrlHelper';
import { AppConsts } from '@shared/AppConsts';

import { MessageService } from '@abp/message/message.service';
import { LogService } from '@abp/log/log.service';
import { TokenService } from '@abp/auth/token.service';
import { UtilsService } from '@abp/utils/utils.service';

import * as _ from 'lodash';

import * as CryptoJS from 'crypto-js';

import { ICryptoUtils } from '@shared/crypto-utils/crypto-utils';

@Injectable()
export class LoginService implements ICryptoUtils {

    static readonly twoFactorRememberClientTokenName = 'TwoFactorRememberClientToken';

    authenticateModel: AuthenticateModel;
    authenticateResult: AuthenticateResultModel;

    rememberMe: boolean;

    constructor(
        private _tokenAuthService: TokenAuthServiceProxy,
        private _router: Router,
        private _utilsService: UtilsService,
        private _messageService: MessageService,
        private _tokenService: TokenService,
        private _logService: LogService
    ) {
        this.clear();
    }

    authenticate(finallyCallback?: () => void): void {
        finallyCallback = finallyCallback || (() => { });

        let userDTO: AuthenticateModel = new AuthenticateModel();
        userDTO.password = this.encrypt("AES", this.authenticateModel.password, "srct-key-" + this.authenticateModel.userNameOrEmailAddress);
        userDTO.rememberClient = this.authenticateModel.rememberClient;
        userDTO.userNameOrEmailAddress = this.authenticateModel.userNameOrEmailAddress;

        this._tokenAuthService
            .authenticate(userDTO)
            .finally(finallyCallback)
            .subscribe((result: AuthenticateResultModel) => {
                this.processAuthenticateResult(result);
            });
    }

    private processAuthenticateResult(authenticateResult: AuthenticateResultModel) {
        this.authenticateResult = authenticateResult;

        if (authenticateResult.accessToken) {
            //Successfully logged in
            this.login(authenticateResult.accessToken, authenticateResult.encryptedAccessToken, authenticateResult.expireInSeconds, this.rememberMe);

        } else {
            //Unexpected result!

            this._logService.warn('Unexpected authenticateResult!');
            this._router.navigate(['account/login']);
        }
    }

    private login(accessToken: string, encryptedAccessToken: string, expireInSeconds: number, rememberMe?: boolean): void {

        var tokenExpireDate = rememberMe ? (new Date(new Date().getTime() + 1000 * expireInSeconds)) : undefined;

        this._tokenService.setToken(
            accessToken,
            tokenExpireDate
        );

        this._utilsService.setCookieValue(
            AppConsts.authorization.encrptedAuthTokenName,
            encryptedAccessToken,
            tokenExpireDate,
            abp.appPath
        );

        var initialUrl = UrlHelper.initialUrl;
        if (initialUrl.indexOf('/account') > 0) {
            initialUrl = AppConsts.appBaseUrl;
        }

        location.href = initialUrl;
    }

    private clear(): void {
        this.authenticateModel = new AuthenticateModel();
        this.authenticateModel.rememberClient = false;
        this.authenticateResult = null;
        this.rememberMe = false;
    }

    encrypt(type: string, text: string, key: string): string {
        let options: any = { mode: CryptoJS.mode.CBC, padding: CryptoJS.pad.Pkcs7 };
        
        key = CryptoJS.enc.Utf8.parse(key);

        let first : string = key.toString().toUpperCase().substring(0, 2);
        let second : string = key.toString().toUpperCase().substring(2, 4);
        let third : string = key.toString().toUpperCase().substring(4, 6); 
        let others : string = key.toString().toUpperCase().substring(6, key.toString().length);

        let json = CryptoJS[type].encrypt(text, first + third + second + others, options);

        return json.toString();
    }

    decrypt(type: string, ciphertext: string, key: string): string {
        let bytes = CryptoJS[type].decrypt(ciphertext, key);
        return bytes.toString(CryptoJS.enc.Utf8);
    }    
}
