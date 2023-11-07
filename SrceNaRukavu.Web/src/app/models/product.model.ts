import { Category } from "./category.model";
import { Section } from "./section.model";

export class Product{
  id: number;
  name: string;
  category: Category;
  description: string;
  price: number;
  size: string;
  isReserved: boolean;
  section: Section;
  image: string;

  sectionId: number;
  categoryId: number;
}