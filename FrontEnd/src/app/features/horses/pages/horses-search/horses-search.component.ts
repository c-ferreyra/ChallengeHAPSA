import { Component, HostListener, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';

import { ApiResult, HorseDto, HorseStatus, HorseType } from '../../models/horse.model';
import { HorsesService } from '../../services/horses.service';
import { HttpErrorResponse } from '@angular/common/http';

const TYPE_LABELS: Record<HorseType, string> = {
  racehorse: 'De carrera',
  stallion: 'Padrillo'
};

// type '' = todos los tipos
const DEFAULT_FILTERS = { name: '', status: 'enabled' as HorseStatus, type: '' as HorseType | '' };

@Component({
  selector: 'app-horses-search',
  templateUrl: './horses-search.component.html',
  styleUrls: ['./horses-search.component.scss']
})
export class HorsesSearchComponent implements OnInit {
  filtersForm: FormGroup = this.fb.group(DEFAULT_FILTERS);

  horses: HorseDto[] = [];
  loading = false;
  searched = false;
  errorMessage: string | null = null;

  // modal de detalle
  detailOpen = false;
  detailLoading = false;
  detailHorse: HorseDto | null = null;
  detailError: string | null = null;
  updatingStatus = false;

  constructor(
    private readonly fb: FormBuilder,
    private readonly horsesService: HorsesService,
    private readonly router: Router
  ) {}

  // al entrar se listan los habilitados (DEFAULT_FILTERS)
  ngOnInit(): void {
    this.onSearch();
  }

  onSearch(): void {
    const { name, status, type } = this.filtersForm.value;

    this.loading = true;
    this.errorMessage = null;

    this.horsesService
      .getAll(name.trim(), status, type || undefined)
      .subscribe({
        next: (horses) => {
          this.horses = horses;
          this.loading = false;
          this.searched = true;
        },
        error: (response: HttpErrorResponse) => {
          this.horses = [];
          this.loading = false;
          this.searched = true;
          this.errorMessage = (response.error as ApiResult | null)?.error?.description ?? 'No se pudo obtener el listado.';
        }
      });
  }

  onClear(): void {
    this.filtersForm.reset(DEFAULT_FILTERS);
    this.onSearch();
  }

  onView(horse: HorseDto): void {
    this.detailOpen = true;
    this.detailLoading = true;
    this.detailHorse = null;
    this.detailError = null;

    this.horsesService.getById(horse.id).subscribe({
      next: (detail) => {
        this.detailHorse = detail;
        this.detailLoading = false;
      },
      error: (response: HttpErrorResponse) => {
        this.detailLoading = false;
        this.detailError = (response.error as ApiResult | null)?.error?.description ?? 'No se pudo obtener el caballo.';
      }
    });
  }

  @HostListener('document:keydown.escape')
  onCloseDetail(): void {
    if (this.updatingStatus) {
      return;
    }

    this.detailOpen = false;
  }

  onDisable(): void {
    this.changeStatus(false);
  }

  onEnable(): void {
    this.changeStatus(true);
  }

  private changeStatus(enable: boolean): void {
    const horse = this.detailHorse;
    const action = enable ? 'habilitar' : 'deshabilitar';

    if (!horse || !confirm(`¿${enable ? 'Habilitar' : 'Deshabilitar'} a ${horse.name}?`)) {
      return;
    }

    this.updatingStatus = true;
    this.detailError = null;

    const request$ = enable ? this.horsesService.enable(horse.id) : this.horsesService.disable(horse.id);

    request$.subscribe({
      next: () => {
        this.updatingStatus = false;
        this.detailHorse = { ...horse, status: enable };
        // refresca la grilla para que refleje el cambio segun el filtro actual
        this.onSearch();
      },
      error: (response: HttpErrorResponse) => {
        this.updatingStatus = false;
        this.detailError = (response.error as ApiResult | null)?.error?.description ?? `No se pudo ${action} el caballo.`;
      }
    });
  }

  onCreate(): void {
    this.router.navigate(['/horses/create']);
  }

  statusLabel(status: boolean): string {
    return status ? 'Habilitado' : 'Deshabilitado';
  }

  typeLabel(type: HorseType): string {
    return TYPE_LABELS[type];
  }
}
