import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddressComponent } from './address/address.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { PersonComponent } from './person/person.component';

const routes: Routes = [
  { path: 'dashboard', component: DashboardComponent },
  { path: 'Person', component: PersonComponent },
  { path: 'Address', component: AddressComponent },
  { path: 'Address/:personId', component: AddressComponent },
  { path: '',   redirectTo: '/dashboard', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes,
    { enableTracing: true }
    )],
  exports: [RouterModule]
})
export class AppRoutingModule { }
