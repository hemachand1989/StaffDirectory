import { Component } from '@angular/core';
import { Router, ActivatedRoute } from "@angular/router";
import { NgZone } from '@angular/core';
import { DataService } from "../../../shared/services/DataService";
@Component({
    selector: 'nav-menu',
    templateUrl: './navmenu.component.html',
    styleUrls: ['./navmenu.component.css'],
 })
export class NavMenuComponent {

    public name?: string;

    constructor(private dataService: DataService, private router: Router, private ngZone: NgZone,private route: ActivatedRoute) {
        
    }
    public searchDirectory() {
        this.router.routeReuseStrategy.shouldReuseRoute = function () {
            return false;
        };
        this.dataService.name = this.name;
        this.ngZone.run(() => this.router.navigate(["/search", { name: this.name }]));
    }
}
