import { Component, OnInit, AfterViewInit } from '@angular/core';
import { MapService } from 'src/app/Services/Map/map.service';
import { ActivityModel } from 'src/app/Models/activity-model';
import { ActivatedRoute } from '@angular/router';
import { GetService } from 'src/app/Services/Get/get-service';

@Component({
  selector: 'app-activity',
  templateUrl: './activity.component.html',
  styleUrls: ['./activity.component.css']
})
export class ActivityComponent implements OnInit {

  activity: ActivityModel = {
    id: '',
    name: '',
    route: '',
    date: '',
    duration: '',
    kilometers: 0,
    type: '',
    athleteusername: ''
  }
  
  constructor(private getService: GetService, private mapService: MapService, private route: ActivatedRoute) { }

  ngOnInit(): void { 
    /*this.getService.getActivity("1").subscribe(
      res =>{
        this.activity = res;
      }, err => {
        alert("Ha ocurrido un error")
      }
    );*/

    this.mapService.plotActivity(this.activity.route);
  }

}
