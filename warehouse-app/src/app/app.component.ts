import { Component } from '@angular/core';
import { AppComponentService } from './app.component.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'warehouse-app';
  cars: any[] = [];

  constructor(private service: AppComponentService) {
    service.getForecast().subscribe(result => { this.cars = result  });
  }
}
