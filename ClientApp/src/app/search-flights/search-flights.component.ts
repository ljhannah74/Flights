import { Component, OnInit } from '@angular/core';
import { FlightService } from '../api/services';
import { FlightRm } from '../api/models';

@Component({
  selector: 'app-search-flights',
  templateUrl: './search-flights.component.html',
  styleUrls: ['./search-flights.component.css']
})
export class SearchFlightsComponent implements OnInit {

  searchResult: FlightRm[] = []

  constructor(private flightService: FlightService) {}

  ngOnInit() {  
  }

  search() {
    this.flightService.searchFlight({})
    .subscribe(response => this.searchResult = response, 
      this.handleError)
  }

  private handleError(err: any) {
    console.log(err);
  }
}
