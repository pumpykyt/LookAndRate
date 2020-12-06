import { Component, OnInit } from '@angular/core';
import { ActorService } from "../Areas/admin-area/Services/actor.service";
import { Router } from '@angular/router';
import { ActorModel } from "../Models/actor.model";


@Component({
  selector: 'app-actor',
  templateUrl: './actor.component.html',
  styleUrls: ['./actor.component.css']
})
export class ActorComponent implements OnInit {

  constructor(private actorService: ActorService, private router: Router) { }


  thisUrl: string;
  listOfData: ActorModel[] = [];

  ngOnInit() {

    this.thisUrl = this.router.url;
    this.actorService.getAllActor().subscribe
    (
      (AllActors : ActorModel[]) => {
        this.listOfData = AllActors;
        console.log(this.router.url);
      }
    )

  }

}
