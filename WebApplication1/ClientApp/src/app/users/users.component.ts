import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {
  public users: any[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    debugger;
    http.get<any[]>(baseUrl + 'api/users').subscribe(result => {
      this.users = result;
    }, error => console.error(error));
  }

  ngOnInit(): void {
  }

}
