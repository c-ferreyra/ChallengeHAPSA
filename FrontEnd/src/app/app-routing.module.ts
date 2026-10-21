import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    redirectTo: 'horses'
  },
  {
    path: 'horses',
    loadChildren: () => import('./features/horses/horses.module').then((m) => m.HorsesModule)
  },
  {
    path: '**',
    redirectTo: 'horses'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
