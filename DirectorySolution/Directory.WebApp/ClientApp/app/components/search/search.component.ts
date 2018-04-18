import { Component, Inject, OnInit, ChangeDetectorRef } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Http } from '@angular/http';
import { PatternValidator } from '@angular/forms';
import { DataService } from "../../../shared/services/DataService";
import { Router, ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs/Subscription';

@Component({
    selector: 'search',
    templateUrl: './search.component.html',
    styleUrls: ['./search.component.css'],
})
export class SearchComponent implements OnInit {
    public currentCount = 0;
    public apiURL: string;
    public http: Http;
    public model?: DirectoryModel;
    public isSearchSuccess: boolean = false;
    public sub?: Subscription;

    constructor(http: Http, @Inject('API_URL') apiUrl: string, private dataService: DataService, private route: ActivatedRoute) {
        this.apiURL = apiUrl;
        this.http = http;
    }

    public updateLikes() {
        if (this.model != null)
            this.model.apprecitations++;
    }

    public fetchDetails(reporteeModel: DirectoryModel) {
        this.http.get(this.apiURL + 'api/staff/' + reporteeModel.id).subscribe(result => {
            console.log(result.status);
            this.model = result.json() as DirectoryModel;
        }, error => console.error(error));
    }


    ngOnInit() {
        if (this.dataService.name != null) {
            this.http.get(this.apiURL + 'api/staff/' + this.dataService.name).subscribe(result => {
                if (result.status == 200) {
                    console.log(result.status);
                    this.model = result.json() as DirectoryModel;
                    this.isSearchSuccess = true;
                }
                else {
                    this.isSearchSuccess = false;
                    console.log(result);
                }
            }, error => console.error(error));
        }
    }

}

export class DirectoryModel {

    constructor(
        public id:number,
        public name: string,
        public role: string,
        public officeNumber: string,
        public mobileNumber: string,
        public emailId: string,
        public apprecitations: number,
        public reporteeList: DirectoryModel[],
        public reporter?: DirectoryModel,
    ) { }

}