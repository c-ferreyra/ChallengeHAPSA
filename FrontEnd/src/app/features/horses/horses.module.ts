import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';

import { HorsesRoutingModule } from './horses-routing.module';
import { HorsesSearchComponent } from './pages/horses-search/horses-search.component';

@NgModule({
  declarations: [HorsesSearchComponent],
  imports: [CommonModule, ReactiveFormsModule, HorsesRoutingModule]
})
export class HorsesModule {}
