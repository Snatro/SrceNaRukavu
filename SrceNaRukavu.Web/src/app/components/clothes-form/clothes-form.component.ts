import {
  Component,
  EventEmitter,
  Inject,
  OnInit,
  Output,
  inject,
} from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { Category } from '../../models/category.model';
import { NzUploadChangeParam, NzUploadFile } from 'ng-zorro-antd/upload';
import { Observable, Subscriber, observable } from 'rxjs';
import { CreateProduct } from 'src/app/models/create-product.model';
import { ProductService } from 'src/app/services/product.service';
import { Product } from 'src/app/models/product.model';
import { CategoryService } from 'src/app/services/category.service';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-clothes-form',
  templateUrl: './clothes-form.component.html',
  styleUrls: ['./clothes-form.component.css'],
})
export class ClothesFormComponent implements OnInit {
  private fb = inject(FormBuilder);
  private productService = inject(ProductService);
  private categoryService = inject(CategoryService);
  public sectionId: number;

  public model: Product;

  public selectedFile: File;

  public isUpdated: boolean = false;

  public validateForm: FormGroup = this.fb.group({
    id:[null],
    name: ['', Validators.required],
    categoryId: [null, Validators.required],
    price: [null, Validators.required],
    size: ['', Validators.required],
    description: ['', Validators.required],
    sectionId: [1],
    image: [null, Validators.required]
  });
  @Output() public closed: EventEmitter<any> = new EventEmitter();
  public imageString: string;

  public categories: Category[];

  constructor(
    private dialogRef: MatDialogRef<ClothesFormComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {
    this.sectionId = data.sectionId;
    this.model = data.product;
  }

  public ngOnInit(): void {
    this.categoryService.get().subscribe((categories) => {
      this.categories = categories;
    });

    if (this.sectionId) {
      this.validateForm.controls['sectionId'].setValue(this.sectionId);
    }
    if (this.model) {
      this.setFormValues();
    }
  }

  public submitForm() {
    if (!this.validateForm.valid) {
      Object.values(this.validateForm.controls).forEach((control) => {
        if (control.invalid) {
          control.markAsDirty();
        }
      });
    }
  }

  handleChange(info: NzUploadChangeParam): void {
    if (info.file.status !== 'uploading') {
      console.log(info.file, info.fileList);
    }
    if (info.file.status === 'done') {
      console.log(`${info.file.name} file uploaded successfully`);
    }
  }

  OnFileChange(event: Event) {
    const input = event.target as HTMLInputElement;
    if (input.files && input.files.length) {
      this.selectedFile = input.files[0];
      this.convertToBase64(this.selectedFile);
    }
  }
  // NAMJESTIT DA KLASA PRIMA VRIJEDNOSTI FORME
  public add() {
    const data: any = this.validateForm.value;
    if (this.isUpdated) {
      console.log(data)
      this.productService
        .updateProduct(data)
        .subscribe(() => {
          this.closed.emit(true);
          this.dialogRef.close();
        });
    } else {
      this.productService.addProduct(data).subscribe(() => {
        this.closed.emit(true);
        this.dialogRef.close();
      });
    }
  }

  public setFormValues() {
    let data = this.model as Product;
    this.validateForm.patchValue({
      id: data.id || null,
      name: data.name || '',
      categoryId: data.category.id || null,
      price: data.price || null,
      size: data.size || '',
      description: data.description || '',
      sectionId: data.sectionId || this.sectionId,
      image: data.image || '',
      isReserved: data.isReserved || false,
    });
    this.isUpdated = true;
  }

  public convertToBase64(file: File) {
    const obs = new Observable((subscriber: Subscriber<any>) => {
      this.readFile(file, subscriber);
    });

    obs.subscribe((result) => {
      this.validateForm.get('image')?.setValue(result);
      this.imageString = result;
    });
  }

  public readFile(file: File, subscriber: Subscriber<any>) {
    const fileReader = new FileReader();
    fileReader.readAsDataURL(file);

    fileReader.onload = () => {
      subscriber.next(fileReader.result);
      subscriber.complete();
    };

    fileReader.onerror = () => {
      subscriber.error();
      subscriber.complete();
    };
  }
}
