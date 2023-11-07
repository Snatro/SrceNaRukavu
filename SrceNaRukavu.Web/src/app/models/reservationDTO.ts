import { PersonSimpleDTO } from "./person-simpleDTO";
import { ProductSimpleDTO } from "./product-simpleDTO";


export class ReservationDTO {
  id : number;
  product: ProductSimpleDTO;
  person: PersonSimpleDTO;
}