import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-chatbot',
  templateUrl: './chatbot.component.html',
  styleUrls: ['./chatbot.component.css']
})
export class ChatbotComponent implements OnInit {

  constructor(private http : HttpClient) { }

  ngOnInit() {
  }
 
  close(){
    (document.getElementById('chatbox') as HTMLElement).style.display = 'none'; 
  }
}
