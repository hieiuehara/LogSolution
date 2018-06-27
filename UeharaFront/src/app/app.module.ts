import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { LogComponent } from './log.component';
import {ApiService} from './log.service'
import { CommonModule } from '@angular/common';
import {MatInputModule, MatTableModule, MatToolbarModule } from '@angular/material';
import { HttpClientModule } from '@angular/common/http'
import { HttpModule } from '@angular/http';

@NgModule({
  declarations: [
    LogComponent
  ],
  imports: [
    BrowserModule,CommonModule, MatToolbarModule, MatInputModule, MatTableModule, HttpClientModule,HttpModule
  ],
  exports: [CommonModule, MatToolbarModule, MatInputModule, MatTableModule],
  providers: [ApiService],
  bootstrap: [LogComponent]
})
export class AppModule { }
