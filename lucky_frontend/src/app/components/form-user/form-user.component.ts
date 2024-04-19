import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { User } from '../../models/user';
import { Departamento } from '../../models/departament';

@Component({
  selector: 'app-form-user',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './form-user.component.html'
})

export class FormUserComponent {
  @Input() user:User;
  @Input() departamentos:Departamento[]=[];
  @Output() newUserEventEmitter:EventEmitter<User>=new EventEmitter();
  @Output() openEventEmitter=new EventEmitter();
  constructor(){
    this.user = new User();
  }

  onSubmit(userform:NgForm):void{
    if(userform.valid)
      {
        this.newUserEventEmitter.emit(this.user);
        console.log(this.user);
      }
      userform.reset();
      userform.resetForm();
  }
  onClear(userform:NgForm):void{
    //this.user=new User();
    userform.reset();
    userform.resetForm();
  }

  onOpenClose(){
    this.openEventEmitter.emit();
  }
}
