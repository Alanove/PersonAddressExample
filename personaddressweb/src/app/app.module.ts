import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PersonComponent } from './person/person.component';
import { TopNavComponent } from './top-nav/top-nav.component';
import { AddressComponent } from './address/address.component';
import { HttpClientModule } from '@angular/common/http';
import { PersonDetailsComponent } from './person-details/person-details.component';
import { AddressDetailsComponent } from './address-details/address-details.component';



@NgModule({
  declarations: [
    AppComponent,
    PersonComponent,
    TopNavComponent,
    AddressComponent,
    PersonDetailsComponent,
    AddressDetailsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
