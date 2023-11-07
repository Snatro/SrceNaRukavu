export class CreateProduct{
  constructor(data: Partial<CreateProduct>) {
    Object.assign(this, data);
  }
  
  name: string;
  categoryId: number;
  description: string;
  price: number;
  size: string;
  sectionId: number;
  image: string;
}