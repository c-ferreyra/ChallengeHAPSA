import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { HorsesCreateComponent } from './pages/horses-create/horses-create.component';
import { HorsesSearchComponent } from './pages/horses-search/horses-search.component';

const routes: Routes = [
  {
    path: '',
    component: HorsesSearchComponent
  },
  {
    path: 'create',
    component: HorsesCreateComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HorsesRoutingModule {}
