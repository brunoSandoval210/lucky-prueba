import { Component, EventEmitter, Input, Output } from '@angular/core';
import { User } from '../../models/user';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-user',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './user.component.html'
})
export class UserComponent {
  @Input() users: User[]=[];

  @Output() idUserEventEmitter=new EventEmitter();

  @Output() selectUserEventEmitter=new EventEmitter();

  onRemoveUser(id:number):void{
      this.idUserEventEmitter.emit(id);
  }
  onSelectdUser(user:User):void{
    this.selectUserEventEmitter.emit(user);
  }

}
