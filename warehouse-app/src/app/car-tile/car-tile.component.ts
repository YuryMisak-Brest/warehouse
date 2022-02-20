import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'car-tile',
  templateUrl: './car-tile.component.html',
  styleUrls: ['./car-tile.component.css']
})
export class CarTileComponent implements OnInit {

  @Input() car: any;

  ngOnInit(): void {
  }

}
