import { HttpErrorResponse } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

import { ApiResult, CreateHorseRequest } from '../../models/horse.model';
import { HorsesService } from '../../services/horses.service';

@Component({
  selector: 'app-horses-create',
  templateUrl: './horses-create.component.html',
  styleUrls: ['./horses-create.component.scss']
})
export class HorsesCreateComponent {
  horseForm: FormGroup = this.fb.group({
    name: ['', [Validators.required, Validators.maxLength(100)]],
    birthday: ['', Validators.required],
    type: ['', Validators.required]
  });

  // el input date trabaja con yyyy-MM-dd; no se permiten fechas futuras
  readonly maxBirthday = new Date().toISOString().substring(0, 10);

  saving = false;
  errorMessage: string | null = null;

  constructor(
    private readonly fb: FormBuilder,
    private readonly horsesService: HorsesService,
    private readonly router: Router
  ) {}

  onSave(): void {
    if (this.horseForm.invalid) {
      this.horseForm.markAllAsTouched();
      return;
    }

    const { name, birthday, type } = this.horseForm.value;
    const request: CreateHorseRequest = { name: name.trim(), birthday, type };

    this.saving = true;
    this.errorMessage = null;

    this.horsesService.create(request).subscribe({
      next: () => this.router.navigate(['/horses']),
      error: (response: HttpErrorResponse) => {
        this.saving = false;
        this.errorMessage = (response.error as ApiResult | null)?.error?.description ?? 'No se pudo crear el caballo.';
      }
    });
  }

  onCancel(): void {
    this.router.navigate(['/horses']);
  }

  isInvalid(controlName: string): boolean {
    const control = this.horseForm.get(controlName);
    return !!control && control.invalid && control.touched;
  }
}
