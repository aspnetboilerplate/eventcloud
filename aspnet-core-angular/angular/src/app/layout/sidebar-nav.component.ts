import { Component, Injector, ViewEncapsulation } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { MenuItem } from '@shared/layout/menu-item';

@Component({
    templateUrl: './sidebar-nav.component.html',
    selector: 'sidebar-nav',
    encapsulation: ViewEncapsulation.None
})
export class SideBarNavComponent extends AppComponentBase {

    menuItems: MenuItem[] = [
        new MenuItem(this.l("HomePage"), "", "home", "/app/home"),

        new MenuItem(this.l("Tenants"), "Pages.Tenants", "business", "/app/tenants"),
        new MenuItem(this.l("Users"), "Pages.Users", "people", "/app/users"),
        new MenuItem(this.l("Roles"), "Pages.Roles", "local_offer", "/app/roles"),
        new MenuItem(this.l("Events"), "Pages.Events", "event", "/app/events"),
        new MenuItem(this.l("Speakers"), "Pages.Speakers", "assignment_ind", "/app/speakers"),
        new MenuItem(this.l("About"), "", "info", "/app/about"),

        new MenuItem(this.l("Referência"), "", "menu", "", [
            new MenuItem("Think A.M.", "", "", "", [
                new MenuItem("Home", "", "", "http://thinkam.net"),
                new MenuItem("Facebook", "", "", "https://fb.com/thinkam.net"),
                new MenuItem("Twitter", "", "", "https://twitter.com/thinkambr"),
                new MenuItem("Youtube", "", "", "https://www.youtube.com/channel/UCb23pO8PReqkJpixm1t6ycA")
            ])
        ])
    ];

    constructor(
        injector: Injector
    ) {
        super(injector);
    }

    showMenuItem(menuItem): boolean {
        if (menuItem.permissionName) {
            return this.permission.isGranted(menuItem.permissionName);
        }

        return true;
    }
}
