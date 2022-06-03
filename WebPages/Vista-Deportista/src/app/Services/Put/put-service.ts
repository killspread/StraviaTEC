import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { AthleteModel } from "src/app/Models/athlete-model";

@Injectable({
    providedIn: 'root'
})

/**
 * Service for the Put Methods to the API
 */
export class PutService {
    
    private baseURL = 'https://localhost:5001/api/';

    constructor(private http: HttpClient) {}
    
    /**
     * Puts the provided Athlete to change its info
     * @param athlete the AthleteModel with the new info of the athlete 
     * to be modified
     * @returns the API response
     */
    updateAthlete(athlete: AthleteModel):Observable<any>{
        let URL = this.baseURL + "Athlete";
        return this.http.put<any>(URL, athlete);
   }
}
