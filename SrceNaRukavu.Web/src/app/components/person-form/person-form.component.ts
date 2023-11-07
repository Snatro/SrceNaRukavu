import { Component, OnInit, inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Role } from 'src/app/models/role.model';
import { AuthService } from 'src/app/services/auth.service';
import { RoleService } from 'src/app/services/role.service';

@Component({
  selector: 'app-person-form',
  templateUrl: './person-form.component.html',
  styleUrls: ['./person-form.component.css']
})
export class PersonFormComponent implements OnInit {

  
  private fb = inject(FormBuilder);
  private auth = inject(AuthService);
  private roleService = inject(RoleService);

  public validateProfileForm : FormGroup = this.fb.group({
    name:['',Validators.required],
    surname:['',Validators.required],
    email:['',[Validators.required,Validators.email]],
    telephone:[''],
    city:[''],
    address:[''],
    role: [null,Validators.required],
    username:['',Validators.required],
    password:['',Validators.required]
  });

  public roles : Role[] = [];


  constructor() { }

  ngOnInit(): void {
    this.roleService.getRoles().subscribe(roles =>{
      this.roles = roles;
    })
  }

  
  public submitForm() {
    if (!this.validateProfileForm.valid) {
      Object.values(this.validateProfileForm.controls).forEach((control) => {
        if (control.invalid) {
          control.markAsDirty();
        }
      });
    }
  }

  
  public signUp(){
    if(!this.validateProfileForm.valid){
      return;
    }
    this.auth.signUpUser(this.validateProfileForm.value).then(() => {
      console.log("successfully");
    })
  }

}
