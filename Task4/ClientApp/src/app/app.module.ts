import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { FetchDataComponent, DialogEditItem } from './fetch-data/fetch-data.component';
import { DemoMaterialModule } from './material-module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
  declarations: [
    AppComponent,
    FetchDataComponent,
    DialogEditItem
    
  ],
  entryComponents: [DialogEditItem],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    DemoMaterialModule,
    RouterModule.forRoot([
      { path: 'fetch-data', component: FetchDataComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
