import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavBarComponent } from './components/nav-bar/nav-bar.component';
import { AppRoutingModule } from '../app-routing.module';

import { MatToolbar } from '@angular/material/toolbar';
import { MatIcon } from '@angular/material/icon';
import { MatIconButton } from '@angular/material/button';
import { SideBarComponent } from './components/side-bar/side-bar.component';

@NgModule({
  declarations: [
    NavBarComponent,
    SideBarComponent
  ],
  exports: [NavBarComponent, SideBarComponent],
  imports: [
    CommonModule,
    AppRoutingModule,
    MatToolbar,
    MatIcon,
    MatIconButton,
  ]
})
export class SharedModule { }
