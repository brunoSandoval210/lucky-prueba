import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { LuckyAppComponent } from './components/lucky-app.component';


@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet,LuckyAppComponent],
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'lucky_frontend';
}
