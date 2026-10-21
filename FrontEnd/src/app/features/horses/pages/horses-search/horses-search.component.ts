import { Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

import { Horse, HorseStatus, HorseType } from '../../models/horse.model';
import { HorsesService } from '../../services/horses.service';

const STATUS_LABELS: Record<HorseStatus, string> = {
  enabled: 'Habilitado',
  disabled: 'Deshabilitado'
};

const TYPE_LABELS: Record<HorseType, string> = {
  racehorse: 'De carrera',
  stallion: 'Padrillo'
};

// TODO: remove once the search endpoint is wired to the backend.
const DUMMY_HORSES: Horse[] = [
  { id: 1, name: 'Furia Roja', birthDate: '2019-03-12', status: 'enabled', type: 'racehorse' },
  { id: 2, name: 'Trueno del Sur', birthDate: '2016-07-04', status: 'enabled', type: 'stallion' },
  { id: 3, name: 'Estrella Fugaz', birthDate: '2021-11-28', status: 'disabled', type: 'racehorse' }
];

@Component({
  selector: 'app-horses-search',
  templateUrl: './horses-search.component.html',
  styleUrls: ['./horses-search.component.scss']
})
export class HorsesSearchComponent {
  filtersForm: FormGroup = this.fb.group({
    name: [''],
    status: [''],
    type: ['']
  });

  horses: Horse[] = DUMMY_HORSES;
  loading = false;
  searched = false;

  constructor(private readonly fb: FormBuilder, private readonly horsesService: HorsesService) {}

  onSearch(): void {
    const { name, status, type } = this.filtersForm.value;

    this.loading = true;

    this.horsesService
      .search({
        name: name || null,
        status: (status || null) as HorseStatus | null,
        type: (type || null) as HorseType | null
      })
      .subscribe({
        next: (horses) => {
          this.horses = horses;
          this.loading = false;
          this.searched = true;
        },
        error: () => {
          this.horses = [];
          this.loading = false;
          this.searched = true;
        }
      });
  }

  onClear(): void {
    this.filtersForm.reset({ name: '', status: '', type: '' });
    this.horses = [];
    this.searched = false;
  }

  onView(horse: Horse): void {
    // TODO: navigate to the horse detail screen once it exists.
    console.log('View horse', horse);
  }

  onCreate(): void {
    // TODO: navigate to the horse creation screen once it exists.
    console.log('Create horse');
  }

  statusLabel(status: HorseStatus): string {
    return STATUS_LABELS[status];
  }

  typeLabel(type: HorseType): string {
    return TYPE_LABELS[type];
  }

  trackByHorseId(_index: number, horse: Horse): number {
    return horse.id;
  }
}
