import { Authenticate } from "./authenticate.model";
import { Role } from "./role.model";

export class Person{
  id? : number;
  name: string;
  surname: string;
  role: Role;
  email: string;
  telephone?: string;
  city?: string;
  address?: string;
  authenticate: Authenticate;
}