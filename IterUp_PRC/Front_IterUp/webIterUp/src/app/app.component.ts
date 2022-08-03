import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent { 

  chatbotMsn() {
    (document.getElementById('chatbox') as HTMLElement).style.display = 'block'; 
  }

}
