import { Component } from '@angular/core';
import { Sidebar } from "../../shared/sidebar/sidebar";
import { RouterOutlet } from "@angular/router";

@Component({
  selector: 'app-layout',
  imports: [Sidebar, RouterOutlet],
  templateUrl: './layout.html',
  styleUrl: './layout.css'
})
export class Layout {

}
