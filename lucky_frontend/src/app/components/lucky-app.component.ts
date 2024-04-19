import { Component, OnInit } from '@angular/core';
import { User } from '../models/user';
import { UserService } from '../services/user.service';
import { UserComponent } from './user/user.component';
import { FormUserComponent } from './form-user/form-user.component';
import Swal from 'sweetalert2';
import { Departamento } from '../models/departament';
import { DepartamentService } from '../services/departament.service';

@Component({
  selector: 'lucky-app',
  standalone: true,
  imports: [UserComponent,FormUserComponent],
  templateUrl: './lucky-app.component.html',
  styleUrls: ['./lucky-app.component.css']
})
export class LuckyAppComponent implements OnInit{
  title: string = 'Listado de usuarios'

  users:User[] = [];
  departamentos: Departamento[] = [];

  userSelected:User;
  open:boolean=false;

  constructor(private service:UserService, private departamentoService:DepartamentService){
    this.userSelected=new User();
  }

  ngOnInit(): void {
      this.service.findAll().subscribe(users=>this.users=users);
      this.departamentoService.findAll().subscribe(departamentos =>this.departamentos = departamentos);
  }
  addUser(user:User):void{
    if(user.usuario_id>0){
      this.service.update(user).subscribe(updateUser =>{
        this.users=this.users.map(u=>(u.usuario_id==updateUser.usuario_id)?{...updateUser}:u);
        this.refreshPage();
      })
    }else{
      this.service.create(user).subscribe(newUser=>{
        this.users=[...this.users,{...newUser}];
        this.refreshPage();
      });
    }
    Swal.fire({
      title: "Guardado!",
      text: "Guardado con exito!",
      icon: "success"
    });
    this.userSelected=new User();
    this.setOpen();
  }

  refreshPage(): void {
    window.location.reload();
  }

  removeUser(id:number):void{
  Swal.fire({
    title: "Esta seguro?",
    text: "Ciudado se eliminara el usuario, esta seguro?",
    icon: "warning",
    showCancelButton: true,
    confirmButtonColor: "#3085d6",
    cancelButtonColor: "#d33",
    confirmButtonText: "Si"
  }).then((result) => {
    if (result.isConfirmed) {
      this.service.delete(id).subscribe(()=>
        this.users=this.users.filter(user=>user.usuario_id!==id));
      Swal.fire({
        title: "Eliminado!",
        text: "Usuario eliminado",
        icon: "success"
      });
    }
  });
  }

  setSelectedUser(useRow:User):void{
    this.userSelected={...useRow};
  
    this.open=true;
  }

  setOpen(){
    this.open=!this.open;
  }

  
}
