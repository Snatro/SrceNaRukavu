import { Person } from "./person.model";
import { Product } from "./product.model";

export class Reservation {
  id?: number;
  person: Person;
  product: Product;
}