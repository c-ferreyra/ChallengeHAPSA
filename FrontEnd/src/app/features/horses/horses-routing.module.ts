import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { HorsesSearchComponent } from './pages/horses-search/horses-search.component';

const routes: Routes = [
  {
    path: '',
    component: HorsesSearchComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HorsesRoutingModule {}
