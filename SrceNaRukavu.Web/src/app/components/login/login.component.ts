import { Component, OnInit, inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  private fb = inject(FormBuilder);
  private auth = inject(AuthService);

  public validateLoginForm : FormGroup = this.fb.group({
    username:['',Validators.required],
    password:['',Validators.required]
  });

  constructor() { }

  public submitForm() {
    if (!this.validateLoginForm.valid) {
      Object.values(this.validateLoginForm.controls).forEach((control) => {
        if (control.invalid) {
          control.markAsDirty();
        }
      });
    }
  }

  public login(){
    console.log(this.validateLoginForm.value);
    this.auth.loginUser(this.validateLoginForm.value).then(data => {
      this.validateLoginForm.reset();
      this.auth.storeToken(data.token);
      const token = this.auth.decodedToken();
      console.log(token);
    })
  }

  ngOnInit(): void {
  }

}
