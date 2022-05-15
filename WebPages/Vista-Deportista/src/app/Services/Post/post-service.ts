import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { AthleteModel } from "src/app/Models/athlete-model";
import { Observable } from "rxjs";
import { AthleteSearch } from "src/app/Models/athlete-search";
import { AthleteFriends } from "src/app/Models/athlete-friends";
import { ActivityModel } from "src/app/Models/activity-model";


@Injectable({
    providedIn: 'root'
})
export class PostService {
    private baseURL = 'https://straviatec.free.beeceptor.com';
    private searchURL = 'https://straviatec.free.beeceptor.com/search';
    /**
    * Método constructor
    * @param http 
    */
    constructor(private http: HttpClient) {
    }

    signInAthlete(athlete: AthleteModel): Observable<any>{
        return this.http.post<any>(this.baseURL, athlete);
    }

    signUpAthlete(athlete: AthleteModel): Observable<any>{
        return this.http.post<any>(this.baseURL, athlete);
    }

    searchAthletes(athlete:AthleteSearch): Observable<any>{
        return this.http.post<any>(this.searchURL,athlete);
    }

    addFollower(athleteFriend: AthleteFriends): Observable<any>{
        return this.http.post<any>(this.baseURL, athleteFriend);
    }

    createActivity(activity: ActivityModel): Observable<any>{
        return this.http.post<any>(this.baseURL, activity);
    }
}