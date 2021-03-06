import { Component, OnInit } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { ActivityModel } from 'src/app/Models/activity-model';
import { Challenge } from 'src/app/Models/challenge';
import { DeleteService } from 'src/app/Services/Delete/delete-service';
import { GetService } from 'src/app/Services/Get/get-service';
import { PostService } from 'src/app/Services/Post/post-service';
import { PutService } from 'src/app/Services/Put/put-service';

@Component({
  selector: 'app-modify-challenge',
  templateUrl: './modify-challenge.component.html',
  styleUrls: ['./modify-challenge.component.css']
})
export class ModifyChallengeComponent implements OnInit {

  challenge: Challenge = {
    id: '',
    name: '',
    enddate: '',
    startdate: '',
    privacy: '',
    kilometers: 0,
    type: '',
    activityid: ''
  }
  challengeSelected = '';
  challengesArray: Challenge[] = [];

  constructor(private getService: GetService, private cookieSvc:CookieService, private putService: PutService, private deleteService: DeleteService) { }

  ngOnInit(): void {
    this.getAllChallenges(this.cookieSvc.get('Username'));
  }

  modifychallenge(){
    this.putService.modifyChallenge(this.challenge).subscribe(
      res => {
        location.reload()
      },
      err=>{
        alert('Ha ocurrido un error')
      }
    );
  }

  getAllChallenges(AthleteID:string){
    this.getService.getAthleteCreatedChallenges(AthleteID).subscribe(
      res => {
        console.log(res)
        this.challengesArray = res;
      },
      err=>{
        alert('Ha ocurrido un error')
      }
    );
  }

  getCurrentChallenge(){
    console.log(this.challengeSelected)
    for(let i = 0; i < this.challengesArray.length; i++){
      if(this.challengesArray[i].id == this.challengeSelected){
        this.challenge = this.challengesArray[i];
        break;
      }
    }
  }

  deleteChallenge(){
    
    this.deleteService.deleteChallenge(this.challengeSelected).subscribe(
      res => {
        location.reload()
      },
      err=>{
        alert('Ha ocurrido un error')
      }
    );
  }


}
